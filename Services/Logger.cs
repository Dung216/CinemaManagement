using System.Text;

namespace CinemaManagement.Services
{
    public static class Logger
    {
        private static readonly object _lock = new object();
        private static readonly string _logFilePath;

        static Logger()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                _logFilePath = Path.Combine(baseDir, "log.txt");
            }
            catch
            {
                _logFilePath = "log.txt";
            }
        }

        public static void Log(string message, Exception? ex = null)
        {
            try
            {
                lock (_lock)
                {
                    var sb = new StringBuilder();
                    sb.Append($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
                    if (ex != null)
                    {
                        sb.AppendLine();
                        sb.Append($"  Exception: {ex.GetType().FullName}: {ex.Message}");
                        if (!string.IsNullOrEmpty(ex.StackTrace))
                        {
                            sb.AppendLine();
                            sb.Append($"  StackTrace: {ex.StackTrace}");
                        }
                    }
                    sb.AppendLine();

                    File.AppendAllText(_logFilePath, sb.ToString(), Encoding.UTF8);
                }
            }
            catch
            {
                // Không bao giờ để lỗi ghi log làm sập ứng dụng
            }
        }

        public static string GetLogPath() => _logFilePath;
    }
}
