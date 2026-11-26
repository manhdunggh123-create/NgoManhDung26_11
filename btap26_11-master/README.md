# BÀI TẬP LẬP TRÌNH .NET WINFORMS — CHƯƠNG 6 (BÀI 6.6 & BÀI 6.7)

## Thông tin sinh viên
- **Họ và tên:** Ngô Mạnh Dũng
- **Mã sinh viên (MSV):** `24810310194`
- **Môn học:** Lập trình .NET (WinForms — Kiến trúc 3-Tier)

---

## Danh sách bài tập

| STT | Thư mục | Tên bài tập | Trọng tâm kỹ thuật | Tài liệu chi tiết |
| :-: | :--- | :--- | :--- | :--- |
| 1 | `Bai6_6_HeThongMDI_ATM/` | **Bài tập 6.6:** Hệ thống MDI Điều hành Mạng lưới Cây ATM Ngân hàng | Kiến trúc MDI (`IsMdiContainer`), chống mở trùng Form con (`MdiChildren`), `async`/`await`, `Task.Run`, `CancellationTokenSource`, `OpenFileDialog` | [Xem README Bài 6.6](Bai6_6_HeThongMDI_ATM/README.md) |
| 2 | `Bai6_7_GiamSatLuoiDien_SCADA/` | **Bài tập 6.7:** Trung tâm Điều độ & Giám sát Lưới điện Thời gian thực (SCADA) | Tiến trình nền định kỳ (`Task.Run`), đảm bảo an toàn đa luồng WinForms (**Cross-Thread Safety**: `InvokeRequired` & `Invoke`), `DataGridView` cấu hình thủ công | [Xem README Bài 6.7](Bai6_7_GiamSatLuoiDien_SCADA/README.md) |

---

## Cấu trúc chuẩn 3-Tier của từng Solution

Mỗi bài tập được tổ chức độc lập trong một thư mục riêng theo đúng quy chuẩn nộp bài 3 tầng:

```text
<TenBaiTap>/
├── <TenBaiTap>.sln         # File Solution Visual Studio (.NET 8 WinForms)
├── Database/
│   └── ScriptDB.sql        # Script khởi tạo CSDL SQL Server & dữ liệu mẫu
├── DTO/                    # Data Transfer Objects (Thực thể truyền dữ liệu)
├── DAL/                    # Data Access Layer (Truy xuất & lưu trữ dữ liệu)
├── BUS/                    # Business Logic Layer (Nghiệp vụ, xử lý bất đồng bộ & mô phỏng SCADA)
├── GUI/                    # Presentation Layer (WinForms UI)
├── Images/                 # Thư mục lưu 5 ảnh chụp màn hình chức năng
└── README.md               # Báo cáo chi tiết chức năng & hướng dẫn chạy
```

---

## Yêu cầu môi trường & Hướng dẫn chạy

- **SDK:** .NET 8.0 SDK (`net8.0-windows`)
- **IDE:** Visual Studio 2022 (hoặc .NET CLI)
- **Hệ điều hành:** Windows 10 / 11

### Chạy nhanh bằng dòng lệnh (.NET CLI)

```powershell
# Chạy Bài 6.6 - Hệ thống MDI Điều hành ATM
dotnet run --project Bai6_6_HeThongMDI_ATM/GUI/AtmManagement.GUI.csproj

# Chạy Bài 6.7 - Trung tâm Điều độ & Giám sát Lưới điện SCADA
dotnet run --project Bai6_7_GiamSatLuoiDien_SCADA/GUI/PowerGridScada.GUI.csproj
```

Hoặc mở trực tiếp từng file `.sln` bằng **Visual Studio 2022**, đặt project `*.GUI` làm **Startup Project** và nhấn **F5** để chạy ở chế độ Debug.
