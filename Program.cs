using System.Runtime.InteropServices;
using CinemaManagement.Forms;
using CinemaManagement.Services;
using CinemaManagement.Tests;

namespace CinemaManagement
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// Điểm khởi động chính của ứng dụng Windows Forms
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Kiểm tra xem có yêu cầu chạy kiểm thử tự động không (--test)
            if (args.Length > 0 && (args[0].Equals("--test", StringComparison.OrdinalIgnoreCase) ||
                                    args[0].Equals("/test", StringComparison.OrdinalIgnoreCase)))
            {
                AttachConsole(ATTACH_PARENT_PROCESS);

                bool allPassed = AppTests.RunAllTests(out int passed, out int failed, out var errors);

                // Ghi kết quả test ra tập tin test_results.log
                string testLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_results.log");
                var sb = new System.Text.StringBuilder();
                sb.AppendLine($"Thời gian kiểm thử: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                sb.AppendLine($"Kết quả: {(allPassed ? "THÀNH CÔNG 100%" : "THẤT BẠI")}");
                sb.AppendLine($"Đạt: {passed}, Thất bại: {failed}");
                if (errors.Count > 0)
                {
                    sb.AppendLine("Chi tiết lỗi:");
                    foreach (var err in errors) sb.AppendLine($" - {err}");
                }
                File.WriteAllText(testLog, sb.ToString());

                Environment.Exit(allPassed ? 0 : 1);
                return;
            }

            // Khởi động giao diện người dùng chuẩn
            ApplicationConfiguration.Initialize();

            try
            {
                // Khởi tạo và nạp dữ liệu từ các tập tin .txt trong thư mục Data (Yêu cầu 2)
                DataManager.Initialize();
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi khởi tạo dữ liệu ứng dụng: {ex.Message}", ex);
                MessageBox.Show($"Lỗi khởi tạo dữ liệu ban đầu: {ex.Message}\nChương trình sẽ cố gắng tiếp tục.",
                                "Cảnh báo khởi động", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Hiển thị màn hình đăng nhập (Yêu cầu 9)
            using var loginForm = new FormLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Sau khi đăng nhập thành công, khởi động Form chính MDI (Yêu cầu 5)
                Application.Run(new FormMain());
            }
        }
    }
}
