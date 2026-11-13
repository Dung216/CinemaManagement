using System.Text;
using CinemaManagement.Models;

namespace CinemaManagement.Services
{
    public static class BackupRestoreService
    {
        public static string BackupData(string targetParentFolder)
        {
            try
            {
                string sourceDir = DataManager.GetDataDirectory();
                if (!Directory.Exists(sourceDir))
                {
                    throw new DirectoryNotFoundException("Thư mục dữ liệu nguồn không tồn tại!");
                }

                string backupFolderName = $"Backup_CinemaData_{DateTime.Now:yyyyMMdd_HHmmss}";
                string backupDir = Path.Combine(targetParentFolder, backupFolderName);
                Directory.CreateDirectory(backupDir);

                foreach (string file in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
                {
                    string relativePath = Path.GetRelativePath(sourceDir, file);
                    string destFile = Path.Combine(backupDir, relativePath);
                    string? destSubDir = Path.GetDirectoryName(destFile);
                    if (!string.IsNullOrEmpty(destSubDir) && !Directory.Exists(destSubDir))
                    {
                        Directory.CreateDirectory(destSubDir);
                    }

                    // Sử dụng FileStream để sao lưu
                    using var sourceStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    using var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write);
                    sourceStream.CopyTo(destStream);
                }

                Logger.Log($"Sao lưu dữ liệu thành công tới: {backupDir}");
                return backupDir;
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi sao lưu dữ liệu: {ex.Message}", ex);
                throw;
            }
        }

        public static void RestoreData(string backupFolder)
        {
            try
            {
                if (!Directory.Exists(backupFolder))
                {
                    throw new DirectoryNotFoundException("Thư mục sao lưu không tồn tại!");
                }

                string destDir = DataManager.GetDataDirectory();
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                foreach (string file in Directory.GetFiles(backupFolder, "*.*", SearchOption.AllDirectories))
                {
                    string relativePath = Path.GetRelativePath(backupFolder, file);
                    string destFile = Path.Combine(destDir, relativePath);
                    string? destSubDir = Path.GetDirectoryName(destFile);
                    if (!string.IsNullOrEmpty(destSubDir) && !Directory.Exists(destSubDir))
                    {
                        Directory.CreateDirectory(destSubDir);
                    }

                    // Dùng File.Copy để khôi phục
                    File.Copy(file, destFile, true);
                }

                // Tải lại dữ liệu vào bộ nhớ List<T>
                DataManager.LoadAll();
                Logger.Log($"Khôi phục dữ liệu thành công từ: {backupFolder}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi khôi phục dữ liệu: {ex.Message}", ex);
                throw;
            }
        }

