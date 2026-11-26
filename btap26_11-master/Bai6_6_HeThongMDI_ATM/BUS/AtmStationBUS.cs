using AtmManagement.DAL;
using AtmManagement.DTO;

namespace AtmManagement.BUS
{
    public class AtmStationBUS
    {
        private readonly AtmStationDAL _dal = new();

        public List<AtmStationDTO> GetAllStations(string? keyword = null)
        {
            var all = _dal.GetAll();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return all;
            }

            var term = keyword.Trim();
            return all.Where(s =>
                s.StationCode.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                s.LocationAddress.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                s.Status.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public (bool Success, string Message) AddStation(AtmStationDTO station)
        {
            var validation = Validate(station);
            if (!validation.IsValid)
            {
                return (false, validation.ErrorMessage);
            }

            if (!_dal.Insert(station))
            {
                return (false, $"Mã trạm '{station.StationCode}' đã tồn tại trong hệ thống.");
            }

            return (true, $"Đã thêm trạm ATM '{station.StationCode}' thành công.");
        }

        public (bool Success, string Message) UpdateStation(AtmStationDTO station)
        {
            var validation = Validate(station);
            if (!validation.IsValid)
            {
                return (false, validation.ErrorMessage);
            }

            if (!_dal.Update(station))
            {
                return (false, $"Không tìm thấy trạm ATM '{station.StationCode}' để cập nhật.");
            }

            return (true, $"Đã cập nhật thông tin trạm ATM '{station.StationCode}'.");
        }

        public (bool Success, string Message) DeleteStation(string stationCode)
        {
            if (string.IsNullOrWhiteSpace(stationCode))
            {
                return (false, "Vui lòng chọn trạm ATM cần xóa.");
            }

            if (!_dal.Delete(stationCode))
            {
                return (false, $"Không tìm thấy trạm ATM '{stationCode}'.");
            }

            return (true, $"Đã xóa trạm ATM '{stationCode}'.");
        }

        private static (bool IsValid, string ErrorMessage) Validate(AtmStationDTO station)
        {
            if (string.IsNullOrWhiteSpace(station.StationCode))
            {
                return (false, "Mã trạm ATM không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(station.LocationAddress))
            {
                return (false, "Địa chỉ đặt máy ATM không được để trống.");
            }

            if (station.CashBalance < 0)
            {
                return (false, "Số tiền tồn quỹ không được nhỏ hơn 0.");
            }

            if (string.IsNullOrWhiteSpace(station.Status))
            {
                return (false, "Vui lòng chọn trạng thái hoạt động.");
            }

            return (true, string.Empty);
        }
    }
}
