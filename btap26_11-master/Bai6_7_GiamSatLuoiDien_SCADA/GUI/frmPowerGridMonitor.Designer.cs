namespace PowerGridScada.GUI
{
    partial class frmPowerGridMonitor
    {
        private System.ComponentModel.IContainer components = null!;

        private TableLayoutPanel tlpMain = null!;

        private TableLayoutPanel tlpHeader = null!;
        private Label lblAppTitle = null!;
        private Label lblStudentInfo = null!;

        private GroupBox grpControl = null!;
        private TableLayoutPanel tlpControl = null!;
        private Label lblSubstation = null!;
        private ComboBox cboSubstation = null!;
        private Button btnStartScada = null!;
        private Button btnStopScada = null!;
        private Button btnClearLogs = null!;

        private GroupBox grpDashboard = null!;
        private TableLayoutPanel tlpDashboard = null!;

        private GroupBox grpVoltage = null!;
        private TableLayoutPanel tlpVoltage = null!;
        private Label lblVoltage = null!;
        private Label lblVoltageRange = null!;

        private GroupBox grpLoad = null!;
        private TableLayoutPanel tlpLoad = null!;
        private Label lblLoadPercent = null!;
        private Label lblAlertBanner = null!;
        private ProgressBar prgLoadMeter = null!;

        private GroupBox grpLogs = null!;
        private DataGridView dgvGridLogs = null!;

        private StatusStrip statusStripScada = null!;
        private ToolStripStatusLabel lblConnectionState = null!;
        private ToolStripStatusLabel lblLastPacketTime = null!;
        private ToolStripStatusLabel lblTotalCycles = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tlpMain = new TableLayoutPanel();
            tlpHeader = new TableLayoutPanel();
            lblAppTitle = new Label();
            lblStudentInfo = new Label();
            grpControl = new GroupBox();
            tlpControl = new TableLayoutPanel();
            lblSubstation = new Label();
            cboSubstation = new ComboBox();
            btnStartScada = new Button();
            btnStopScada = new Button();
            btnClearLogs = new Button();
            grpDashboard = new GroupBox();
            tlpDashboard = new TableLayoutPanel();
            grpVoltage = new GroupBox();
            tlpVoltage = new TableLayoutPanel();
            lblVoltage = new Label();
            lblVoltageRange = new Label();
            grpLoad = new GroupBox();
            tlpLoad = new TableLayoutPanel();
            lblLoadPercent = new Label();
            lblAlertBanner = new Label();
            prgLoadMeter = new ProgressBar();
            grpLogs = new GroupBox();
            dgvGridLogs = new DataGridView();
            statusStripScada = new StatusStrip();
            lblConnectionState = new ToolStripStatusLabel();
            lblLastPacketTime = new ToolStripStatusLabel();
            lblTotalCycles = new ToolStripStatusLabel();

            tlpMain.SuspendLayout();
            tlpHeader.SuspendLayout();
            grpControl.SuspendLayout();
            tlpControl.SuspendLayout();
            grpDashboard.SuspendLayout();
            tlpDashboard.SuspendLayout();
            grpVoltage.SuspendLayout();
            tlpVoltage.SuspendLayout();
            grpLoad.SuspendLayout();
            tlpLoad.SuspendLayout();
            grpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGridLogs).BeginInit();
            statusStripScada.SuspendLayout();
            SuspendLayout();

            // tlpMain
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Padding = new Padding(10, 8, 10, 8);
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // tlpHeader
            tlpHeader.AutoSize = true;
            tlpHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpHeader.ColumnCount = 1;
            tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpHeader.Dock = DockStyle.Fill;
            tlpHeader.Margin = new Padding(0, 0, 0, 8);
            tlpHeader.RowCount = 2;
            tlpHeader.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpHeader.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAppTitle.Margin = new Padding(0, 0, 0, 2);
            lblAppTitle.Text = "TRUNG TÂM ĐIỀU ĐỘ & GIÁM SÁT LƯỚI ĐIỆN THỜI GIAN THỰC (SCADA)";
            lblAppTitle.UseMnemonic = false;
            tlpHeader.Controls.Add(lblAppTitle, 0, 0);

            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 9F);
            lblStudentInfo.Margin = new Padding(0);
            lblStudentInfo.Text = "Sinh viên: Đỗ Việt Hoàng - MSV: 24810310199 | Cross-Thread Safety (InvokeRequired / Invoke)";
            tlpHeader.Controls.Add(lblStudentInfo, 0, 1);

            tlpMain.Controls.Add(tlpHeader, 0, 0);

            // grpControl
            grpControl.AutoSize = true;
            grpControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpControl.Dock = DockStyle.Fill;
            grpControl.Margin = new Padding(0, 0, 0, 8);
            grpControl.Padding = new Padding(10, 6, 10, 8);
            grpControl.Text = "Khu vực điều khiển kết nối SCADA";

            tlpControl.AutoSize = true;
            tlpControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpControl.ColumnCount = 5;
            tlpControl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpControl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpControl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpControl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpControl.Dock = DockStyle.Fill;
            tlpControl.RowCount = 1;
            tlpControl.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblSubstation.Anchor = AnchorStyles.Left;
            lblSubstation.AutoSize = true;
            lblSubstation.Margin = new Padding(0, 4, 8, 4);
            lblSubstation.Text = "Trạm biến áp:";
            tlpControl.Controls.Add(lblSubstation, 0, 0);

            cboSubstation.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboSubstation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubstation.Margin = new Padding(0, 3, 10, 3);
            tlpControl.Controls.Add(cboSubstation, 1, 0);

            btnStartScada.AutoSize = true;
            btnStartScada.Margin = new Padding(0, 0, 8, 0);
            btnStartScada.MinimumSize = new Size(185, 32);
            btnStartScada.Padding = new Padding(8, 2, 8, 2);
            btnStartScada.Text = "Bắt đầu Giám sát SCADA";
            btnStartScada.Click += BtnStartScada_Click;
            tlpControl.Controls.Add(btnStartScada, 2, 0);

            btnStopScada.AutoSize = true;
            btnStopScada.Enabled = false;
            btnStopScada.Margin = new Padding(0, 0, 8, 0);
            btnStopScada.MinimumSize = new Size(125, 32);
            btnStopScada.Padding = new Padding(8, 2, 8, 2);
            btnStopScada.Text = "Ngắt Kết nối";
            btnStopScada.Click += BtnStopScada_Click;
            tlpControl.Controls.Add(btnStopScada, 3, 0);

            btnClearLogs.AutoSize = true;
            btnClearLogs.Margin = new Padding(0);
            btnClearLogs.MinimumSize = new Size(110, 32);
            btnClearLogs.Padding = new Padding(8, 2, 8, 2);
            btnClearLogs.Text = "Xóa nhật ký";
            btnClearLogs.Click += BtnClearLogs_Click;
            tlpControl.Controls.Add(btnClearLogs, 4, 0);

            grpControl.Controls.Add(tlpControl);
            tlpMain.Controls.Add(grpControl, 0, 1);

            // grpDashboard
            grpDashboard.AutoSize = true;
            grpDashboard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpDashboard.Dock = DockStyle.Fill;
            grpDashboard.Margin = new Padding(0, 0, 0, 8);
            grpDashboard.Padding = new Padding(10, 6, 10, 10);
            grpDashboard.Text = "Bảng thông số vận hành trực quan (Real-time Dashboard)";

            tlpDashboard.AutoSize = true;
            tlpDashboard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpDashboard.ColumnCount = 2;
            tlpDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDashboard.Dock = DockStyle.Fill;
            tlpDashboard.RowCount = 1;
            tlpDashboard.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Voltage box
            grpVoltage.AutoSize = true;
            grpVoltage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpVoltage.Dock = DockStyle.Fill;
            grpVoltage.Margin = new Padding(0, 0, 6, 0);
            grpVoltage.Padding = new Padding(10, 6, 10, 10);
            grpVoltage.Text = "Điện áp hiện tại (kV)";

            tlpVoltage.AutoSize = true;
            tlpVoltage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpVoltage.ColumnCount = 1;
            tlpVoltage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpVoltage.Dock = DockStyle.Fill;
            tlpVoltage.RowCount = 2;
            tlpVoltage.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpVoltage.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblVoltage.AutoSize = true;
            lblVoltage.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblVoltage.Margin = new Padding(0, 4, 0, 8);
            lblVoltage.Text = "--- kV";
            tlpVoltage.Controls.Add(lblVoltage, 0, 0);

            lblVoltageRange.AutoSize = true;
            lblVoltageRange.Margin = new Padding(0);
            lblVoltageRange.Text = "Dải vận hành chuẩn: 108.0 kV – 115.0 kV | Chu kỳ quét: 2 giây";
            tlpVoltage.Controls.Add(lblVoltageRange, 0, 1);

            grpVoltage.Controls.Add(tlpVoltage);
            tlpDashboard.Controls.Add(grpVoltage, 0, 0);

            // Load box
            grpLoad.AutoSize = true;
            grpLoad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpLoad.Dock = DockStyle.Fill;
            grpLoad.Margin = new Padding(6, 0, 0, 0);
            grpLoad.Padding = new Padding(10, 6, 10, 10);
            grpLoad.Text = "Mức mang tải (%) — Ngưỡng an toàn <= 85%";

            tlpLoad.AutoSize = true;
            tlpLoad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpLoad.ColumnCount = 1;
            tlpLoad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpLoad.Dock = DockStyle.Fill;
            tlpLoad.RowCount = 3;
            tlpLoad.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpLoad.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpLoad.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblLoadPercent.AutoSize = true;
            lblLoadPercent.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblLoadPercent.Margin = new Padding(0, 4, 0, 4);
            lblLoadPercent.Text = "--.- %";
            tlpLoad.Controls.Add(lblLoadPercent, 0, 0);

            lblAlertBanner.AutoSize = true;
            lblAlertBanner.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAlertBanner.Margin = new Padding(0, 0, 0, 6);
            lblAlertBanner.Text = "Trạng thái: Chờ kết nối SCADA";
            tlpLoad.Controls.Add(lblAlertBanner, 0, 1);

            prgLoadMeter.Dock = DockStyle.Fill;
            prgLoadMeter.Height = 18;
            prgLoadMeter.Margin = new Padding(0);
            prgLoadMeter.Maximum = 100;
            prgLoadMeter.Minimum = 0;
            prgLoadMeter.Style = ProgressBarStyle.Continuous;
            tlpLoad.Controls.Add(prgLoadMeter, 0, 2);

            grpLoad.Controls.Add(tlpLoad);
            tlpDashboard.Controls.Add(grpLoad, 1, 0);

            grpDashboard.Controls.Add(tlpDashboard);
            tlpMain.Controls.Add(grpDashboard, 0, 2);

            // grpLogs
            grpLogs.Dock = DockStyle.Fill;
            grpLogs.Margin = new Padding(0);
            grpLogs.Padding = new Padding(8);
            grpLogs.Text = "Nhật ký sự cố Quá tải lưới điện (Tự động ghi nhận khi Mức tải > 85%)";

            dgvGridLogs.AllowUserToAddRows = false;
            dgvGridLogs.AllowUserToDeleteRows = false;
            dgvGridLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGridLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGridLogs.Dock = DockStyle.Fill;
            dgvGridLogs.ReadOnly = true;
            dgvGridLogs.RowHeadersVisible = false;
            dgvGridLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grpLogs.Controls.Add(dgvGridLogs);

            tlpMain.Controls.Add(grpLogs, 0, 3);

            // statusStripScada
            statusStripScada.Font = new Font("Segoe UI", 9F);
            statusStripScada.Items.AddRange(new ToolStripItem[]
            {
                lblConnectionState,
                lblLastPacketTime,
                lblTotalCycles
            });

            lblConnectionState.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblConnectionState.Text = "SCADA: Đã ngắt kết nối";

            lblLastPacketTime.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblLastPacketTime.Text = "Gói tin cuối cùng: --:--:--";

            lblTotalCycles.Spring = true;
            lblTotalCycles.TextAlign = ContentAlignment.MiddleRight;
            lblTotalCycles.Text = "Tổng số chu kỳ đã quét: 0";

            // frmPowerGridMonitor
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 680);
            Controls.Add(tlpMain);
            Controls.Add(statusStripScada);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(800, 560);
            Name = "frmPowerGridMonitor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SCADA - Trung tâm Điều độ & Giám sát Lưới điện Thời gian thực - Đỗ Việt Hoàng (24810310199)";
            Load += FrmPowerGridMonitor_Load;
            FormClosing += FrmPowerGridMonitor_FormClosing;

            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            tlpHeader.ResumeLayout(false);
            tlpHeader.PerformLayout();
            grpControl.ResumeLayout(false);
            grpControl.PerformLayout();
            tlpControl.ResumeLayout(false);
            tlpControl.PerformLayout();
            grpDashboard.ResumeLayout(false);
            grpDashboard.PerformLayout();
            tlpDashboard.ResumeLayout(false);
            tlpDashboard.PerformLayout();
            grpVoltage.ResumeLayout(false);
            grpVoltage.PerformLayout();
            tlpVoltage.ResumeLayout(false);
            tlpVoltage.PerformLayout();
            grpLoad.ResumeLayout(false);
            grpLoad.PerformLayout();
            tlpLoad.ResumeLayout(false);
            tlpLoad.PerformLayout();
            grpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGridLogs).EndInit();
            statusStripScada.ResumeLayout(false);
            statusStripScada.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
