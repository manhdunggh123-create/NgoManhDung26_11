-- =============================================
-- BÀI TẬP 6.7: TRUNG TÂM ĐIỀU ĐỘ & GIÁM SÁT LƯỚI ĐIỆN THỜI GIAN THỰC (SCADA)
-- Sinh viên: Đỗ Việt Hoàng - MSV: 24810310199
-- =============================================

CREATE DATABASE PowerGridScadaDB;
GO

USE PowerGridScadaDB;
GO

-- 1. Bảng Danh mục Trạm biến áp
CREATE TABLE Substations (
    SubstationCode NVARCHAR(20) PRIMARY KEY,
    SubstationName NVARCHAR(150) NOT NULL,
    NominalVoltageKv DECIMAL(6, 2) NOT NULL,
    SafeLoadThresholdPercent DECIMAL(5, 2) NOT NULL DEFAULT 85.00,
    Region NVARCHAR(100) NOT NULL
);
GO

-- 2. Bảng Nhật ký sự cố Quá tải lưới điện
CREATE TABLE GridIncidentLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    RecordedAt DATETIME NOT NULL DEFAULT GETDATE(),
    SubstationCode NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Substations(SubstationCode),
    SubstationName NVARCHAR(150) NOT NULL,
    VoltageKv DECIMAL(6, 2) NOT NULL,
    LoadPercent DECIMAL(5, 2) NOT NULL,
    Severity NVARCHAR(50) NOT NULL,
    Message NVARCHAR(300) NOT NULL
);
GO

-- Dữ liệu mẫu Trạm biến áp
INSERT INTO Substations (SubstationCode, SubstationName, NominalVoltageKv, SafeLoadThresholdPercent, Region)
VALUES
(N'TBA-110-HD', N'Trạm 110kV Hà Đông', 110.00, 85.00, N'Khu vực Tây Nam Hà Nội'),
(N'TBA-220-CH', N'Trạm 220kV Chèm', 220.00, 85.00, N'Khu vực Bắc Từ Liêm'),
(N'TBA-110-TX', N'Trạm 110kV Thanh Xuân', 110.00, 85.00, N'Khu vực Trung tâm Hà Nội'),
(N'TBA-220-DA', N'Trạm 220kV Đông Anh', 220.00, 85.00, N'Khu vực Bắc Sông Hồng');
GO
