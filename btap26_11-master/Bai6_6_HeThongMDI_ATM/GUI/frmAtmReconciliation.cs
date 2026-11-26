using AtmManagement.BUS;
using AtmManagement.DTO;

namespace AtmManagement.GUI
{
    public partial class frmAtmReconciliation : Form
    {
        private readonly ReconciliationBUS _reconciliationBus = new();
        private CancellationTokenSource? _cts;

        public frmAtmReconciliation()
        {
            InitializeComponent();
        }

        private void FrmAtmReconciliation_Load(object? sender, EventArgs e)
        {
            ConfigureHistoryGrid();
            LoadHistory();
        }

        private void ConfigureHistoryGrid()
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionId",
                HeaderText = "Mã phiên",
                FillWeight = 18,
                MinimumWidth = 110
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StartedAt",
                HeaderText = "Bắt đầu",
                FillWeight = 15,
                MinimumWidth = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm:ss dd/MM" }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalTransactions",
                HeaderText = "Tổng GD",
                FillWeight = 12,
                MinimumWidth = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MatchedCount",
                HeaderText = "Khớp",
                FillWeight = 12,
                MinimumWidth = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiscrepancyCount",
                HeaderText = "Lệch",
                FillWeight = 8,
                MinimumWidth = 55,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                FillWeight = 16,
                MinimumWidth = 95
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Notes",
                HeaderText = "Ghi chú",
                FillWeight = 32,
                MinimumWidth = 150
            });
        }

        private void LoadHistory()
        {
            if (IsDisposed || Disposing)
            {
                return;
            }

            dgvHistory.DataSource = null;
            dgvHistory.DataSource = _reconciliationBus.GetHistory();
        }

        private frmBankAtmMain? GetParentMainForm()
        {
            return MdiParent as frmBankAtmMain;
        }

        private async void BtnStartReconciliation_Click(object? sender, EventArgs e)
        {
            if (_cts != null)
            {
                return;
            }

            _cts = new CancellationTokenSource();
            btnStartReconciliation.Enabled = false;
            btnStopReconciliation.Enabled = true;
            prgLocal.Value = 0;
            lblStepInfo.Text = "Đang khởi tạo kết nối máy chủ Core Banking...";
            lblStats.Text = "Đã xử lý: 0 / 0 giao dịch | Phát hiện lệch: 0";

            var parentMain = GetParentMainForm();
            string operatorName = parentMain?.CurrentTellerName ?? "Đỗ Việt Hoàng";
            parentMain?.UpdateReconciliationProgress(0, "Đang chạy đối soát ATM...");

            var token = _cts.Token;
            var progress = new Progress<ReconciliationProgressDTO>(p =>
            {
                if (IsDisposed || Disposing || token.IsCancellationRequested || _cts == null)
                {
                    return;
                }

                prgLocal.Value = Math.Clamp(p.PercentComplete, 0, 100);
                lblStepInfo.Text = $"[{p.PercentComplete}%] {p.CurrentStep}";
                lblStats.Text = $"Đã xử lý: {p.ProcessedTransactions:N0} / {p.TotalTransactions:N0} giao dịch | Phát hiện lệch: {p.DiscrepanciesFound}";
                parentMain?.UpdateReconciliationProgress(
                    p.PercentComplete,
                    $"Đối soát ATM: {p.PercentComplete}% ({p.ProcessedTransactions:N0}/{p.TotalTransactions:N0} GD)");
            });

            try
            {
                var result = await _reconciliationBus.RunAutoReconciliationAsync(operatorName, progress, _cts.Token);

                if (IsDisposed || Disposing)
                {
                    return;
                }

                lblStepInfo.Text = $"Hoàn tất đối soát phiên {result.SessionId}!";
                parentMain?.UpdateReconciliationProgress(100, $"Đối soát hoàn tất ({result.TotalTransactions:N0} GD, {result.DiscrepancyCount} lệch)");
                LoadHistory();

                MessageBox.Show(
                    $"Đối soát giao dịch ATM hoàn tất!\n" +
                    $"- Mã phiên: {result.SessionId}\n" +
                    $"- Tổng số giao dịch: {result.TotalTransactions:N0}\n" +
                    $"- Giao dịch khớp: {result.MatchedCount:N0}\n" +
                    $"- Giao dịch lệch: {result.DiscrepancyCount:N0}",
                    "Kết quả đối soát cuối ngày",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                if (!IsDisposed && !Disposing)
                {
                    lblStepInfo.Text = "Tiến trình đối soát đã bị dừng theo yêu cầu người dùng.";
                    LoadHistory();
                }
                parentMain?.UpdateReconciliationProgress(0, "Đối soát đã dừng");
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing)
                {
                    lblStepInfo.Text = $"Lỗi đối soát: {ex.Message}";
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                parentMain?.UpdateReconciliationProgress(0, "Lỗi khi chạy đối soát");
            }
            finally
            {
                _cts?.Dispose();
                _cts = null;
                if (!IsDisposed && !Disposing)
                {
                    btnStartReconciliation.Enabled = true;
                    btnStopReconciliation.Enabled = false;
                }
            }
        }

        private void BtnStopReconciliation_Click(object? sender, EventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                lblStepInfo.Text = "Đang gửi tín hiệu dừng tiến trình đối soát...";
                btnStopReconciliation.Enabled = false;
                _cts.Cancel();
            }
        }

        private void FrmAtmReconciliation_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
            GetParentMainForm()?.UpdateReconciliationProgress(0, "Sẵn sàng");
        }
    }
}
