using System.Text;
using CinemaManagement.Models;

namespace CinemaManagement.Services
{
    public static class DataManager
    {
        // Danh sách đối tượng nghiệp vụ quản lý trong bộ nhớ bằng List<T>
        public static List<User> Users { get; private set; } = new List<User>();
        public static List<Movie> Movies { get; private set; } = new List<Movie>();
        public static List<Room> Rooms { get; private set; } = new List<Room>();
        public static List<Showtime> Showtimes { get; private set; } = new List<Showtime>();
        public static List<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public static List<SnackCombo> Combos { get; private set; } = new List<SnackCombo>();

        // Người dùng đang đăng nhập
        public static User? CurrentUser { get; set; }

        private static string _dataDirectory = string.Empty;

        public static string GetDataDirectory()
        {
            if (string.IsNullOrEmpty(_dataDirectory))
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string dirName = ConfigManager.DataDirectory;
                _dataDirectory = Path.Combine(baseDir, dirName);
            }
            return _dataDirectory;
        }

        public static void SetDataDirectory(string customPath)
        {
            _dataDirectory = customPath;
        }

        // Đường dẫn các tập tin dữ liệu chính
        public static string UsersFilePath => Path.Combine(GetDataDirectory(), "users.txt");
        public static string MoviesFilePath => Path.Combine(GetDataDirectory(), "phim.txt");
        public static string RoomsFilePath => Path.Combine(GetDataDirectory(), "phongchieu.txt");
        public static string ShowtimesFilePath => Path.Combine(GetDataDirectory(), "suatchieu.txt");
        public static string TicketsFilePath => Path.Combine(GetDataDirectory(), "ve.txt");
        public static string CombosFilePath => Path.Combine(GetDataDirectory(), "combos.txt");

        public static void Initialize()
        {
            EnsureDataFilesExist();
            LoadAll();
        }

