namespace AtmManagement.GUI
{
    partial class frmAtmReconciliation
    {
        private System.ComponentModel.IContainer components = null!;

        private TableLayoutPanel tlpMain = null!;
        private TableLayoutPanel tlpHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;

        private GroupBox grpControl = null!;
        private TableLayoutPanel tlpControl = null!;
        private FlowLayoutPanel flpButtons = null!;
        private Button btnStartReconciliation = null!;
        private Button btnStopReconciliation = null!;
        private Label lblStepInfo = null!;
        private ProgressBar prgLocal = null!;
        private Label lblStats = null!;

        private GroupBox grpHistory = null!;
        private DataGridView dgvHistory = null!;

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
            lblTitle = new Label();
            lblSubtitle = new Label();
            grpControl = new GroupBox();
            tlpControl = new TableLayoutPanel();
            flpButtons = new FlowLayoutPanel();
            btnStartReconciliation = new Button();
            btnStopReconciliation = new Button();
            lblStepInfo = new Label();
            prgLocal = new ProgressBar();
            lblStats = new Label();
            grpHistory = new GroupBox();
            dgvHistory = new DataGridView();

            tlpMain.SuspendLayout();
            tlpHeader.SuspendLayout();
            grpControl.SuspendLayout();
            tlpControl.SuspendLayout();
            flpButtons.SuspendLayout();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();

            // tlpMain
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Padding = new Padding(10);
            tlpMain.RowCount = 3;
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

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Margin = new Padding(0, 0, 0, 2);
            lblTitle.Text = "ĐỐI SOÁT GIAO DỊCH ATM CUỐI NGÀY (ASYNC / AWAIT)";
            lblTitle.UseMnemonic = false;
            tlpHeader.Controls.Add(lblTitle, 0, 0);

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.Margin = new Padding(0);
            lblSubtitle.Text = "Xử lý bất đồng bộ hàng trăm nghìn giao dịch rút tiền/chuyển khoản — Giao diện luôn tương tác mượt mà.";
            tlpHeader.Controls.Add(lblSubtitle, 0, 1);

            tlpMain.Controls.Add(tlpHeader, 0, 0);

            // grpControl
            grpControl.AutoSize = true;
            grpControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpControl.Dock = DockStyle.Fill;
            grpControl.Margin = new Padding(0, 0, 0, 10);
            grpControl.Padding = new Padding(10, 8, 10, 10);
            grpControl.Text = "Điều khiển tiến trình đối soát";

            tlpControl.AutoSize = true;
            tlpControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpControl.ColumnCount = 1;
            tlpControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpControl.Dock = DockStyle.Fill;
            tlpControl.RowCount = 4;
            tlpControl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpControl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpControl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpControl.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            flpButtons.AutoSize = true;
            flpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Margin = new Padding(0, 0, 0, 8);
            flpButtons.WrapContents = true;

            btnStartReconciliation.AutoSize = true;
            btnStartReconciliation.Margin = new Padding(0, 0, 10, 4);
            btnStartReconciliation.MinimumSize = new Size(195, 34);
            btnStartReconciliation.Padding = new Padding(12, 4, 12, 4);
            btnStartReconciliation.Text = "Chạy Đối Soát Tự Động";
            btnStartReconciliation.Click += BtnStartReconciliation_Click;
            flpButtons.Controls.Add(btnStartReconciliation);

            btnStopReconciliation.AutoSize = true;
            btnStopReconciliation.Enabled = false;
            btnStopReconciliation.Margin = new Padding(0, 0, 0, 4);
            btnStopReconciliation.MinimumSize = new Size(145, 34);
            btnStopReconciliation.Padding = new Padding(12, 4, 12, 4);
            btnStopReconciliation.Text = "Dừng Đối Soát";
            btnStopReconciliation.Click += BtnStopReconciliation_Click;
            flpButtons.Controls.Add(btnStopReconciliation);

            tlpControl.Controls.Add(flpButtons, 0, 0);

            lblStepInfo.AutoSize = true;
            lblStepInfo.Dock = DockStyle.Fill;
            lblStepInfo.Margin = new Padding(0, 2, 0, 6);
            lblStepInfo.Text = "Trạng thái: Sẵn sàng thực hiện đối soát cuối ngày.";
            tlpControl.Controls.Add(lblStepInfo, 0, 1);

            prgLocal.Dock = DockStyle.Fill;
            prgLocal.Height = 22;
            prgLocal.Margin = new Padding(0, 0, 0, 6);
            prgLocal.Maximum = 100;
            prgLocal.Minimum = 0;
            prgLocal.Style = ProgressBarStyle.Continuous;
            tlpControl.Controls.Add(prgLocal, 0, 2);

            lblStats.AutoSize = true;
            lblStats.Dock = DockStyle.Fill;
            lblStats.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStats.Margin = new Padding(0);
            lblStats.Text = "Đã xử lý: 0 / 0 giao dịch | Phát hiện lệch: 0";
            tlpControl.Controls.Add(lblStats, 0, 3);

            grpControl.Controls.Add(tlpControl);
            tlpMain.Controls.Add(grpControl, 0, 1);

            // grpHistory
            grpHistory.Dock = DockStyle.Fill;
            grpHistory.Margin = new Padding(0);
            grpHistory.Padding = new Padding(8);
            grpHistory.Text = "Lịch sử các phiên đối soát giao dịch ATM";

            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grpHistory.Controls.Add(dgvHistory);

            tlpMain.Controls.Add(grpHistory, 0, 2);

            // frmAtmReconciliation
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 560);
            Controls.Add(tlpMain);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(440, 340);
            Name = "frmAtmReconciliation";
            Text = "Đối soát Giao dịch Cuối ngày";
            Load += FrmAtmReconciliation_Load;
            FormClosing += FrmAtmReconciliation_FormClosing;

            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            tlpHeader.ResumeLayout(false);
            tlpHeader.PerformLayout();
            grpControl.ResumeLayout(false);
            grpControl.PerformLayout();
            tlpControl.ResumeLayout(false);
            tlpControl.PerformLayout();
            flpButtons.ResumeLayout(false);
            flpButtons.PerformLayout();
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }
    }
}
