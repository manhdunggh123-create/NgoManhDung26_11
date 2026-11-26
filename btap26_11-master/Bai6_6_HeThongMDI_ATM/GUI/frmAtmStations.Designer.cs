namespace AtmManagement.GUI
{
    partial class frmAtmStations
    {
        private System.ComponentModel.IContainer components = null!;

        private TableLayoutPanel tlpTop = null!;
        private Label lblTitle = null!;
        private Label lblSearch = null!;
        private TextBox txtSearch = null!;
        private Button btnSearch = null!;
        private Button btnRefresh = null!;

        private TableLayoutPanel tlpBody = null!;
        private GroupBox grpList = null!;
        private DataGridView dgvStations = null!;

        private GroupBox grpDetails = null!;
        private Panel pnlDetailsScroll = null!;
        private TableLayoutPanel tlpDetails = null!;
        private Label lblCode = null!;
        private TextBox txtStationCode = null!;
        private Label lblAddress = null!;
        private TextBox txtLocationAddress = null!;
        private Label lblBalance = null!;
        private NumericUpDown numCashBalance = null!;
        private Label lblStatus = null!;
        private ComboBox cboStatus = null!;
        private TableLayoutPanel tlpPhotoHeader = null!;
        private Label lblPhoto = null!;
        private Button btnBrowsePhoto = null!;
        private PictureBox picStationPhoto = null!;
        private Label lblPhotoPath = null!;
        private TableLayoutPanel tlpActions = null!;
        private Button btnAdd = null!;
        private Button btnUpdate = null!;
        private Button btnDelete = null!;
        private Button btnClear = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (picStationPhoto?.Image != null)
                {
                    var img = picStationPhoto.Image;
                    picStationPhoto.Image = null;
                    img.Dispose();
                }
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tlpTop = new TableLayoutPanel();
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();

            tlpBody = new TableLayoutPanel();
            grpList = new GroupBox();
            dgvStations = new DataGridView();

            grpDetails = new GroupBox();
            pnlDetailsScroll = new Panel();
            tlpDetails = new TableLayoutPanel();
            lblCode = new Label();
            txtStationCode = new TextBox();
            lblAddress = new Label();
            txtLocationAddress = new TextBox();
            lblBalance = new Label();
            numCashBalance = new NumericUpDown();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            tlpPhotoHeader = new TableLayoutPanel();
            lblPhoto = new Label();
            btnBrowsePhoto = new Button();
            picStationPhoto = new PictureBox();
            lblPhotoPath = new Label();
            tlpActions = new TableLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            tlpTop.SuspendLayout();
            tlpBody.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStations).BeginInit();
            grpDetails.SuspendLayout();
            pnlDetailsScroll.SuspendLayout();
            tlpDetails.SuspendLayout();
            tlpPhotoHeader.SuspendLayout();
            tlpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCashBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStationPhoto).BeginInit();
            SuspendLayout();

            // tlpTop
            tlpTop.AutoSize = true;
            tlpTop.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpTop.ColumnCount = 4;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpTop.Dock = DockStyle.Top;
            tlpTop.Padding = new Padding(10, 8, 10, 6);
            tlpTop.RowCount = 2;
            tlpTop.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpTop.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Margin = new Padding(0, 0, 0, 6);
            lblTitle.Text = "QUẢN LÝ DANH SÁCH TRẠM ATM & TỒN QUỸ";
            lblTitle.UseMnemonic = false;
            tlpTop.Controls.Add(lblTitle, 0, 0);
            tlpTop.SetColumnSpan(lblTitle, 4);

            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            lblSearch.Margin = new Padding(0, 4, 8, 2);
            lblSearch.Text = "Tìm kiếm:";
            tlpTop.Controls.Add(lblSearch, 0, 1);

            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Margin = new Padding(0, 2, 8, 2);
            txtSearch.PlaceholderText = "Nhập mã trạm, địa chỉ đặt máy hoặc trạng thái...";
            txtSearch.KeyDown += TxtSearch_KeyDown;
            tlpTop.Controls.Add(txtSearch, 1, 1);

            btnSearch.AutoSize = true;
            btnSearch.Margin = new Padding(0, 0, 6, 0);
            btnSearch.MinimumSize = new Size(92, 28);
            btnSearch.Padding = new Padding(8, 0, 8, 0);
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += BtnSearch_Click;
            tlpTop.Controls.Add(btnSearch, 2, 1);

            btnRefresh.AutoSize = true;
            btnRefresh.Margin = new Padding(0);
            btnRefresh.MinimumSize = new Size(92, 28);
            btnRefresh.Padding = new Padding(8, 0, 8, 0);
            btnRefresh.Text = "Làm mới";
            btnRefresh.Click += BtnRefresh_Click;
            tlpTop.Controls.Add(btnRefresh, 3, 1);

            // tlpBody
            tlpBody.ColumnCount = 2;
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpBody.Dock = DockStyle.Fill;
            tlpBody.Padding = new Padding(10, 4, 10, 10);
            tlpBody.RowCount = 1;
            tlpBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // grpList
            grpList.Dock = DockStyle.Fill;
            grpList.Margin = new Padding(0, 0, 6, 0);
            grpList.Padding = new Padding(8);
            grpList.Text = "Danh sách Trạm ATM";

            dgvStations.AllowUserToAddRows = false;
            dgvStations.AllowUserToDeleteRows = false;
            dgvStations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStations.Dock = DockStyle.Fill;
            dgvStations.MultiSelect = false;
            dgvStations.ReadOnly = true;
            dgvStations.RowHeadersVisible = false;
            dgvStations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStations.SelectionChanged += DgvStations_SelectionChanged;
            grpList.Controls.Add(dgvStations);
            tlpBody.Controls.Add(grpList, 0, 0);

            // grpDetails
            grpDetails.Dock = DockStyle.Fill;
            grpDetails.Margin = new Padding(6, 0, 0, 0);
            grpDetails.Padding = new Padding(8);
            grpDetails.Text = "Thông tin chi tiết Trạm ATM";

            pnlDetailsScroll.AutoScroll = true;
            pnlDetailsScroll.Dock = DockStyle.Fill;
            grpDetails.Controls.Add(pnlDetailsScroll);

            tlpDetails.AutoSize = true;
            tlpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpDetails.ColumnCount = 1;
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDetails.Dock = DockStyle.Top;
            tlpDetails.Padding = new Padding(2, 2, 6, 4);
            tlpDetails.RowCount = 12;
            for (int i = 0; i < 12; i++)
            {
                tlpDetails.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            lblCode.AutoSize = true;
            lblCode.Margin = new Padding(0, 0, 0, 2);
            lblCode.Text = "Mã trạm ATM:";
            tlpDetails.Controls.Add(lblCode, 0, 0);

            txtStationCode.Dock = DockStyle.Fill;
            txtStationCode.Margin = new Padding(0, 0, 0, 4);
            tlpDetails.Controls.Add(txtStationCode, 0, 1);

            lblAddress.AutoSize = true;
            lblAddress.Margin = new Padding(0, 2, 0, 2);
            lblAddress.Text = "Địa chỉ đặt máy:";
            tlpDetails.Controls.Add(lblAddress, 0, 2);

            txtLocationAddress.Dock = DockStyle.Fill;
            txtLocationAddress.Margin = new Padding(0, 0, 0, 4);
            tlpDetails.Controls.Add(txtLocationAddress, 0, 3);

            lblBalance.AutoSize = true;
            lblBalance.Margin = new Padding(0, 2, 0, 2);
            lblBalance.Text = "Số tiền tồn quỹ hiện tại (VNĐ):";
            tlpDetails.Controls.Add(lblBalance, 0, 4);

            numCashBalance.Dock = DockStyle.Fill;
            numCashBalance.Increment = 10_000_000m;
            numCashBalance.Margin = new Padding(0, 0, 0, 4);
            numCashBalance.Maximum = 10_000_000_000m;
            numCashBalance.ThousandsSeparator = true;
            tlpDetails.Controls.Add(numCashBalance, 0, 5);

            lblStatus.AutoSize = true;
            lblStatus.Margin = new Padding(0, 2, 0, 2);
            lblStatus.Text = "Trạng thái hoạt động:";
            tlpDetails.Controls.Add(lblStatus, 0, 6);

            cboStatus.Dock = DockStyle.Fill;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[]
            {
                "Hoạt động",
                "Cảnh báo tồn quỹ thấp",
                "Bảo trì",
                "Ngưng hoạt động"
            });
            cboStatus.Margin = new Padding(0, 0, 0, 6);
            tlpDetails.Controls.Add(cboStatus, 0, 7);

            // Photo header (Label + Button side-by-side without overlap)
            tlpPhotoHeader.AutoSize = true;
            tlpPhotoHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpPhotoHeader.ColumnCount = 2;
            tlpPhotoHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPhotoHeader.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpPhotoHeader.Dock = DockStyle.Fill;
            tlpPhotoHeader.Margin = new Padding(0, 0, 0, 2);
            tlpPhotoHeader.RowCount = 1;
            tlpPhotoHeader.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblPhoto.Anchor = AnchorStyles.Left;
            lblPhoto.AutoSize = true;
            lblPhoto.Margin = new Padding(0, 4, 8, 0);
            lblPhoto.Text = "Ảnh hiện trường trạm ATM:";
            tlpPhotoHeader.Controls.Add(lblPhoto, 0, 0);

            btnBrowsePhoto.Anchor = AnchorStyles.Right;
            btnBrowsePhoto.AutoSize = true;
            btnBrowsePhoto.Margin = new Padding(0);
            btnBrowsePhoto.MinimumSize = new Size(96, 26);
            btnBrowsePhoto.Padding = new Padding(8, 0, 8, 0);
            btnBrowsePhoto.Text = "Chọn ảnh...";
            btnBrowsePhoto.Click += BtnBrowsePhoto_Click;
            tlpPhotoHeader.Controls.Add(btnBrowsePhoto, 1, 0);
            tlpDetails.Controls.Add(tlpPhotoHeader, 0, 8);

            picStationPhoto.BorderStyle = BorderStyle.FixedSingle;
            picStationPhoto.Dock = DockStyle.Fill;
            picStationPhoto.Height = 110;
            picStationPhoto.Margin = new Padding(0, 2, 0, 2);
            picStationPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            tlpDetails.Controls.Add(picStationPhoto, 0, 9);

            lblPhotoPath.AutoEllipsis = true;
            lblPhotoPath.Dock = DockStyle.Fill;
            lblPhotoPath.MinimumSize = new Size(0, 22);
            lblPhotoPath.Height = 22;
            lblPhotoPath.Margin = new Padding(0, 0, 0, 6);
            lblPhotoPath.Text = "(Chưa đính kèm ảnh hiện trường)";
            tlpDetails.Controls.Add(lblPhotoPath, 0, 10);

            // Action buttons (2x2 balanced grid so no text ever clips)
            tlpActions.AutoSize = true;
            tlpActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpActions.ColumnCount = 2;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpActions.Dock = DockStyle.Fill;
            tlpActions.Margin = new Padding(0);
            tlpActions.RowCount = 2;
            tlpActions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpActions.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Height = 30;
            btnAdd.Margin = new Padding(0, 0, 4, 4);
            btnAdd.Text = "Thêm";
            btnAdd.Click += BtnAdd_Click;
            tlpActions.Controls.Add(btnAdd, 0, 0);

            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.Height = 30;
            btnUpdate.Margin = new Padding(4, 0, 0, 4);
            btnUpdate.Text = "Sửa";
            btnUpdate.Click += BtnUpdate_Click;
            tlpActions.Controls.Add(btnUpdate, 1, 0);

            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Height = 30;
            btnDelete.Margin = new Padding(0, 0, 4, 0);
            btnDelete.Text = "Xóa";
            btnDelete.Click += BtnDelete_Click;
            tlpActions.Controls.Add(btnDelete, 0, 1);

            btnClear.Dock = DockStyle.Fill;
            btnClear.Height = 30;
            btnClear.Margin = new Padding(4, 0, 0, 0);
            btnClear.Text = "Nhập mới";
            btnClear.Click += BtnClear_Click;
            tlpActions.Controls.Add(btnClear, 1, 1);

            tlpDetails.Controls.Add(tlpActions, 0, 11);
            pnlDetailsScroll.Controls.Add(tlpDetails);
            tlpBody.Controls.Add(grpDetails, 1, 0);

            // frmAtmStations
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 620);
            Controls.Add(tlpBody);
            Controls.Add(tlpTop);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(440, 340);
            Name = "frmAtmStations";
            Text = "Danh sách Trạm ATM & Tồn quỹ";
            Load += FrmAtmStations_Load;

            tlpTop.ResumeLayout(false);
            tlpTop.PerformLayout();
            tlpBody.ResumeLayout(false);
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStations).EndInit();
            grpDetails.ResumeLayout(false);
            pnlDetailsScroll.ResumeLayout(false);
            pnlDetailsScroll.PerformLayout();
            tlpDetails.ResumeLayout(false);
            tlpDetails.PerformLayout();
            tlpPhotoHeader.ResumeLayout(false);
            tlpPhotoHeader.PerformLayout();
            tlpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numCashBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStationPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