        public static void EnsureDataFilesExist()
        {
            try
            {
                string dir = GetDataDirectory();
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                // 1. users.txt (tối thiểu 2 vai trò: Quản trị, Nhân viên)
                if (!File.Exists(UsersFilePath))
                {
                    var lines = new[]
                    {
                        "# Username;Password;FullName;Role;IsLocked;FailedAttempts",
                        "admin;admin123;Quản trị viên hệ thống;Admin;False;0",
                        "staff;staff123;Nguyễn Văn Bán Vé;Staff;False;0",
                        "thungan;thungan123;Trần Thị Thu Ngân;Staff;False;0"
                    };
                    File.WriteAllLines(UsersFilePath, lines, Encoding.UTF8);
                }

                // 2. phim.txt (tối thiểu >= 20 dòng dữ liệu mẫu theo yêu cầu số 2)
                if (!File.Exists(MoviesFilePath))
                {
                    var lines = new[]
                    {
                        "# Ma;Ten;TheLoai;ThoiLuong;GioiHanTuoi;Poster",
                        "P01;Mai;Tâm lý, Tình cảm;131;T18;mai.jpg",
                        "P02;Đào, Phở và Piano;Lịch sử, Chiến tranh;100;T13;dao_pho_piano.jpg",
                        "P03;Lật Mặt 7: Một Điều Ước;Gia đình, Tâm lý;138;K;lat_mat_7.jpg",
                        "P04;Dune: Part Two;Khoa học viễn tưởng;166;T16;dune_2.jpg",
                        "P05;Godzilla x Kong: The New Empire;Hành động, Viễn tưởng;115;K;godzilla_kong.jpg",
                        "P06;Kung Fu Panda 4;Hoạt hình, Hài hước;94;P;kungfu_panda_4.jpg",
                        "P07;Deadpool & Wolverine;Hành động, Siêu anh hùng;127;T18;deadpool_wolverine.jpg",
                        "P08;Inside Out 2;Hoạt hình, Gia đình;96;P;inside_out_2.jpg",
                        "P09;Kẻ Trộm Mặt Trời;Hành động, Kịch tính;110;T16;ke_trom_mat_troi.jpg",
                        "P10;Thám Tử Lừng Danh Conan: Ngôi Sao 5 Cánh;Hoạt hình, Trinh thám;110;K;conan_27.jpg",
                        "P11;Doraemon: Bản Giao Hưởng Địa Cầu;Hoạt hình, Phiêu lưu;115;P;doraemon_symphony.jpg",
                        "P12;Oppenheimer;Lịch sử, Tiểu sử;180;T18;oppenheimer.jpg",
                        "P13;Interstellar;Khoa học viễn tưởng;169;T13;interstellar.jpg",
                        "P14;Avengers: Endgame;Hành động, Viễn tưởng;181;T13;avengers_endgame.jpg",
                        "P15;Spider-Man: No Way Home;Hành động, Phiêu lưu;148;T13;spiderman_nwh.jpg",
                        "P16;Avatar: The Way of Water;Khoa học viễn tưởng;192;T13;avatar_2.jpg",
                        "P17;Nhà Bà Nữ;Tâm lý, Gia đình;102;T16;nha_ba_nu.jpg",
                        "P18;Bố Già;Gia đình, Hài hước;128;P;bo_gia.jpg",
                        "P19;Mắt Biếc;Tình cảm, Lãng mạn;117;T16;mat_biec.jpg",
                        "P20;Tôi Thấy Hoa Vàng Trên Cỏ Xanh;Tâm lý, Tuổi thơ;103;P;hoa_vang_co_xanh.jpg",
                        "P21;Em Chưa 18;Hài, Lãng mạn;95;T16;em_chua_18.jpg",
                        "P22;Hai Phượng;Hành động;98;T18;hai_phuong.jpg",
                        "P23;Gặp Lại Chị Bầu;Hài, Tình cảm;114;T13;gap_lai_chi_bau.jpg",
                        "P24;Cám;Kinh dị;122;T18;cam.jpg",
                        "P25;Ma Da;Kinh dị, Hồi hộp;96;T16;ma_da.jpg"
                    };
                    File.WriteAllLines(MoviesFilePath, lines, Encoding.UTF8);
                }

                // 3. phongchieu.txt (3-5 phòng chiếu)
                if (!File.Exists(RoomsFilePath))
                {
                    var lines = new[]
                    {
                        "# Ma;Ten;SoHang;SoGheMoiHang;HangVIP",
                        "PC01;Phòng Chiếu 1 (Standard);6;8;C,D",
                        "PC02;Phòng Chiếu 2 (IMAX);7;10;D,E",
                        "PC03;Phòng Chiếu 3 (Gold Class VIP);5;8;B,C,D",
                        "PC04;Phòng Chiếu 4 (Standard);6;8;C,D",
                        "PC05;Phòng Chiếu 5 (3D Digital);8;10;D,E,F"
                    };
                    File.WriteAllLines(RoomsFilePath, lines, Encoding.UTF8);
                }

                // 4. suatchieu.txt (lịch chiếu phân bổ các ngày)
                if (!File.Exists(ShowtimesFilePath))
                {
                    DateTime today = DateTime.Today;
                    var lines = new[]
                    {
                        "# Ma;MaPhim;MaPhong;NgayGio;GiaVe",
                        $"SC01;P01;PC01;{today:yyyy-MM-dd} 09:00;80000",
                        $"SC02;P01;PC01;{today:yyyy-MM-dd} 13:00;85000",
                        $"SC03;P02;PC02;{today:yyyy-MM-dd} 10:00;90000",
                        $"SC04;P03;PC03;{today:yyyy-MM-dd} 14:30;120000",
                        $"SC05;P04;PC01;{today:yyyy-MM-dd} 16:30;85000",
                        $"SC06;P05;PC02;{today:yyyy-MM-dd} 15:00;95000",
                        $"SC07;P06;PC04;{today:yyyy-MM-dd} 10:30;75000",
                        $"SC08;P08;PC05;{today:yyyy-MM-dd} 11:00;80000",
                        $"SC09;P02;PC01;{today.AddDays(1):yyyy-MM-dd} 09:30;85000",
                        $"SC10;P03;PC02;{today.AddDays(1):yyyy-MM-dd} 13:00;90000",
                        $"SC11;P07;PC03;{today.AddDays(1):yyyy-MM-dd} 15:30;120000",
                        $"SC12;P10;PC04;{today.AddDays(1):yyyy-MM-dd} 10:00;80000",
                        $"SC13;P14;PC05;{today.AddDays(1):yyyy-MM-dd} 18:00;100000",
                        $"SC14;P01;PC01;{today.AddDays(2):yyyy-MM-dd} 14:00;85000",
                        $"SC15;P04;PC02;{today.AddDays(2):yyyy-MM-dd} 16:30;95000"
                    };
                    File.WriteAllLines(ShowtimesFilePath, lines, Encoding.UTF8);
                }

                // 5. ve.txt (vé đã bán mẫu)
                if (!File.Exists(TicketsFilePath))
                {
                    DateTime today = DateTime.Today;
                    var lines = new[]
                    {
                        "# Ma;MaSuat;Ghe;LoaiVe;GiaBan;NgayBan;ComboDetails",
                        $"VE001;SC01;A1;Người lớn;80000;{today:yyyy-MM-dd} 08:15;Combo Solo: 1",
                        $"VE002;SC01;A2;Người lớn;80000;{today:yyyy-MM-dd} 08:15;Combo Solo: 1",
                        $"VE003;SC01;C3;Người lớn;95000;{today:yyyy-MM-dd} 08:20;",
                        $"VE004;SC01;C4;Học sinh - Sinh viên;76000;{today:yyyy-MM-dd} 08:22;",
                        $"VE005;SC02;B3;Người lớn;85000;{today:yyyy-MM-dd} 09:10;Combo Couple: 1",
                        $"VE006;SC02;B4;Người lớn;85000;{today:yyyy-MM-dd} 09:10;Combo Couple: 1",
                        $"VE007;SC03;D5;Người lớn;105000;{today:yyyy-MM-dd} 09:20;",
                        $"VE008;SC03;D6;Học sinh - Sinh viên;84000;{today:yyyy-MM-dd} 09:20;"
                    };
                    File.WriteAllLines(TicketsFilePath, lines, Encoding.UTF8);
                }

                // 6. combos.txt (Combo bắp nước - Điểm cộng nâng cao)
                if (!File.Exists(CombosFilePath))
                {
                    var lines = new[]
                    {
                        "# Ma;Ten;Gia;MoTa",
                        "CB01;Combo Solo (1 Bắp + 1 Nước);50000;1 Bắp ngọt vừa + 1 Nước ngọt 22oz",
                        "CB02;Combo Couple (1 Bắp Lớn + 2 Nước);80000;1 Bắp lớn 2 vị + 2 Nước ngọt 32oz",
                        "CB03;Combo Party (2 Bắp + 4 Nước + 1 Snack);150000;2 Bắp khổng lồ + 4 Nước + 1 Khoai tây chiên"
                    };
                    File.WriteAllLines(CombosFilePath, lines, Encoding.UTF8);
                }

                // Tạo tập tin CSV mẫu để kiểm tra tính năng Import phim (SV1)
                string sampleCsvDir = Path.Combine(dir, "SampleData");
                if (!Directory.Exists(sampleCsvDir)) Directory.CreateDirectory(sampleCsvDir);
                string sampleCsv = Path.Combine(sampleCsvDir, "import_phim_mau.csv");
                if (!File.Exists(sampleCsv))
                {
                    var csvLines = new[]
                    {
                        "Ma;Ten;TheLoai;ThoiLuong;GioiHanTuoi;Poster",
                        "P26;Transformers: One;Hoạt hình, Hành động;104;P;transformers_one.jpg",
                        "P27;Joker: Folie a Deux;Tâm lý, Giật gân;138;T18;joker_2.jpg",
                        "P28;Venom: The Last Dance;Hành động, Viễn tưởng;110;T16;venom_3.jpg",
                        "P29;Moana 2;Hoạt hình, Âm nhạc;100;P;moana_2.jpg",
                        "P30;Sonic the Hedgehog 3;Phiêu lưu, Gia đình;110;P;sonic_3.jpg"
                    };
                    File.WriteAllLines(sampleCsv, csvLines, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi khởi tạo tập tin dữ liệu mẫu: {ex.Message}", ex);
            }
        }

        #region Đọc dữ liệu (StreamReader)
        public static void LoadAll()
        {
            LoadUsers();
            LoadMovies();
            LoadRooms();
            LoadShowtimes();
            LoadTickets();
            LoadCombos();
        }

        public static void LoadUsers()
        {
            Users.Clear();
            if (!File.Exists(UsersFilePath)) return;
            try
            {
                using var reader = new StreamReader(UsersFilePath, Encoding.UTF8);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;
                    try
                    {
                        var user = User.FromDataLine(line);
                        if (user != null) Users.Add(user);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Lỗi định dạng dòng trong users.txt: '{line}' - {ex.Message}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc tập tin users.txt: {ex.Message}", ex);
            }
        }

        public static void LoadMovies()
        {
            Movies.Clear();
            if (!File.Exists(MoviesFilePath)) return;
            try
            {
                using var reader = new StreamReader(MoviesFilePath, Encoding.UTF8);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;
                    try
                    {
                        var movie = Movie.FromDataLine(line);
                        if (movie != null) Movies.Add(movie);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Lỗi định dạng dòng trong phim.txt: '{line}' - {ex.Message}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc tập tin phim.txt: {ex.Message}", ex);
            }
        }

        public static void LoadRooms()
        {
            Rooms.Clear();
            if (!File.Exists(RoomsFilePath)) return;
            try
            {
                using var reader = new StreamReader(RoomsFilePath, Encoding.UTF8);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;
                    try
                    {
                        var room = Room.FromDataLine(line);
                        if (room != null) Rooms.Add(room);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Lỗi định dạng dòng trong phongchieu.txt: '{line}' - {ex.Message}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc tập tin phongchieu.txt: {ex.Message}", ex);
            }
        }

        public static void LoadShowtimes()
        {
            Showtimes.Clear();
            if (!File.Exists(ShowtimesFilePath)) return;
            try
            {
                using var reader = new StreamReader(ShowtimesFilePath, Encoding.UTF8);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;
                    try
                    {
                        var showtime = Showtime.FromDataLine(line);
                        if (showtime != null) Showtimes.Add(showtime);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Lỗi định dạng dòng trong suatchieu.txt: '{line}' - {ex.Message}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc tập tin suatchieu.txt: {ex.Message}", ex);
            }
        }

        public static void LoadTickets()
        {
            Tickets.Clear();
            if (!File.Exists(TicketsFilePath)) return;
            try
            {
                using var reader = new StreamReader(TicketsFilePath, Encoding.UTF8);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;
                    try
                    {
                        var ticket = Ticket.FromDataLine(line);
                        if (ticket != null) Tickets.Add(ticket);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Lỗi định dạng dòng trong ve.txt: '{line}' - {ex.Message}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc tập tin ve.txt: {ex.Message}", ex);
            }
        }

        public static void LoadCombos()
        {
            Combos.Clear();
            if (!File.Exists(CombosFilePath)) return;
            try
            {
                using var reader = new StreamReader(CombosFilePath, Encoding.UTF8);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;
                    try
                    {
                        var combo = SnackCombo.FromDataLine(line);
                        if (combo != null) Combos.Add(combo);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Lỗi định dạng dòng trong combos.txt: '{line}' - {ex.Message}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc tập tin combos.txt: {ex.Message}", ex);
            }
        }
        #endregion

        #region Ghi dữ liệu (StreamWriter)
        public static void SaveAll()
        {
            SaveUsers();
            SaveMovies();
            SaveRooms();
            SaveShowtimes();
            SaveTickets();
            SaveCombos();
        }

        public static void SaveUsers()
        {
            try
            {
                using var writer = new StreamWriter(UsersFilePath, false, Encoding.UTF8);
                writer.WriteLine("# Username;Password;FullName;Role;IsLocked;FailedAttempts");
                foreach (var u in Users)
                {
                    writer.WriteLine(u.ToDataLine());
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi tập tin users.txt: {ex.Message}", ex);
                throw;
            }
        }

        public static void SaveMovies()
        {
            try
            {
                using var writer = new StreamWriter(MoviesFilePath, false, Encoding.UTF8);
                writer.WriteLine("# Ma;Ten;TheLoai;ThoiLuong;GioiHanTuoi;Poster");
                foreach (var m in Movies)
                {
                    writer.WriteLine(m.ToDataLine());
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi tập tin phim.txt: {ex.Message}", ex);
                throw;
            }
        }

        public static void SaveRooms()
        {
            try
            {
                using var writer = new StreamWriter(RoomsFilePath, false, Encoding.UTF8);
                writer.WriteLine("# Ma;Ten;SoHang;SoGheMoiHang;HangVIP");
                foreach (var r in Rooms)
                {
                    writer.WriteLine(r.ToDataLine());
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi tập tin phongchieu.txt: {ex.Message}", ex);
                throw;
            }
        }

        public static void SaveShowtimes()
        {
            try
            {
                using var writer = new StreamWriter(ShowtimesFilePath, false, Encoding.UTF8);
                writer.WriteLine("# Ma;MaPhim;MaPhong;NgayGio;GiaVe");
                foreach (var s in Showtimes)
                {
                    writer.WriteLine(s.ToDataLine());
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi tập tin suatchieu.txt: {ex.Message}", ex);
                throw;
            }
        }

        public static void SaveTickets()
        {
            try
            {
                using var writer = new StreamWriter(TicketsFilePath, false, Encoding.UTF8);
                writer.WriteLine("# Ma;MaSuat;Ghe;LoaiVe;GiaBan;NgayBan;ComboDetails");
                foreach (var t in Tickets)
                {
                    writer.WriteLine(t.ToDataLine());
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi tập tin ve.txt: {ex.Message}", ex);
                throw;
            }
        }

        public static void SaveCombos()
        {
            try
            {
                using var writer = new StreamWriter(CombosFilePath, false, Encoding.UTF8);
                writer.WriteLine("# Ma;Ten;Gia;MoTa");
                foreach (var c in Combos)
                {
                    writer.WriteLine(c.ToDataLine());
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi tập tin combos.txt: {ex.Message}", ex);
                throw;
            }
        }
        #endregion

        #region Nghiệp vụ & Tra cứu
        public static Movie? GetMovieById(string id) => Movies.FirstOrDefault(m => m.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        public static Room? GetRoomById(string id) => Rooms.FirstOrDefault(r => r.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        public static Showtime? GetShowtimeById(string id) => Showtimes.FirstOrDefault(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        public static List<Ticket> GetTicketsForShowtime(string showtimeId)
        {
            return Tickets.Where(t => t.ShowtimeId.Equals(showtimeId, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static bool HasSoldTickets(string showtimeId)
        {
            return Tickets.Any(t => t.ShowtimeId.Equals(showtimeId, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Thuật toán kiểm tra không cho hai suất chồng giờ trong cùng phòng
        /// (tính theo thời lượng phim + thời gian dọn phòng từ App.config)
        /// </summary>
        public static bool ValidateShowtimeConflict(Showtime newShowtime, out string conflictMessage)
        {
            conflictMessage = string.Empty;

            var movie = GetMovieById(newShowtime.MovieId);
            if (movie == null)
            {
                conflictMessage = "Phim không tồn tại trong hệ thống!";
                return false;
            }

            var room = GetRoomById(newShowtime.RoomId);
            if (room == null)
            {
                conflictMessage = "Phòng chiếu không tồn tại trong hệ thống!";
                return false;
            }

            int cleaningMins = ConfigManager.CleaningTimeMinutes;
            DateTime newStart = newShowtime.StartTime;
            DateTime newEnd = newStart.AddMinutes(movie.Duration + cleaningMins);

            // Kiểm tra các suất chiếu khác trong cùng phòng chiếu
            foreach (var exist in Showtimes)
            {
                // Bỏ qua chính nó khi sửa
                if (exist.Id.Equals(newShowtime.Id, StringComparison.OrdinalIgnoreCase))
                    continue;

                // Chỉ kiểm tra suất chiếu trong cùng phòng
                if (!exist.RoomId.Equals(newShowtime.RoomId, StringComparison.OrdinalIgnoreCase))
                    continue;

                var existMovie = GetMovieById(exist.MovieId);
                int existDuration = existMovie?.Duration ?? 90;
                DateTime existStart = exist.StartTime;
                DateTime existEnd = existStart.AddMinutes(existDuration + cleaningMins);

                // Hai khoảng thời gian [newStart, newEnd] và [existStart, existEnd] giao nhau
                // nếu max(newStart, existStart) < min(newEnd, existEnd)
                DateTime overlapStart = newStart > existStart ? newStart : existStart;
                DateTime overlapEnd = newEnd < existEnd ? newEnd : existEnd;

                if (overlapStart < overlapEnd)
                {
                    conflictMessage = $"Xung đột lịch chiếu tại {room.Name}!\n" +
                        $"Suất chiếu mới ({newStart:HH:mm} - {newEnd:HH:mm}, gồm {cleaningMins}p dọn phòng) trùng giờ với suất chiếu " +
                        $"'{existMovie?.Title}' ({existStart:HH:mm} - {existEnd:HH:mm}).";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Quy tắc trả vé: Trước giờ chiếu ít nhất 1 tiếng (hoặc theo cấu hình RefundTimeLimitMinutes)
        /// </summary>
        public static bool CheckTicketRefundable(string ticketId, out Ticket? ticket, out Showtime? showtime, out string message)
        {
            ticket = Tickets.FirstOrDefault(t => t.Id.Equals(ticketId, StringComparison.OrdinalIgnoreCase));
            showtime = null;

            if (ticket == null)
            {
                message = $"Không tìm thấy vé có mã '{ticketId}'!";
                return false;
            }

            showtime = GetShowtimeById(ticket.ShowtimeId);
            if (showtime == null)
            {
                message = "Không tìm thấy thông tin suất chiếu gắn với vé này!";
                return false;
            }

            int limitMins = ConfigManager.RefundTimeLimitMinutes;
            TimeSpan timeRemaining = showtime.StartTime - DateTime.Now;

            if (timeRemaining.TotalMinutes < limitMins)
            {
                if (timeRemaining.TotalMinutes <= 0)
                {
                    message = $"Không thể trả vé! Suất chiếu đã bắt đầu/kết thúc lúc {showtime.StartTime:dd/MM/yyyy HH:mm}.";
                }
                else
                {
                    message = $"Không thể trả vé! Suất chiếu sẽ bắt đầu sau {timeRemaining.TotalMinutes:N0} phút.\n" +
                              $"(Quy định: Chỉ được trả vé trước giờ chiếu ít nhất {limitMins} phút).";
                }
                return false;
            }

            message = $"Vé hợp lệ để trả. Số tiền hoàn lại: {ticket.Price:N0} VNĐ.";
            return true;
        }
        #endregion
    }
}
