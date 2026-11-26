-- =============================================
-- BÀI TẬP 6.6: HỆ THỐNG MDI ĐIỀU HÀNH MẠNG LƯỚI CÂY ATM NGÂN HÀNG
-- Sinh viên: Đỗ Việt Hoàng - MSV: 24810310199
-- =============================================

CREATE DATABASE BankAtmManagementDB;
GO

USE BankAtmManagementDB;
GO

-- 1. Bảng Danh sách Trạm ATM & Tồn quỹ
CREATE TABLE AtmStations (
    StationCode NVARCHAR(20) PRIMARY KEY,
    LocationAddress NVARCHAR(255) NOT NULL,
    CashBalance DECIMAL(18, 0) NOT NULL DEFAULT 0,
    Status NVARCHAR(50) NOT NULL DEFAULT N'Hoạt động',
    PhotoPath NVARCHAR(500) NULL,
    LastUpdated DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- 2. Bảng Lịch sử Đối soát Giao dịch ATM Cuối ngày
CREATE TABLE ReconciliationLogs (
    SessionId NVARCHAR(30) PRIMARY KEY,
    StartedAt DATETIME NOT NULL,
    CompletedAt DATETIME NULL,
    TotalTransactions INT NOT NULL,
    MatchedCount INT NOT NULL,
    DiscrepancyCount INT NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    OperatorName NVARCHAR(100) NOT NULL,
    Notes NVARCHAR(500) NULL
);
GO

-- Dữ liệu mẫu Trạm ATM
INSERT INTO AtmStations (StationCode, LocationAddress, CashBalance, Status, PhotoPath)
VALUES
(N'ATM-HN-001', N'Số 198 Trần Quang Khải, Hoàn Kiếm, Hà Nội', 1850000000, N'Hoạt động', NULL),
(N'ATM-HN-002', N'Số 54 Liễu Giai, Ba Đình, Hà Nội', 920000000, N'Hoạt động', NULL),
(N'ATM-HN-003', N'Số 235 Hoàng Quốc Việt, Cầu Giấy, Hà Nội', 145000000, N'Cảnh báo tồn quỹ thấp', NULL),
(N'ATM-HN-004', N'Số 102 Nguyễn Trãi, Thanh Xuân, Hà Nội', 0, N'Bảo trì', NULL),
(N'ATM-HN-005', N'Số 15 Quang Trung, Hà Đông, Hà Nội', 1420000000, N'Hoạt động', NULL);
GO

-- Dữ liệu mẫu Lịch sử Đối soát
INSERT INTO ReconciliationLogs (SessionId, StartedAt, CompletedAt, TotalTransactions, MatchedCount, DiscrepancyCount, Status, OperatorName, Notes)
VALUES
(N'REC-20261125-01', '2026-11-25 17:30:00', '2026-11-25 17:30:05', 184520, 184516, 4, N'Hoàn tất', N'Đỗ Việt Hoàng', N'Đã tự động tạo phiếu tra soát cho 4 giao dịch lệch.');
GO
