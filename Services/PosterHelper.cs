using System.Drawing.Drawing2D;
using CinemaManagement.Models;

namespace CinemaManagement.Services
{
    public static class PosterHelper
    {
        private static readonly Dictionary<string, Image> _cache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

        public static Image GetPoster(Movie movie, int width = 140, int height = 200)
        {
            string cacheKey = $"{movie.Id}_{width}x{height}";
            if (_cache.TryGetValue(cacheKey, out var cachedImg))
            {
                return cachedImg;
            }

            // Kiểm tra xem có file ảnh thực tế trên ổ đĩa không
            string? realPath = FindPosterFile(movie.Poster);
            if (!string.IsNullOrEmpty(realPath) && File.Exists(realPath))
            {
                try
                {
                    using var stream = new FileStream(realPath, FileMode.Open, FileAccess.Read);
                    using var original = Image.FromStream(stream);
                    var resized = new Bitmap(width, height);
                    using (var g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, width, height);
                    }
                    _cache[cacheKey] = resized;
                    return resized;
                }
                catch (Exception ex)
                {
                    Logger.Log($"Lỗi nạp file poster '{movie.Poster}': {ex.Message}", ex);
                }
            }

            // Nếu không có file thực tế hoặc lỗi, tự động vẽ Poster đồ họa đẹp mắt
            var generatedPoster = GeneratePosterBitmap(movie, width, height);
            _cache[cacheKey] = generatedPoster;
            return generatedPoster;
        }

        private static string? FindPosterFile(string posterFileName)
        {
            if (string.IsNullOrWhiteSpace(posterFileName)) return null;
            if (File.Exists(posterFileName)) return posterFileName;

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string p1 = Path.Combine(baseDir, ConfigManager.DataDirectory, "Posters", posterFileName);
            if (File.Exists(p1)) return p1;

            string p2 = Path.Combine(baseDir, "Posters", posterFileName);
            if (File.Exists(p2)) return p2;

            return null;
        }

        public static Bitmap GeneratePosterBitmap(Movie movie, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Chọn màu gradient dựa trên mã phim
                int hash = Math.Abs(movie.Id.GetHashCode());
                Color[] colorPairs = new[]
                {
                    Color.FromArgb(20, 30, 48), Color.FromArgb(36, 59, 85),
                    Color.FromArgb(15, 32, 39), Color.FromArgb(44, 83, 100),
                    Color.FromArgb(43, 88, 118), Color.FromArgb(78, 67, 118),
                    Color.FromArgb(75, 19, 79), Color.FromArgb(201, 75, 75),
                    Color.FromArgb(30, 60, 114), Color.FromArgb(42, 82, 152),
                    Color.FromArgb(40, 62, 81), Color.FromArgb(0, 0, 0)
                };
                int idx = (hash % (colorPairs.Length / 2)) * 2;
                Color c1 = colorPairs[idx];
                Color c2 = colorPairs[idx + 1];

                using (var brush = new LinearGradientBrush(new Rectangle(0, 0, width, height), c1, c2, 45f))
                {
                    g.FillRectangle(brush, 0, 0, width, height);
                }

                // Vẽ viền
                using (var pen = new Pen(Color.FromArgb(100, 255, 255, 255), 2))
                {
                    g.DrawRectangle(pen, 2, 2, width - 4, height - 4);
                }

                // Huy hiệu giới hạn độ tuổi ở góc trên bên phải
                Color badgeColor = movie.AgeRating switch
                {
                    "P" => Color.FromArgb(40, 167, 69),      // Xanh lá (Phổ thông)
                    "K" => Color.FromArgb(23, 162, 184),     // Xanh ngọc (Dưới 13 tuổi có bảo trợ)
                    "T13" => Color.FromArgb(255, 193, 7),    // Vàng cam
                    "T16" => Color.FromArgb(253, 126, 20),   // Cam đậm
                    "T18" => Color.FromArgb(220, 53, 69),    // Đỏ (18+)
                    _ => Color.Gray
                };

                using (var badgeBrush = new SolidBrush(badgeColor))
                {
                    g.FillRectangle(badgeBrush, width - 42, 8, 34, 20);
                }
                using (var textBrush = new SolidBrush(Color.White))
                using (var badgeFont = new Font("Segoe UI", 8, FontStyle.Bold))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(movie.AgeRating, badgeFont, textBrush, new RectangleF(width - 42, 8, 34, 20), sf);
                }

                // Biểu tượng cuộn phim
                using (var iconFont = new Font("Segoe UI", 24, FontStyle.Bold))
                using (var iconBrush = new SolidBrush(Color.FromArgb(180, 255, 255, 255)))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("🎬", iconFont, iconBrush, new RectangleF(0, height / 4, width, 40), sf);
                }

                // Tên phim ở nửa dưới
                using (var titleFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                using (var titleBrush = new SolidBrush(Color.White))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    var titleRect = new RectangleF(6, height / 2, width - 12, height / 3);
                    g.DrawString(movie.Title, titleFont, titleBrush, titleRect, sf);
                }

                // Thể loại & thời lượng ở chân poster
                using (var infoFont = new Font("Segoe UI", 7.5f, FontStyle.Regular))
                using (var infoBrush = new SolidBrush(Color.FromArgb(220, 220, 220)))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far };
                    var infoRect = new RectangleF(4, height - 32, width - 8, 26);
                    string info = $"{movie.Duration} phút\n{movie.Genre}";
                    g.DrawString(info, infoFont, infoBrush, infoRect, sf);
                }
            }
            return bmp;
        }

        public static void ClearCache()
        {
            foreach (var img in _cache.Values)
            {
                img.Dispose();
            }
            _cache.Clear();
        }
    }
}
