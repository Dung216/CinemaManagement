# ĐỀ TÀI 10: PHẦN MỀM QUẢN LÝ RẠP CHIẾU PHIM (3–5 PHÒNG CHIẾU)

Dự án thành phần A3 – Cuối kỳ (40%) môn **Lập trình trên môi trường Windows (111165)**
- **Công nghệ**: C# .NET 8.0 Windows Forms trên Visual Studio 2022
- **Kiến trúc**: Không sử dụng SQL/CSDL, toàn bộ dữ liệu quản lý trong bộ nhớ bằng `List<T>` và lưu trữ bằng tập tin văn bản (.txt, .csv, UTF-8, phân cách `;`)

---

## 🌟 PHÂN HỆ VÀ TÍNH NĂNG ĐÃ HOÀN THIỆN ĐẦY ĐỦ

### 1. Phân hệ SV1 – Phim & Phòng chiếu:
- **Quản lý phim**:
  - Mã, Tên, Thể loại, Thời lượng (phút), Giới hạn độ tuổi (P, K, T13, T16, T18), File Poster.
  - Hiển thị Poster trực quan bằng `PictureBox`, chọn ảnh poster qua `OpenFileDialog`.
  - Hiển thị danh sách phim bằng `ListView`: hỗ trợ chuyển đổi linh hoạt giữa chế độ **`LargeIcon` (Poster thumbnail trực quan)** và **`Details` (Bảng chi tiết)**.
  - Lọc phim theo thể loại bằng `ComboBox`.
  - **Nhập danh sách phim từ tập tin CSV** (`OpenFileDialog`), tự động kiểm tra chống trùng mã phim.
- **Quản lý phòng chiếu**:
  - Mã phòng, Tên phòng, Số hàng ghế, Số ghế mỗi hàng, Các hàng ghế VIP (VD: C,D).
  - Tự động tính tổng số ghế và nhận diện vị trí ghế VIP.

### 2. Phân hệ SV2 – Suất chiếu & Cây lịch chiếu:
- **Lên lịch suất chiếu**:
  - Chọn Phim, Phòng chiếu, Ngày giờ chiếu, Giá vé cơ bản.
  - **Thuật toán kiểm tra không cho hai suất chồng giờ trong cùng phòng**:
    - Tính theo công thức: `Thời gian chiếm phòng = Thời lượng phim + 15 phút dọn phòng` (cấu hình trong `App.config`).
    - Ngăn chặn triệt để xung đột thời gian, hiển thị cảnh báo chi tiết suất đang bị trùng.
- **Cây lịch chiếu (`TreeView`)**:
  - Cấu trúc 3 cấp phân cấp: `📅 Ngày -> 🎬 Phim -> ⏰ Suất chiếu`.
  - Hiển thị đầy đủ thông tin: Giờ chiếu, phòng chiếu, đơn giá, số vé đã bán / tổng số ghế.
- **Hủy suất chưa bán vé**:
  - Kiểm tra nếu suất chiếu đã có vé được bán ra -> Chặn không cho xóa và giải thích lý do.
  - Nếu chưa có vé bán -> Xác nhận và cho phép xóa an toàn.

### 3. Phân hệ SV3 – Bán vé & Doanh thu:
- **Quầy bán vé theo sơ đồ ghế**:
  - **Sơ đồ ghế bằng Button được tạo động bằng code** C# theo cấu hình từng phòng chiếu.
  - Màu sắc phân biệt trực quan 4 trạng thái:
    - ⬜ **Ghế tiêu chuẩn trống**: Màu xanh nhạt/trắng viền xanh.
    - 🟨 **Ghế VIP trống**: Màu vàng cam nổi bật.
    - 🟦 **Ghế đang chọn**: Màu xanh dương đậm.
    - 🟥 **Ghế đã bán**: Màu đỏ (vô hiệu hóa, không cho bán trùng ghế).
- **Loại vé & Giảm giá**:
  - RadioButton chọn loại vé: **Người lớn** (100% giá) / **Học sinh - Sinh viên** (giảm 20% cấu hình trong `App.config`).
  - Tự động cộng phụ thu ghế VIP (15.000đ cấu hình trong `App.config`).
- **In vé / Hóa đơn ra tập tin TXT**:
  - Xuất phiếu vé điện tử ra tập tin TXT trong thư mục `Tickets/`, hỗ trợ mở xem và in ngay.
- **Thống kê doanh thu**:
  - Thống kê doanh thu theo **Phim** (Số vé, Doanh thu, Tỷ lệ %).
  - Thống kê doanh thu theo **Ngày** trong khoảng thời gian.
  - **Xuất báo cáo doanh thu ra tập tin TXT** và **xuất chi tiết ra CSV** (`SaveFileDialog`).

