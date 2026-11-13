# TÀI LIỆU BÁO CÁO DỰ ÁN & BẢNG TEST CASE KIỂM THỬ

**Học phần**: Lập trình trên môi trường Windows (111165)  
**Đề tài 10**: Quản lý rạp chiếu phim (3–5 phòng chiếu)  
**Công nghệ**: C# .NET Windows Forms, Visual Studio 2022  

---

## I. TỔNG QUAN HỆ THỐNG
Phần mềm phục vụ cho quy trình quản lý và vận hành quầy vé tại rạp chiếu phim quy mô vừa và nhỏ (3 đến 5 phòng chiếu). Hệ thống đáp ứng đầy đủ nghiệp vụ:
- Quản lý danh mục phim, hiển thị poster trực quan, phân loại và nhập liệu từ file.
- Quản lý cấu hình phòng chiếu (hàng ghế, ghế mỗi hàng, hàng VIP).
- Lên lịch suất chiếu thông minh với thuật toán ngăn chặn chồng giờ trong cùng phòng chiếu.
- Quầy bán vé trực quan theo sơ đồ ghế động, chống trùng ghế, hỗ trợ giảm giá theo đối tượng và combo bắp nước.
- Tra cứu và thực hiện quy tắc hoàn trả vé trước giờ chiếu ít nhất 60 phút.
- Thống kê doanh thu theo phim, theo ngày và xuất báo cáo ra file TXT, CSV.

---

## II. MÔ TẢ CẤU TRÚC CÁC TẬP TIN DỮ LIỆU (THƯ MỤC `Data/`)
Dữ liệu lưu trữ hoàn toàn dưới dạng tập tin văn bản thuần (.txt, .csv) theo chuẩn mã hóa UTF-8, mỗi dòng là một bản ghi, các trường phân tách bằng dấu chấm phẩy `;`:

1. **`users.txt`**: Lưu trữ danh sách tài khoản người dùng
   - Định dạng: `Username;Password;FullName;Role;IsLocked;FailedAttempts`
   - Ví dụ: `admin;admin123;Quản trị viên hệ thống;Admin;False;0`

2. **`phim.txt`**: Danh mục phim (có sẵn >= 20 dòng mẫu)
   - Định dạng: `Ma;Ten;TheLoai;ThoiLuong;GioiHanTuoi;Poster`
   - Ví dụ: `P01;Mai;Tâm lý, Tình cảm;131;T18;mai.jpg`

3. **`phongchieu.txt`**: Cấu hình các phòng chiếu trong rạp
   - Định dạng: `Ma;Ten;SoHang;SoGheMoiHang;HangVIP`
   - Ví dụ: `PC01;Phòng Chiếu 1 (Standard);6;8;C,D`

4. **`suatchieu.txt`**: Lịch chiếu phim theo phòng và giờ
   - Định dạng: `Ma;MaPhim;MaPhong;NgayGio;GiaVe`
   - Ví dụ: `SC01;P01;PC01;2026-11-13 09:00;80000`

5. **`ve.txt`**: Danh sách vé đã bán ra
   - Định dạng: `Ma;MaSuat;Ghe;LoaiVe;GiaBan;NgayBan;ComboDetails`
   - Ví dụ: `VE001;SC01;A1;Người lớn;80000;2026-11-13 08:15;Combo Solo: 1`

6. **`combos.txt`**: Danh mục combo bắp nước bán kèm
   - Định dạng: `Ma;Ten;Gia;MoTa`
   - Ví dụ: `CB01;Combo Solo (1 Bắp + 1 Nước);50000;1 Bắp ngọt vừa + 1 Nước ngọt 22oz`

---

## III. BẢNG TEST CASE KIỂM THỬ CHỨC NĂNG (TEST CASES)