        public static void ExportRevenueToTxt(string filePath, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var tickets = DataManager.Tickets
                    .Where(t => t.SaleTime.Date >= fromDate.Date && t.SaleTime.Date <= toDate.Date)
                    .ToList();

                var sb = new StringBuilder();
                sb.AppendLine("==================================================================================");
                sb.AppendLine($"           {ConfigManager.CinemaName.ToUpper()}");
                sb.AppendLine($"          {ConfigManager.CinemaAddress} - Hotline: {ConfigManager.CinemaHotline}");
                sb.AppendLine("                       BÁO CÁO THỐNG KÊ DOANH THU BÁN VÉ");
                sb.AppendLine($"            Từ ngày: {fromDate:dd/MM/yyyy}  -  Đến ngày: {toDate:dd/MM/yyyy}");
                sb.AppendLine($"            Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine($"            Người lập: {DataManager.CurrentUser?.FullName ?? "Hệ thống"}");
                sb.AppendLine("==================================================================================");
                sb.AppendLine();

                // 1. Thống kê theo phim
                sb.AppendLine("I. THỐNG KÊ DOANH THU THEO PHIM:");
                sb.AppendLine(string.Format("{0,-8} | {1,-35} | {2,10} | {3,18}", "Mã Phim", "Tên Phim", "Số Vé", "Doanh Thu (VNĐ)"));
                sb.AppendLine(new string('-', 82));

                var movieGroups = tickets
                    .GroupBy(t =>
                    {
                        var showtime = DataManager.GetShowtimeById(t.ShowtimeId);
                        return showtime?.MovieId ?? "Khác";
                    })
                    .Select(g => new
                    {
                        MovieId = g.Key,
                        MovieTitle = DataManager.GetMovieById(g.Key)?.Title ?? "Không xác định",
                        TicketCount = g.Count(),
                        Revenue = g.Sum(x => x.Price)
                    })
                    .OrderByDescending(x => x.Revenue);

                foreach (var mg in movieGroups)
                {
                    string title = mg.MovieTitle.Length > 34 ? mg.MovieTitle.Substring(0, 31) + "..." : mg.MovieTitle;
                    sb.AppendLine(string.Format("{0,-8} | {1,-35} | {2,10:N0} | {3,18:N0}", mg.MovieId, title, mg.TicketCount, mg.Revenue));
                }

                sb.AppendLine(new string('-', 82));
                sb.AppendLine();

                // 2. Thống kê theo ngày
                sb.AppendLine("II. THỐNG KÊ DOANH THU THEO NGÀY:");
                sb.AppendLine(string.Format("{0,-15} | {1,15} | {2,20}", "Ngày", "Số Vé Bán Ra", "Doanh Thu (VNĐ)"));
                sb.AppendLine(new string('-', 56));

                var dateGroups = tickets
                    .GroupBy(t => t.SaleTime.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        TicketCount = g.Count(),
                        Revenue = g.Sum(x => x.Price)
                    })
                    .OrderBy(x => x.Date);

                foreach (var dg in dateGroups)
                {
                    sb.AppendLine(string.Format("{0,-15:dd/MM/yyyy} | {1,15:N0} | {2,20:N0}", dg.Date, dg.TicketCount, dg.Revenue));
                }

                sb.AppendLine(new string('-', 56));
                sb.AppendLine();

                // Tổng kết chung
                decimal totalRevenue = tickets.Sum(t => t.Price);
                int totalTickets = tickets.Count;
                sb.AppendLine("==================================================================================");
                sb.AppendLine($"TỔNG SỐ VÉ ĐÃ BÁN : {totalTickets:N0} vé");
                sb.AppendLine($"TỔNG DOANH THU    : {totalRevenue:N0} VNĐ");
                sb.AppendLine("==================================================================================");
                sb.AppendLine();
                sb.AppendLine("                                               Người lập báo cáo");
                sb.AppendLine("                                              (Ký và ghi rõ họ tên)");

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                Logger.Log($"Xuất báo cáo doanh thu ra TXT thành công: {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi xuất báo cáo doanh thu ra TXT: {ex.Message}", ex);
                throw;
            }
        }

        public static void ExportRevenueToCsv(string filePath, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var tickets = DataManager.Tickets
                    .Where(t => t.SaleTime.Date >= fromDate.Date && t.SaleTime.Date <= toDate.Date)
                    .OrderBy(t => t.SaleTime)
                    .ToList();

                using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
                writer.WriteLine("MaVe;MaSuat;TenPhim;PhongChieu;Ghe;LoaiVe;GiaBan;NgayBan;Combo");

                foreach (var t in tickets)
                {
                    var showtime = DataManager.GetShowtimeById(t.ShowtimeId);
                    var movie = showtime != null ? DataManager.GetMovieById(showtime.MovieId) : null;
                    var room = showtime != null ? DataManager.GetRoomById(showtime.RoomId) : null;

                    string movieTitle = movie?.Title ?? "N/A";
                    string roomName = room?.Name ?? "N/A";

                    writer.WriteLine($"{t.Id};{t.ShowtimeId};{movieTitle};{roomName};{t.SeatCode};{t.TicketType};{t.Price};{t.SaleTime:yyyy-MM-dd HH:mm};{t.ComboDetails}");
                }

                Logger.Log($"Xuất báo cáo doanh thu ra CSV thành công: {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi xuất báo cáo doanh thu ra CSV: {ex.Message}", ex);
                throw;
            }
        }
    }
}
