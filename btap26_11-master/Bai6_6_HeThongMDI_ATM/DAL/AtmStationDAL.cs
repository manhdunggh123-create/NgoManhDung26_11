using AtmManagement.DTO;

namespace AtmManagement.DAL
{
    public class AtmStationDAL
    {
        private static readonly object SyncRoot = new();
        private static readonly List<AtmStationDTO> Stations = new()
        {
            new AtmStationDTO
            {
                StationCode = "ATM-HN-001",
                LocationAddress = "Số 198 Trần Quang Khải, Hoàn Kiếm, Hà Nội",
                CashBalance = 1_850_000_000m,
                Status = "Hoạt động",
                PhotoPath = null,
                LastUpdated = DateTime.Now.AddMinutes(-25)
            },
            new AtmStationDTO
            {
                StationCode = "ATM-HN-002",
                LocationAddress = "Số 54 Liễu Giai, Ba Đình, Hà Nội",
                CashBalance = 920_000_000m,
                Status = "Hoạt động",
                PhotoPath = null,
                LastUpdated = DateTime.Now.AddMinutes(-18)
            },
            new AtmStationDTO
            {
                StationCode = "ATM-HN-003",
                LocationAddress = "Số 235 Hoàng Quốc Việt, Cầu Giấy, Hà Nội",
                CashBalance = 145_000_000m,
                Status = "Cảnh báo tồn quỹ thấp",
                PhotoPath = null,
                LastUpdated = DateTime.Now.AddMinutes(-10)
            },
            new AtmStationDTO
            {
                StationCode = "ATM-HN-004",
                LocationAddress = "Số 102 Nguyễn Trãi, Thanh Xuân, Hà Nội",
                CashBalance = 0m,
                Status = "Bảo trì",
                PhotoPath = null,
                LastUpdated = DateTime.Now.AddHours(-2)
            },
            new AtmStationDTO
            {
                StationCode = "ATM-HN-005",
                LocationAddress = "Số 15 Quang Trung, Hà Đông, Hà Nội",
                CashBalance = 1_420_000_000m,
                Status = "Hoạt động",
                PhotoPath = null,
                LastUpdated = DateTime.Now.AddMinutes(-5)
            }
        };

        public List<AtmStationDTO> GetAll()
        {
            lock (SyncRoot)
            {
                return Stations
                    .Select(s => new AtmStationDTO
                    {
                        StationCode = s.StationCode,
                        LocationAddress = s.LocationAddress,
                        CashBalance = s.CashBalance,
                        Status = s.Status,
                        PhotoPath = s.PhotoPath,
                        LastUpdated = s.LastUpdated
                    })
                    .OrderBy(s => s.StationCode, StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }
        }

        public AtmStationDTO? GetByCode(string stationCode)
        {
            lock (SyncRoot)
            {
                return Stations.FirstOrDefault(s =>
                    string.Equals(s.StationCode, stationCode, StringComparison.OrdinalIgnoreCase));
            }
        }

        public bool Insert(AtmStationDTO station)
        {
            lock (SyncRoot)
            {
                if (Stations.Any(s => string.Equals(s.StationCode, station.StationCode, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }

                station.LastUpdated = DateTime.Now;
                Stations.Add(station);
                return true;
            }
        }

        public bool Update(AtmStationDTO station)
        {
            lock (SyncRoot)
            {
                var existing = Stations.FirstOrDefault(s =>
                    string.Equals(s.StationCode, station.StationCode, StringComparison.OrdinalIgnoreCase));
                if (existing == null)
                {
                    return false;
                }

                existing.LocationAddress = station.LocationAddress;
                existing.CashBalance = station.CashBalance;
                existing.Status = station.Status;
                existing.PhotoPath = station.PhotoPath;
                existing.LastUpdated = DateTime.Now;
                return true;
            }
        }

        public bool Delete(string stationCode)
        {
            lock (SyncRoot)
            {
                var existing = Stations.FirstOrDefault(s =>
                    string.Equals(s.StationCode, stationCode, StringComparison.OrdinalIgnoreCase));
                if (existing == null)
                {
                    return false;
                }

                Stations.Remove(existing);
                return true;
            }
        }
    }
}
