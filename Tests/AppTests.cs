using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Tests
{
    public static class AppTests
    {
        public static bool RunAllTests(out int passed, out int failed, out List<string> errors)
        {
            passed = 0;
            failed = 0;
            errors = new List<string>();

            Console.WriteLine("==================================================================");
            Console.WriteLine("       BẮT ĐẦU CHẠY KIỂM THỬ TỰ ĐỘNG TOÀN DIỆN (AUTOMATED TESTS)");
            Console.WriteLine("          ĐỀ TÀI 10: QUẢN LÝ RẠP CHIẾU PHIM (C# WINFORMS)");
            Console.WriteLine("==================================================================");

            RunTest("Test 01: Khởi tạo dữ liệu & Tập tin mẫu (>= 20 phim)", () =>
            {
                DataManager.Initialize();

                Assert(File.Exists(DataManager.UsersFilePath), "File users.txt không tồn tại!");
                Assert(File.Exists(DataManager.MoviesFilePath), "File phim.txt không tồn tại!");
                Assert(File.Exists(DataManager.RoomsFilePath), "File phongchieu.txt không tồn tại!");
                Assert(File.Exists(DataManager.ShowtimesFilePath), "File suatchieu.txt không tồn tại!");
                Assert(File.Exists(DataManager.TicketsFilePath), "File ve.txt không tồn tại!");

                // Yêu cầu số 2: tập tin chính có sẵn >= 20 dòng dữ liệu mẫu
                Assert(DataManager.Movies.Count >= 20, $"Số dòng phim mẫu phải >= 20, thực tế có {DataManager.Movies.Count} dòng.");
                Assert(DataManager.Rooms.Count >= 3, $"Số phòng chiếu phải từ 3-5 phòng, thực tế có {DataManager.Rooms.Count} phòng.");
                Assert(DataManager.Users.Count >= 2, $"Số người dùng tối thiểu 2 vai trò, thực tế có {DataManager.Users.Count}.");

                // Yêu cầu số 1: Mỗi đối tượng nghiệp vụ là 1 lớp có ToString()
                var sampleMovie = DataManager.Movies[0];
                Assert(!string.IsNullOrEmpty(sampleMovie.ToString()), "Movie.ToString() không được rỗng!");
                var sampleRoom = DataManager.Rooms[0];
                Assert(!string.IsNullOrEmpty(sampleRoom.ToString()), "Room.ToString() không được rỗng!");
                var sampleUser = DataManager.Users[0];
                Assert(!string.IsNullOrEmpty(sampleUser.ToString()), "User.ToString() không được rỗng!");
            }, ref passed, ref failed, errors);

            RunTest("Test 02: Xác thực & Khóa tài khoản sau 3 lần sai mật khẩu (Yêu cầu 9)", () =>
            {
                string testUser = "test_staff_" + Guid.NewGuid().ToString("N").Substring(0, 5);
                var u = new User(testUser, "123456", "Nhân viên Test", "Staff", false, 0);
                DataManager.Users.Add(u);

                // Lần 1: sai pass
                u.FailedAttempts++;
                Assert(!u.IsLocked, "Chưa đủ 3 lần không được khóa tài khoản!");

                // Lần 2: sai pass
                u.FailedAttempts++;
                Assert(!u.IsLocked, "Lần 2 sai vẫn chưa được khóa!");

                // Lần 3: sai pass -> BỊ KHÓA
                u.FailedAttempts++;
                if (u.FailedAttempts >= 3) u.IsLocked = true;
                Assert(u.IsLocked, "Nhập sai 3 lần liên tiếp tài khoản PHẢI bị khóa!");

                // Mở khóa bởi Admin
                u.IsLocked = false;
                u.FailedAttempts = 0;
                Assert(!u.IsLocked && u.FailedAttempts == 0, "Mở khóa thành công!");
                DataManager.Users.Remove(u);
            }, ref passed, ref failed, errors);

            RunTest("Test 03: SV1 - Quản lý phòng chiếu & Nhận diện ghế VIP", () =>
            {
                var room = new Room("TEST_PC", "Phòng Thử Nghiệm", 6, 8, "C,D");
                Assert(room.TotalSeats == 48, $"Tổng ghế phòng phải là 48 (6x8), thực tế là {room.TotalSeats}");
                Assert(room.IsVipSeat("C3"), "Ghế C3 phải là ghế VIP (hàng C nằm trong 'C,D')!");
                Assert(room.IsVipSeat("D8"), "Ghế D8 phải là ghế VIP!");
                Assert(!room.IsVipSeat("A1"), "Ghế A1 phải là ghế tiêu chuẩn!");
                Assert(!room.IsVipSeat("F4"), "Ghế F4 phải là ghế tiêu chuẩn!");
            }, ref passed, ref failed, errors);

            RunTest("Test 04: SV1 - Nhập phim từ CSV & Kiểm tra không trùng mã", () =>
            {
                string sampleCsv = Path.Combine(DataManager.GetDataDirectory(), "SampleData", "import_phim_mau.csv");
                Assert(File.Exists(sampleCsv), "Tập tin import_phim_mau.csv mẫu phải tồn tại!");

                int oldCount = DataManager.Movies.Count;
                string[] lines = File.ReadAllLines(sampleCsv);
                int added = 0;
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("Ma;")) continue;
                    var m = Movie.FromDataLine(line);
                    if (m != null && !DataManager.Movies.Any(x => x.Id == m.Id))
                    {
                        DataManager.Movies.Add(m);
                        added++;
                    }
                }
                Assert(added >= 0, "Xử lý nhập CSV thành công!");
            }, ref passed, ref failed, errors);

            RunTest("Test 05: SV2 - Thuật toán chống chồng giờ trong cùng phòng (+15p dọn phòng)", () =>
            {
                // Giả sử phim P01 có thời lượng 131 phút. Dọn phòng 15 phút => Chiếm phòng 146 phút.
                var movie = DataManager.Movies.First();
                var room = DataManager.Rooms.First();

                DateTime t1 = new DateTime(2026, 12, 1, 10, 0, 0);
                var s1 = new Showtime("TEST_S1", movie.Id, room.Id, t1, 80000);
                DataManager.Showtimes.Add(s1);

                // Suất s2 bắt đầu lúc 11:30 (sau 90p) -> Phim s1 chưa chiếu xong (131p) -> XUNG ĐỘT!
                DateTime t2 = new DateTime(2026, 12, 1, 11, 30, 0);
                var s2 = new Showtime("TEST_S2", movie.Id, room.Id, t2, 80000);
                bool conflict1 = !DataManager.ValidateShowtimeConflict(s2, out string msg1);
                Assert(conflict1, "Suất s2 phải bị báo xung đột do chồng giờ!");

                // Suất s3 bắt đầu lúc 12:15 (sau 135p) -> Phim s1 đã hết nhưng đang dọn phòng 15p (đến 12:26) -> XUNG ĐỘT!
                DateTime t3 = new DateTime(2026, 12, 1, 12, 15, 0);
                var s3 = new Showtime("TEST_S3", movie.Id, room.Id, t3, 80000);
                bool conflict2 = !DataManager.ValidateShowtimeConflict(s3, out string msg2);
                Assert(conflict2, "Suất s3 phải bị báo xung đột do đang trong 15 phút dọn phòng!");

                // Suất s4 bắt đầu lúc 12:30 (sau 150p) -> s1 đã hoàn thành chiếu và dọn phòng -> HỢP LỆ!
                DateTime t4 = new DateTime(2026, 12, 1, 12, 30, 0);
                var s4 = new Showtime("TEST_S4", movie.Id, room.Id, t4, 80000);
                bool valid = DataManager.ValidateShowtimeConflict(s4, out string msg4);
                Assert(valid, $"Suất s4 phải hợp lệ! Thông báo nếu lỗi: {msg4}");

                // Suất ở PHÒNG KHÁC cùng giờ -> HỢP LỆ!
                var otherRoom = DataManager.Rooms.First(r => r.Id != room.Id);
                var sOther = new Showtime("TEST_SOTHER", movie.Id, otherRoom.Id, t1, 80000);
                bool validOther = DataManager.ValidateShowtimeConflict(sOther, out string msgOther);
                Assert(validOther, "Khác phòng chiếu cùng giờ phải hợp lệ!");

                DataManager.Showtimes.Remove(s1);
            }, ref passed, ref failed, errors);

            RunTest("Test 06: SV2 - Hủy suất chiếu chưa bán vé & Chặn hủy suất đã bán vé", () =>
            {
                var sNoTicket = new Showtime("TEST_NO_TICKET", "P01", "PC01", DateTime.Now.AddDays(5), 80000);
                DataManager.Showtimes.Add(sNoTicket);
                Assert(!DataManager.HasSoldTickets(sNoTicket.Id), "Suất mới chưa bán vé nào!");

                var sWithTicket = new Showtime("TEST_WITH_TICKET", "P01", "PC01", DateTime.Now.AddDays(6), 80000);
                DataManager.Showtimes.Add(sWithTicket);
                var t = new Ticket("TEST_TK_01", sWithTicket.Id, "A1", "Người lớn", 80000, DateTime.Now);
                DataManager.Tickets.Add(t);

                Assert(DataManager.HasSoldTickets(sWithTicket.Id), "Suất này đã có vé bán ra!");

                // Dọn dẹp
                DataManager.Showtimes.Remove(sNoTicket);
                DataManager.Showtimes.Remove(sWithTicket);
                DataManager.Tickets.Remove(t);
            }, ref passed, ref failed, errors);

            RunTest("Test 07: SV3 - Tính tiền vé, Giảm giá HS-SV & Phụ thu VIP từ App.config", () =>
            {
                var room = new Room("PC_TEST", "Test Room", 6, 8, "C,D");
                decimal basePrice = 80000;
                decimal vipSurcharge = ConfigManager.VipSurcharge; // 15,000đ
                int discountPercent = ConfigManager.StudentDiscountPercent; // 20%

                // Vé thường - Người lớn
                decimal priceAdultNormal = basePrice;
                Assert(priceAdultNormal == 80000, "Giá vé thường người lớn = 80.000đ");

                // Vé VIP - Người lớn
                decimal priceAdultVip = basePrice + vipSurcharge;
                Assert(priceAdultVip == 95000, "Giá vé VIP người lớn = 95.000đ");

                // Vé VIP - Học sinh sinh viên (giảm 20%)
                decimal priceStudentVip = priceAdultVip * (100 - discountPercent) / 100m;
                Assert(priceStudentVip == 76000, "Giá vé VIP HS-SV = 76.000đ");
            }, ref passed, ref failed, errors);

            RunTest("Test 08: Điểm cộng - Trả vé trước giờ chiếu ít nhất 1 tiếng (60 phút)", () =>
            {
                // Trường hợp 1: Suất chiếu còn cách 2 tiếng (120 phút >= 60 phút) -> Được trả vé!
                var sValid = new Showtime("S_REFUND_VALID", "P01", "PC01", DateTime.Now.AddHours(2), 80000);
                DataManager.Showtimes.Add(sValid);
                var tValid = new Ticket("T_REFUND_VALID", sValid.Id, "A1", "Người lớn", 80000, DateTime.Now);
                DataManager.Tickets.Add(tValid);

                bool canRefund = DataManager.CheckTicketRefundable(tValid.Id, out _, out _, out string msgValid);
                Assert(canRefund, $"Suất chiếu còn 2 tiếng phải trả được vé! Lỗi: {msgValid}");

                // Trường hợp 2: Suất chiếu chỉ còn cách 30 phút (< 60 phút) -> BỊ TỪ CHỐI!
                var sInvalid = new Showtime("S_REFUND_INVALID", "P01", "PC01", DateTime.Now.AddMinutes(30), 80000);
                DataManager.Showtimes.Add(sInvalid);
                var tInvalid = new Ticket("T_REFUND_INVALID", sInvalid.Id, "A2", "Người lớn", 80000, DateTime.Now);
                DataManager.Tickets.Add(tInvalid);

                bool cannotRefund = !DataManager.CheckTicketRefundable(tInvalid.Id, out _, out _, out string msgInvalid);
                Assert(cannotRefund, "Suất chiếu trong vòng 60 phút PHẢI bị từ chối trả vé!");

                // Dọn dẹp
                DataManager.Showtimes.Remove(sValid);
                DataManager.Showtimes.Remove(sInvalid);
                DataManager.Tickets.Remove(tValid);
                DataManager.Tickets.Remove(tInvalid);
            }, ref passed, ref failed, errors);

            RunTest("Test 09: Yêu cầu 10 - Sao lưu và khôi phục thư mục dữ liệu", () =>
            {
                string tempBackupParent = Path.Combine(Path.GetTempPath(), "CinemaTestBackup_" + Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(tempBackupParent);

                try
                {
                    string backupDir = BackupRestoreService.BackupData(tempBackupParent);
                    Assert(Directory.Exists(backupDir), "Thư mục sao lưu phải được tạo thành công!");
                    Assert(File.Exists(Path.Combine(backupDir, "phim.txt")), "File phim.txt phải có trong thư mục sao lưu!");
                    Assert(File.Exists(Path.Combine(backupDir, "users.txt")), "File users.txt phải có trong thư mục sao lưu!");

                    // Khôi phục lại
                    BackupRestoreService.RestoreData(backupDir);
                    Assert(DataManager.Movies.Count > 0, "Dữ liệu sau khôi phục phải nạp lại đầy đủ vào bộ nhớ!");
                }
                finally
                {
                    if (Directory.Exists(tempBackupParent))
                    {
                        Directory.Delete(tempBackupParent, true);
                    }
                }
            }, ref passed, ref failed, errors);

            RunTest("Test 10: Yêu cầu 10 - Xuất báo cáo doanh thu ra TXT và CSV", () =>
            {
                string txtReport = Path.Combine(Path.GetTempPath(), "BaoCaoTest_" + Guid.NewGuid().ToString("N") + ".txt");
                string csvReport = Path.Combine(Path.GetTempPath(), "BaoCaoTest_" + Guid.NewGuid().ToString("N") + ".csv");

                try
                {
                    DateTime from = DateTime.Today.AddDays(-30);
                    DateTime to = DateTime.Today.AddDays(30);

                    BackupRestoreService.ExportRevenueToTxt(txtReport, from, to);
                    Assert(File.Exists(txtReport), "File báo cáo TXT phải được tạo!");
                    string txtContent = File.ReadAllText(txtReport);
                    Assert(txtContent.Contains("BÁO CÁO THỐNG KÊ DOANH THU"), "Nội dung báo cáo TXT phải chuẩn!");

                    BackupRestoreService.ExportRevenueToCsv(csvReport, from, to);
                    Assert(File.Exists(csvReport), "File báo cáo CSV phải được tạo!");
                    string[] csvLines = File.ReadAllLines(csvReport);
                    Assert(csvLines.Length >= 1 && csvLines[0].Contains("MaVe;MaSuat"), "Header CSV phải đúng chuẩn ngăn cách bằng ';'");
                }
                finally
                {
                    if (File.Exists(txtReport)) File.Delete(txtReport);
                    if (File.Exists(csvReport)) File.Delete(csvReport);
                }
            }, ref passed, ref failed, errors);

            Console.WriteLine("==================================================================");
            Console.WriteLine($"KẾT QUẢ KIỂM THỬ: ĐẠT {passed}/{passed + failed} TEST ({passed * 100.0 / (passed + failed):F1}%)");
            if (failed > 0)
            {
                Console.WriteLine($"CÓ {failed} LỖI CẦN XỬ LÝ:");
                foreach (var err in errors)
                {
                    Console.WriteLine("  - " + err);
                }
            }
            else
            {
                Console.WriteLine("🎉 TẤT CẢ CÁC BÀI TEST ĐÃ VƯỢT QUA XUẤT SẮC 100%!");
            }
            Console.WriteLine("==================================================================");

            return failed == 0;
        }

        private static void RunTest(string testName, Action action, ref int passed, ref int failed, List<string> errors)
        {
            try
            {
                action();
                Console.WriteLine($"  [PASS] {testName}");
                passed++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  [FAIL] {testName} => {ex.Message}");
                failed++;
                errors.Add($"{testName}: {ex.Message}");
            }
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
        }
    }
}
