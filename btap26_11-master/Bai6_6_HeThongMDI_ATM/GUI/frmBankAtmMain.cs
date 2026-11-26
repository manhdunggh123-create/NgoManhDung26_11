namespace AtmManagement.GUI
{
    public partial class frmBankAtmMain : Form
    {
        public string CurrentTellerName { get; private set; } = "Đỗ Việt Hoàng";

        public frmBankAtmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Điều hướng MDI chuẩn mực: duyệt this.MdiChildren để chống mở trùng lặp Form con.
        /// Nếu đã tồn tại -> Activate(); nếu chưa -> khởi tạo, gán MdiParent = this và Show().
        /// </summary>
        private T OpenOrActivateChild<T>() where T : Form, new()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T existingForm)
                {
                    if (existingForm.WindowState == FormWindowState.Minimized)
                    {
                        existingForm.WindowState = FormWindowState.Normal;
                    }
                    existingForm.Activate();
                    return existingForm;
                }
            }

            var newForm = new T
            {
                MdiParent = this
            };
            newForm.Show();
            return newForm;
        }

        /// <summary>
        /// Cho phép Form con cập nhật tiến độ đối soát lên ToolStripProgressBar của Form Cha MDI an toàn.
        /// </summary>
        public void UpdateReconciliationProgress(int percent, string statusText)
        {
            if (IsDisposed || Disposing || !IsHandleCreated)
            {
                return;
            }

            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action(() => UpdateReconciliationProgress(percent, statusText)));
                }
                catch (ObjectDisposedException)
                {
                }
                catch (InvalidOperationException)
                {
                }
                return;
            }

            prgReconciliation.Value = Math.Clamp(percent, prgReconciliation.Minimum, prgReconciliation.Maximum);
            lblProgressStatus.Text = statusText;
        }

        private void MnuDanhSachAtm_Click(object? sender, EventArgs e)
        {
            OpenOrActivateChild<frmAtmStations>();
        }

        private void MnuDoiSoatCuoiNgay_Click(object? sender, EventArgs e)
        {
            OpenOrActivateChild<frmAtmReconciliation>();
        }

        private void MnuXepTang_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void MnuXepNgang_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MnuXepDoc_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MnuDongTatCa_Click(object? sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren.ToArray())
            {
                child.Close();
            }
        }

        private void MnuKhoaManHinh_Click(object? sender, EventArgs e)
        {
            lblCoreBankingStatus.Text = "Core Banking: Phiên làm việc đang tạm khóa";

            MessageBox.Show(
                "Màn hình điều hành đã được khóa để bảo mật.\nNhấn OK để mở khóa và tiếp tục ca trực.",
                "Khóa màn hình - ATM Center",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            lblCoreBankingStatus.Text = "Core Banking: Đã kết nối (Online)";
        }

        private void MnuDangXuat_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất phiên làm việc hiện tại?\nTất cả cửa sổ nghiệp vụ đang mở sẽ được đóng lại.",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                MnuDongTatCa_Click(sender, e);
                lblTellerName.Text = "Giao dịch viên trực: (Chưa đăng nhập)";
                lblCoreBankingStatus.Text = "Core Banking: Đã ngắt kết nối";

                var relogin = MessageBox.Show(
                    "Đã đăng xuất thành công.\nNhấn Yes để đăng nhập lại với tài khoản Đỗ Việt Hoàng, hoặc No để thoát.",
                    "Đăng xuất hoàn tất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (relogin == DialogResult.Yes)
                {
                    lblTellerName.Text = "Giao dịch viên trực: Đỗ Việt Hoàng (MSV: 24810310199)";
                    lblCoreBankingStatus.Text = "Core Banking: Đã kết nối (Online)";
                }
                else
                {
                    Close();
                }
            }
        }

        private void MnuThoat_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát Hệ thống Điều hành ATM?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
