using PowerGridScada.BUS;
using PowerGridScada.DTO;

namespace PowerGridScada.GUI
{
    public partial class frmPowerGridMonitor : Form
    {
        private readonly ScadaMonitorBUS _scadaBus = new();
        private CancellationTokenSource? _cts;
        private volatile bool _isMonitoring;
        private int _totalCycles;

        public frmPowerGridMonitor()
        {
            InitializeComponent();
        }

        private void FrmPowerGridMonitor_Load(object? sender, EventArgs e)
        {
            ConfigureGridLogsManually();
            LoadSubstations();
        }

        /// <summary>
        /// Cấu hình thủ công các cột cho DataGridView (dgvGridLogs) hoàn toàn bằng code.
        /// </summary>
        private void ConfigureGridLogsManually()
        {
            dgvGridLogs.AutoGenerateColumns = false;
            dgvGridLogs.Columns.Clear();

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLogId",
                HeaderText = "STT",
                FillWeight = 7,
                MinimumWidth = 45
            });
            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTime",
                HeaderText = "Thời điểm sự cố",
                FillWeight = 16,
                MinimumWidth = 115
            });
            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSubstation",
                HeaderText = "Trạm biến áp",
                FillWeight = 20,
                MinimumWidth = 130
            });
            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVoltage",
                HeaderText = "Điện áp (kV)",
                FillWeight = 13,
                MinimumWidth = 85,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLoad",
                HeaderText = "Mức tải (%)",
                FillWeight = 12,
                MinimumWidth = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSeverity",
                HeaderText = "Mức cảnh báo",
                FillWeight = 18,
                MinimumWidth = 110
            });
            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMessage",
                HeaderText = "Chi tiết cảnh báo",
                FillWeight = 32,
                MinimumWidth = 180
            });
        }

        private void LoadSubstations()
        {
            var substations = _scadaBus.GetSubstations();
            cboSubstation.DataSource = substations;
            if (cboSubstation.Items.Count > 0)
            {
                cboSubstation.SelectedIndex = 0;
            }
        }

        private void BtnStartScada_Click(object? sender, EventArgs e)
        {
            if (_isMonitoring)
            {
                return;
            }

            if (cboSubstation.SelectedItem is not SubstationDTO selectedSubstation)
            {
                MessageBox.Show("Vui lòng chọn Trạm biến áp cần giám sát.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sessionCts = new CancellationTokenSource();
            _cts = sessionCts;
            _isMonitoring = true;

            btnStartScada.Enabled = false;
            btnStopScada.Enabled = true;
            cboSubstation.Enabled = false;

            lblConnectionState.Text = $"SCADA: Đang giám sát {selectedSubstation.SubstationName}";
            lblAlertBanner.ForeColor = SystemColors.ControlText;
            lblAlertBanner.Text = "Trạng thái: Đang thu thập tín hiệu SCADA...";

            // Khởi chạy tiến trình thu thập dữ liệu ngầm trên Background Thread (Task.Run)
            _ = Task.Run(() => RunScadaBackgroundLoop(selectedSubstation, sessionCts));
        }

        /// <summary>
        /// Vòng lặp nền chạy trên Background Thread: định kỳ 2 giây/lần sinh thông số SCADA
        /// và cập nhật lên UI thông qua hàm đảm bảo Thread Safety (InvokeRequired / Invoke).
        /// </summary>
        private void RunScadaBackgroundLoop(SubstationDTO substation, CancellationTokenSource sessionCts)
        {
            var token = sessionCts.Token;
            var random = new Random();

            try
            {
                while (!token.IsCancellationRequested)
                {
                    int cycle = Interlocked.Increment(ref _totalCycles);
                    var (reading, incident) = _scadaBus.SampleTelemetry(substation, cycle, random);

                    // Bắt buộc chuyển ngữ cảnh về Main UI Thread trước khi cập nhật Control
                    UpdateDashboardThreadSafe(reading, incident, token);

                    // Chờ định kỳ 2 giây cho chu kỳ quét kế tiếp
                    Task.Delay(TimeSpan.FromSeconds(2), token).GetAwaiter().GetResult();
                }
            }
            catch (OperationCanceledException)
            {
                // Ngắt kết nối bình thường
            }
            catch (ObjectDisposedException)
            {
                // Form đã đóng
            }
            finally
            {
                sessionCts.Dispose();
            }
        }

        /// <summary>
        /// Quy tắc Thread Safety bắt buộc: kiểm tra InvokeRequired và dùng this.Invoke(new Action(...))
        /// để chuyển ngữ cảnh về Main UI Thread, tuyệt đối không truy cập UI Control trực tiếp từ Background Thread.
        /// </summary>
        private void UpdateDashboardThreadSafe(
            TelemetryReadingDTO reading,
            GridIncidentLogDTO? incident,
            CancellationToken token)
        {
            if (token.IsCancellationRequested || !_isMonitoring || IsDisposed || Disposing || !IsHandleCreated)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => UpdateDashboardThreadSafe(reading, incident, token)));
                }
                catch (ObjectDisposedException)
                {
                }
                catch (InvalidOperationException)
                {
                }
                return;
            }

            // Đang ở Main UI Thread — kiểm tra lại cờ trước khi cập nhật giao diện
            if (token.IsCancellationRequested || !_isMonitoring || IsDisposed || Disposing)
            {
                return;
            }

            lblVoltage.Text = $"{reading.VoltageKv:F2} kV";
            lblLoadPercent.Text = $"{reading.LoadPercent:F1} %";
            prgLoadMeter.Value = Math.Clamp((int)Math.Round(reading.LoadPercent), 0, 100);

            // Đổi màu chữ lblLoadPercent theo yêu cầu bài 6.7: Đỏ nếu > 85%, Xanh lá nếu ổn định
            if (reading.IsOverloaded)
            {
                lblLoadPercent.ForeColor = Color.Red;
                lblAlertBanner.ForeColor = Color.Red;
                lblAlertBanner.Text = "CẢNH BÁO QUÁ TẢI! Vượt ngưỡng an toàn (> 85%)";
            }
            else
            {
                lblLoadPercent.ForeColor = Color.Green;
                lblAlertBanner.ForeColor = Color.Green;
                lblAlertBanner.Text = "Trạng thái: Ổn định (Trong ngưỡng an toàn)";
            }

            lblLastPacketTime.Text = $"Gói tin cuối cùng: {reading.Timestamp:HH:mm:ss}";
            lblTotalCycles.Text = $"Tổng số chu kỳ đã quét: {reading.CycleNumber}";

            if (incident != null)
            {
                dgvGridLogs.Rows.Insert(
                    0,
                    incident.LogId,
                    incident.RecordedAt.ToString("HH:mm:ss dd/MM/yyyy"),
                    incident.SubstationName,
                    $"{incident.VoltageKv:F2}",
                    $"{incident.LoadPercent:F1}%",
                    incident.Severity,
                    incident.Message);

                dgvGridLogs.ClearSelection();
                dgvGridLogs.Rows[0].Selected = true;
            }
        }

        private void BtnStopScada_Click(object? sender, EventArgs e)
        {
            StopScadaMonitoring();
        }

        private void StopScadaMonitoring()
        {
            _isMonitoring = false;
            var oldCts = Interlocked.Exchange(ref _cts, null);
            if (oldCts != null)
            {
                try
                {
                    oldCts.Cancel();
                }
                catch (ObjectDisposedException)
                {
                }
            }

            btnStartScada.Enabled = true;
            btnStopScada.Enabled = false;
            cboSubstation.Enabled = true;

            lblConnectionState.Text = "SCADA: Đã ngắt kết nối";
            lblAlertBanner.ForeColor = SystemColors.ControlText;
            lblAlertBanner.Text = "Trạng thái: Đã ngắt kết nối SCADA";
        }

        private void BtnClearLogs_Click(object? sender, EventArgs e)
        {
            _scadaBus.ClearIncidentLogs();
            dgvGridLogs.Rows.Clear();
        }

        private void FrmPowerGridMonitor_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _isMonitoring = false;
            var oldCts = Interlocked.Exchange(ref _cts, null);
            if (oldCts != null)
            {
                try
                {
                    oldCts.Cancel();
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }
    }
}
