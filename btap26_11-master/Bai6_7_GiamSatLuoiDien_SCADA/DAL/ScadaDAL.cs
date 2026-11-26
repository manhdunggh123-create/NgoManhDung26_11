using PowerGridScada.DTO;

namespace PowerGridScada.DAL
{
    public class SubstationDAL
    {
        private static readonly List<SubstationDTO> Substations = new()
        {
            new SubstationDTO
            {
                SubstationCode = "TBA-110-HD",
                SubstationName = "Trạm 110kV Hà Đông",
                NominalVoltageKv = 110.0,
                SafeLoadThresholdPercent = 85.0,
                Region = "Khu vực Tây Nam Hà Nội"
            },
            new SubstationDTO
            {
                SubstationCode = "TBA-220-CH",
                SubstationName = "Trạm 220kV Chèm",
                NominalVoltageKv = 220.0,
                SafeLoadThresholdPercent = 85.0,
                Region = "Khu vực Bắc Từ Liêm"
            },
            new SubstationDTO
            {
                SubstationCode = "TBA-110-TX",
                SubstationName = "Trạm 110kV Thanh Xuân",
                NominalVoltageKv = 110.0,
                SafeLoadThresholdPercent = 85.0,
                Region = "Khu vực Trung tâm Hà Nội"
            },
            new SubstationDTO
            {
                SubstationCode = "TBA-220-DA",
                SubstationName = "Trạm 220kV Đông Anh",
                NominalVoltageKv = 220.0,
                SafeLoadThresholdPercent = 85.0,
                Region = "Khu vực Bắc Sông Hồng"
            }
        };

        public List<SubstationDTO> GetAll() => Substations.ToList();
    }

    public class GridLogDAL
    {
        private static readonly object SyncRoot = new();
        private static readonly List<GridIncidentLogDTO> IncidentLogs = new();
        private static int _nextId = 1;

        public GridIncidentLogDTO AddIncident(GridIncidentLogDTO incident)
        {
            lock (SyncRoot)
            {
                incident.LogId = _nextId++;
                IncidentLogs.Insert(0, incident);
                return incident;
            }
        }

        public List<GridIncidentLogDTO> GetAll()
        {
            lock (SyncRoot)
            {
                return IncidentLogs.ToList();
            }
        }

        public void Clear()
        {
            lock (SyncRoot)
            {
                IncidentLogs.Clear();
                _nextId = 1;
            }
        }
    }
}
