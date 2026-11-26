using AtmManagement.BUS;
using AtmManagement.DTO;

namespace AtmManagement.GUI
{
    public partial class frmAtmStations : Form
    {
        private readonly AtmStationBUS _stationBus = new();
        private string? _selectedPhotoPath;

        public frmAtmStations()
        {
            InitializeComponent();
        }

        private void FrmAtmStations_Load(object? sender, EventArgs e)
        {
            ConfigureGridColumns();
            cboStatus.SelectedIndex = 0;
            LoadStations();
        }

        private void ConfigureGridColumns()
        {
            dgvStations.AutoGenerateColumns = false;
            dgvStations.Columns.Clear();

            dgvStations.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StationCode",
                DataPropertyName = "StationCode",
                HeaderText = "Mã trạm",
                FillWeight = 16,
                MinimumWidth = 85
            });

            dgvStations.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LocationAddress",
                DataPropertyName = "LocationAddress",
                HeaderText = "Địa chỉ đặt máy",
                FillWeight = 36,
                MinimumWidth = 140
            });

            dgvStations.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CashBalance",
                DataPropertyName = "CashBalance",
                HeaderText = "Tồn quỹ (VNĐ)",
                FillWeight = 20,
                MinimumWidth = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvStations.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                FillWeight = 18,
                MinimumWidth = 90
            });

            dgvStations.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastUpdated",
                DataPropertyName = "LastUpdated",
                HeaderText = "Cập nhật",
                FillWeight = 15,
                MinimumWidth = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm dd/MM" }
            });
        }

        private void LoadStations(string? keyword = null, string? selectStationCode = null)
        {
            var data = _stationBus.GetAllStations(keyword);
            dgvStations.DataSource = null;
            dgvStations.DataSource = data;

            if (!string.IsNullOrWhiteSpace(selectStationCode))
            {
                foreach (DataGridViewRow row in dgvStations.Rows)
                {
                    if (row.DataBoundItem is AtmStationDTO station &&
                        string.Equals(station.StationCode, selectStationCode, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                        dgvStations.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
        }

        private void DgvStations_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvStations.CurrentRow?.DataBoundItem is not AtmStationDTO station)
            {
                return;
            }

            txtStationCode.Text = station.StationCode;
            txtLocationAddress.Text = station.LocationAddress;
            numCashBalance.Value = Math.Clamp(station.CashBalance, numCashBalance.Minimum, numCashBalance.Maximum);
            cboStatus.SelectedItem = station.Status;
            if (cboStatus.SelectedIndex < 0)
            {
                cboStatus.SelectedIndex = 0;
            }

            _selectedPhotoPath = station.PhotoPath;
            DisplayStationPhoto(_selectedPhotoPath);
        }

        private void DisplayStationPhoto(string? photoPath)
        {
            if (picStationPhoto.Image != null)
            {
                var oldImg = picStationPhoto.Image;
                picStationPhoto.Image = null;
                oldImg.Dispose();
            }

            if (!string.IsNullOrWhiteSpace(photoPath) && File.Exists(photoPath))
            {
                try
                {
                    using var fs = new FileStream(photoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var tempImage = Image.FromStream(fs);
                    picStationPhoto.Image = new Bitmap(tempImage);
                    lblPhotoPath.Text = Path.GetFileName(photoPath);
                }
                catch (Exception ex)
                {
                    lblPhotoPath.Text = "(Không thể đọc tệp ảnh đã chọn)";
                    MessageBox.Show($"Không thể tải ảnh hiện trường: {ex.Message}", "Lỗi đọc ảnh",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                lblPhotoPath.Text = "(Chưa đính kèm ảnh hiện trường)";
            }
        }

        private void BtnBrowsePhoto_Click(object? sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Title = "Chọn ảnh chụp hiện trường trạm ATM",
                Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Tất cả tệp (*.*)|*.*",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _selectedPhotoPath = openFileDialog.FileName;
                DisplayStationPhoto(_selectedPhotoPath);
            }
        }

        private AtmStationDTO ReadFormInput()
        {
            return new AtmStationDTO
            {
                StationCode = txtStationCode.Text.Trim().ToUpperInvariant(),
                LocationAddress = txtLocationAddress.Text.Trim(),
                CashBalance = numCashBalance.Value,
                Status = cboStatus.SelectedItem?.ToString() ?? "Hoạt động",
                PhotoPath = _selectedPhotoPath
            };
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var input = ReadFormInput();
            var result = _stationBus.AddStation(input);
            MessageBox.Show(result.Message, "Quản lý Trạm ATM", MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (result.Success)
            {
                LoadStations(txtSearch.Text, input.StationCode);
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            var input = ReadFormInput();
            var result = _stationBus.UpdateStation(input);
            MessageBox.Show(result.Message, "Quản lý Trạm ATM", MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (result.Success)
            {
                LoadStations(txtSearch.Text, input.StationCode);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            var code = txtStationCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Vui lòng chọn trạm ATM cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa trạm ATM '{code}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            var result = _stationBus.DeleteStation(code);
            MessageBox.Show(result.Message, "Quản lý Trạm ATM", MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (result.Success)
            {
                ClearInputs();
                LoadStations(txtSearch.Text);
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtStationCode.Clear();
            txtLocationAddress.Clear();
            numCashBalance.Value = 500_000_000m;
            cboStatus.SelectedIndex = 0;
            _selectedPhotoPath = null;
            DisplayStationPhoto(null);
            txtStationCode.Focus();
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadStations(txtSearch.Text);
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadStations(txtSearch.Text);
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStations();
        }
    }
}