| Mã TC | Tên Chức Năng | Các Bước Thực Hiện | Dữ Liệu Đầu Vào | Kết Quả Mong Đợi | Trạng Thái |
|-------|---------------|-------------------|-----------------|-------------------|------------|
| **TC01** | Đăng nhập đúng | Nhập user và pass chính xác, bấm "Đăng nhập" | `admin` / `admin123` | Đăng nhập thành công, mở FormMain với quyền Quản trị viên | **PASS** |
| **TC02** | Phân quyền vai trò | Đăng nhập bằng tài khoản nhân viên | `staff` / `staff123` | Menu Quản trị tài khoản, Sao lưu/Khôi phục bị ẩn | **PASS** |
| **TC03** | Khóa tài khoản sau 3 lần sai | Nhập sai mật khẩu 3 lần liên tiếp cho 1 tài khoản | Sai pass 3 lần | Tài khoản bị khóa (`IsLocked = true`), không cho đăng nhập | **PASS** |
| **TC04** | Kiểm tra trùng mã phim | Nhập mã phim đã tồn tại trong hệ thống | Mã `P01` | Báo lỗi trùng mã phim, trỏ chuột về ô Mã phim | **PASS** |
| **TC05** | Chuyển chế độ xem phim | Bấm nút chuyển đổi chế độ xem trên Form Phim | Click nút | Chuyển đổi qua lại giữa dạng Poster (LargeIcon) và Bảng (Details) | **PASS** |
| **TC06** | Nhập phim từ CSV | Chọn file `import_phim_mau.csv` từ nút "Nhập từ CSV" | File CSV hợp lệ | Nạp thêm các phim mới vào danh sách, tự bỏ qua mã trùng | **PASS** |
| **TC07** | Chống chồng giờ cùng phòng | Thêm suất chiếu mới có giờ chiếu giao với suất cũ trong cùng phòng | Suất cùng phòng cách < (thời lượng + 15p) | Báo lỗi xung đột lịch chiếu chi tiết, đưa con trỏ về ô giờ | **PASS** |
| **TC08** | Cùng giờ khác phòng | Thêm 2 suất chiếu cùng thời gian nhưng ở 2 phòng khác nhau | Phòng PC01 và PC02 | Cho phép lên lịch thành công không báo lỗi | **PASS** |
| **TC09** | Chặn hủy suất đã bán vé | Chọn suất chiếu đã có khán giả mua vé và bấm "Hủy suất" | Suất `SC01` (đã có vé) | Hiển thị thông báo từ chối hủy suất chiếu đã bán vé | **PASS** |
| **TC10** | Hủy suất chưa bán vé | Chọn suất chiếu chưa có vé và bấm "Hủy suất" | Suất chưa bán vé | Hiện hộp thoại xác nhận Yes/No, xóa thành công khi chọn Yes | **PASS** |
| **TC11** | Hiển thị sơ đồ ghế động | Chọn 1 suất chiếu trên quầy bán vé | Suất chiếu cụ thể | Sinh các nút ghế theo số hàng, số cột; ghế đã bán tô màu đỏ | **PASS** |
| **TC12** | Chống bán trùng ghế | Nhấp vào ghế màu đỏ (đã bán) trên sơ đồ | Ghế đã bán | Vô hiệu hóa hoặc báo ghế đã có người mua | **PASS** |
| **TC13** | Giảm giá HS-SV | Chọn ghế, chuyển RadioButton từ Người lớn sang HS-SV | Giảm 20% từ App.config | Tổng tiền tự động giảm 20% tiền vé ngay lập tức | **PASS** |
| **TC14** | Thêm combo bắp nước | Tăng số lượng combo Solo/Couple khi đặt vé | 1 Combo Solo | Tổng thanh toán cộng thêm giá combo chính xác | **PASS** |
| **TC15** | Thanh toán & In vé TXT | Chọn ghế, bấm "Thanh toán & In vé" | Ghế A1, C3 | Lưu vé vào `ve.txt`, xuất file hóa đơn vào thư mục `Tickets/` | **PASS** |
| **TC16** | Trả vé trước 1 tiếng | Nhập mã vé có giờ chiếu cách hiện tại >= 60 phút | Suất cách >= 60p | Báo vé hợp lệ, cho phép hoàn tiền và giải phóng ghế trống | **PASS** |
| **TC17** | Từ chối trả vé < 1 tiếng | Nhập mã vé có giờ chiếu cách hiện tại < 60 phút | Suất cách < 60p | Báo từ chối trả vé do vi phạm quy định 1 tiếng | **PASS** |
| **TC18** | Timer ẩn suất quá giờ | Bật tùy chọn "Tự động ẩn suất đã chiếu" | Suất có giờ < Hiện tại | Suất chiếu quá giờ tự động biến mất khỏi danh sách chọn | **PASS** |
| **TC19** | Sao lưu / Khôi phục | Thực hiện sao lưu dữ liệu ra thư mục khác | Chọn thư mục | Copy toàn bộ các file dữ liệu bằng Stream, khôi phục nguyên vẹn | **PASS** |
| **TC20** | Xuất báo cáo TXT & CSV | Nhấn nút xuất báo cáo tại màn hình Thống kê | Chọn nơi lưu file | Xuất thành công file báo cáo định dạng chuẩn bảng và CSV | **PASS** |

---

## IV. BẢNG PHÂN CÔNG CÔNG VIỆC VÀ TỶ LỆ ĐÓNG GÓP

| Thành viên | Nhiệm vụ phân công | Sản phẩm / Module phụ trách | Tỷ lệ đóng góp |
|------------|---------------------|-----------------------------|----------------|
| **Sinh viên 1** | Phân hệ Phim & Phòng chiếu | Quản lý phim (LargeIcon, PictureBox), lọc thể loại, nhập CSV, cấu hình phòng chiếu & hàng VIP | **100%** (33.3%) |
| **Sinh viên 2** | Phân hệ Suất chiếu & Cây lịch chiếu | Lên lịch suất chiếu, thuật toán chống chồng giờ (+15p dọn phòng), TreeView Ngày->Phim->Suất, hủy suất chưa bán | **100%** (33.3%) |
| **Sinh viên 3** | Phân hệ Bán vé & Thống kê doanh thu | Sơ đồ ghế động bằng Button, RadioButton loại vé, In vé TXT, thống kê báo cáo, combo bắp nước, trả vé 1h | **100%** (33.4%) |
| **Tổng cộng** | Toàn bộ 3 phân hệ + Điểm cộng nâng cao | Hệ thống hoàn chỉnh 100%, tự động test đạt 10/10 test case | **100%** |