### 4. Tính năng nâng cao (Điểm cộng):
- 🍿 **Combo bắp nước**: Cho phép chọn kèm combo Solo, Couple, Party khi mua vé; tự động cộng vào tổng tiền và in lên vé.
- 🔄 **Trả vé trước giờ chiếu 1 tiếng**: Tra cứu vé, kiểm tra quy tắc thời gian cách giờ chiếu >= 60 phút mới cho trả và hoàn tiền; phục hồi lại ghế trống ngay lập tức.
- ⏱️ **Timer tự động ẩn suất đã chiếu**: Tự động lọc ẩn các suất chiếu đã qua giờ bắt đầu khỏi danh sách chọn bán vé.

---

## 🛠️ YÊU CẦU KỸ THUẬT BẮT BUỘC ĐÃ ĐẠT CHUẨN 100%

| # | Yêu cầu kỹ thuật | Cài đặt trong đồ án |
|---|-------------------|---------------------|
| **1** | C# WinForms VS 2022, OOP, mỗi đối tượng có `ToString()`, quản lý bằng `List<T>`, không SQL | `User`, `Movie`, `Room`, `Showtime`, `Ticket`, `SnackCombo` đều có `ToString()`, lưu trong `DataManager` bằng `List<T>` |
| **2** | Lưu file .txt/.csv UTF-8 phân cách `;`, `StreamReader`/`StreamWriter`, tối thiểu 4 file, chính >= 20 dòng | `phim.txt` (25 phim mẫu), `users.txt`, `phongchieu.txt` (5 phòng), `suatchieu.txt`, `ve.txt`, `combos.txt` |
| **3** | Kiểm tra dữ liệu (không rỗng, `TryParse`, không trùng mã), focus về ô sai | Tất cả các form thêm/sửa đều dùng `TryParse`, kiểm tra trùng và `.Focus()` |
| **4** | `ListView (Details)`, `ComboBox`, `ListBox`, `TreeView`, `PictureBox`, `Timer`, `ContextMenuStrip` | Đã sử dụng đầy đủ cả 7 điều khiển theo yêu cầu của Chương 3 |
| **5** | Form chính MDI, MenuStrip, form con không mở trùng, menu Cửa sổ sắp xếp | `FormMain` (`IsMdiContainer = true`), kiểm tra `MdiChildren`, menu Cửa sổ (Cascade, Tile, Close All) |
| **6** | Hộp thoại chuẩn: `MessageBox` xác nhận xóa/thoát, `OpenFileDialog`/`SaveFileDialog`, `ColorDialog`/`FontDialog` | Đầy đủ hộp thoại chuẩn xác nhận và nhập xuất file |
| **7** | `try-catch` mọi thao tác tập tin, dòng lỗi bỏ qua không sập, ghi `log.txt` | Tự động bắt lỗi, bỏ qua dòng lỗi định dạng và ghi log chi tiết vào `log.txt` |
| **8** | `App.config` chứa tham số chung; `Registry` lưu tùy chọn người dùng | `App.config` lưu tên rạp, giảm giá HS-SV, dọn phòng; `Registry` lưu ghi nhớ đăng nhập, vị trí form, màu/font |
| **9** | Đăng nhập từ `users.txt`, 2 vai trò (Admin, Staff) với menu khác nhau, khóa sau 3 lần sai | Form đăng nhập kiểm tra 3 lần sai -> khóa tài khoản và lưu vào file |
| **10** | Sao lưu / khôi phục dữ liệu (`File`, `Directory`, `FileStream`), xuất báo cáo TXT/CSV | Đầy đủ chức năng sao lưu/khôi phục toàn bộ dữ liệu và xuất báo cáo |

---

## 🚀 HƯỚNG DẪN KHỞI ĐỘNG VÀ CHẠY DỰ ÁN

### Cách 1: Chạy bằng Visual Studio 2022 (Khuyên dùng)
1. Mở **Visual Studio 2022**.
2. Chọn **Open a project or solution**.
3. Điều hướng đến thư mục dự án và chọn file:
   `CinemaManagement.sln`
4. Nhấn phím **F5** (hoặc nút **Start / Run** màu xanh) để khởi động ứng dụng.
5. Đăng nhập bằng tài khoản mẫu:
   - **Tài khoản Quản trị viên (Admin)**: `admin` | Mật khẩu: `admin123` (Toàn quyền hệ thống)
   - **Tài khoản Nhân viên (Staff)**: `staff` | Mật khẩu: `staff123` (Bán vé, tra cứu, in vé)
   - **Tài khoản Thu ngân**: `thungan` | Mật khẩu: `thungan123`

### Cách 2: Chạy kiểm thử tự động từ Command Line / Terminal
Mở PowerShell hoặc Command Prompt tại thư mục dự án và chạy lệnh:
```bash
dotnet run --no-restore -- --test
```
Chương trình sẽ tự động kiểm thử toàn bộ 10 kịch bản test case và xuất kết quả `10/10 TEST PASS (100%)`.
