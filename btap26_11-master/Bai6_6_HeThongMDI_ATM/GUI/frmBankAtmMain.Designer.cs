namespace AtmManagement.GUI
{
    partial class frmBankAtmMain
    {
        private System.ComponentModel.IContainer components = null!;

        private MenuStrip menuStripMain = null!;
        private ToolStripMenuItem mnuHeThong = null!;
        private ToolStripMenuItem mnuDangXuat = null!;
        private ToolStripMenuItem mnuKhoaManHinh = null!;
        private ToolStripSeparator mnuSep1 = null!;
        private ToolStripMenuItem mnuThoat = null!;

        private ToolStripMenuItem mnuQuanLyAtm = null!;
        private ToolStripMenuItem mnuDanhSachAtm = null!;
        private ToolStripMenuItem mnuDoiSoatCuoiNgay = null!;

        private ToolStripMenuItem mnuCuaSo = null!;
        private ToolStripMenuItem mnuXepTang = null!;
        private ToolStripMenuItem mnuXepNgang = null!;
        private ToolStripMenuItem mnuXepDoc = null!;
        private ToolStripSeparator mnuSep2 = null!;
        private ToolStripMenuItem mnuDongTatCa = null!;

        private StatusStrip statusStripMain = null!;
        private ToolStripStatusLabel lblTellerName = null!;
        private ToolStripStatusLabel lblCoreBankingStatus = null!;
        private ToolStripStatusLabel lblProgressStatus = null!;
        private ToolStripProgressBar prgReconciliation = null!;

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
            menuStripMain = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuKhoaManHinh = new ToolStripMenuItem();
            mnuSep1 = new ToolStripSeparator();
            mnuThoat = new ToolStripMenuItem();

            mnuQuanLyAtm = new ToolStripMenuItem();
            mnuDanhSachAtm = new ToolStripMenuItem();
            mnuDoiSoatCuoiNgay = new ToolStripMenuItem();

            mnuCuaSo = new ToolStripMenuItem();
            mnuXepTang = new ToolStripMenuItem();
            mnuXepNgang = new ToolStripMenuItem();
            mnuXepDoc = new ToolStripMenuItem();
            mnuSep2 = new ToolStripSeparator();
            mnuDongTatCa = new ToolStripMenuItem();

            statusStripMain = new StatusStrip();
            lblTellerName = new ToolStripStatusLabel();
            lblCoreBankingStatus = new ToolStripStatusLabel();
            lblProgressStatus = new ToolStripStatusLabel();
            prgReconciliation = new ToolStripProgressBar();

            menuStripMain.SuspendLayout();
            statusStripMain.SuspendLayout();
            SuspendLayout();

            // menuStripMain
            menuStripMain.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            menuStripMain.Items.AddRange(new ToolStripItem[]
            {
                mnuHeThong,
                mnuQuanLyAtm,
                mnuCuaSo
            });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1280, 28);
            menuStripMain.MdiWindowListItem = mnuCuaSo;

            // Hệ thống
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Text = "Hệ thống";
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[]
            {
                mnuDangXuat,
                mnuKhoaManHinh,
                mnuSep1,
                mnuThoat
            });

            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += MnuDangXuat_Click;

            mnuKhoaManHinh.Name = "mnuKhoaManHinh";
            mnuKhoaManHinh.Text = "Khóa màn hình";
            mnuKhoaManHinh.ShortcutKeys = Keys.Control | Keys.L;
            mnuKhoaManHinh.Click += MnuKhoaManHinh_Click;

            mnuThoat.Name = "mnuThoat";
            mnuThoat.Text = "Thoát";
            mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuThoat.Click += MnuThoat_Click;

            // Quản lý ATM
            mnuQuanLyAtm.Name = "mnuQuanLyAtm";
            mnuQuanLyAtm.Text = "Quản lý ATM";
            mnuQuanLyAtm.DropDownItems.AddRange(new ToolStripItem[]
            {
                mnuDanhSachAtm,
                mnuDoiSoatCuoiNgay
            });

            mnuDanhSachAtm.Name = "mnuDanhSachAtm";
            mnuDanhSachAtm.Text = "Danh sách Trạm ATM && Tồn quỹ";
            mnuDanhSachAtm.ShortcutKeys = Keys.Control | Keys.D1;
            mnuDanhSachAtm.Click += MnuDanhSachAtm_Click;

            mnuDoiSoatCuoiNgay.Name = "mnuDoiSoatCuoiNgay";
            mnuDoiSoatCuoiNgay.Text = "Đối soát Giao dịch Cuối ngày";
            mnuDoiSoatCuoiNgay.ShortcutKeys = Keys.Control | Keys.D2;
            mnuDoiSoatCuoiNgay.Click += MnuDoiSoatCuoiNgay_Click;

            // Cửa sổ
            mnuCuaSo.Name = "mnuCuaSo";
            mnuCuaSo.Text = "Cửa sổ";
            mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[]
            {
                mnuXepTang,
                mnuXepNgang,
                mnuXepDoc,
                mnuSep2,
                mnuDongTatCa
            });

            mnuXepTang.Name = "mnuXepTang";
            mnuXepTang.Text = "Xếp tầng (Cascade)";
            mnuXepTang.Click += MnuXepTang_Click;

            mnuXepNgang.Name = "mnuXepNgang";
            mnuXepNgang.Text = "Xếp ngang (Tile Horizontal)";
            mnuXepNgang.Click += MnuXepNgang_Click;

            mnuXepDoc.Name = "mnuXepDoc";
            mnuXepDoc.Text = "Xếp dọc (Tile Vertical)";
            mnuXepDoc.Click += MnuXepDoc_Click;

            mnuDongTatCa.Name = "mnuDongTatCa";
            mnuDongTatCa.Text = "Đóng tất cả";
            mnuDongTatCa.Click += MnuDongTatCa_Click;

            // statusStripMain
            statusStripMain.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            statusStripMain.Items.AddRange(new ToolStripItem[]
            {
                lblTellerName,
                lblCoreBankingStatus,
                lblProgressStatus,
                prgReconciliation
            });
            statusStripMain.Location = new Point(0, 695);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1280, 25);

            lblTellerName.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblTellerName.Name = "lblTellerName";
            lblTellerName.Text = "Giao dịch viên trực: Đỗ Việt Hoàng (MSV: 24810310199)";

            lblCoreBankingStatus.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblCoreBankingStatus.Name = "lblCoreBankingStatus";
            lblCoreBankingStatus.Text = "Core Banking: Đã kết nối (Online)";

            lblProgressStatus.Name = "lblProgressStatus";
            lblProgressStatus.Spring = true;
            lblProgressStatus.TextAlign = ContentAlignment.MiddleRight;
            lblProgressStatus.Text = "Sẵn sàng";

            prgReconciliation.Maximum = 100;
            prgReconciliation.Minimum = 0;
            prgReconciliation.Name = "prgReconciliation";
            prgReconciliation.Size = new Size(200, 18);
            prgReconciliation.Style = ProgressBarStyle.Continuous;
            prgReconciliation.Value = 0;

            // frmBankAtmMain
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(statusStripMain);
            Controls.Add(menuStripMain);
            IsMdiContainer = true;
            MainMenuStrip = menuStripMain;
            MinimumSize = new Size(900, 600);
            Name = "frmBankAtmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống MDI Điều hành Mạng lưới Cây ATM Ngân hàng - Đỗ Việt Hoàng (24810310199)";
            WindowState = FormWindowState.Maximized;

            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
