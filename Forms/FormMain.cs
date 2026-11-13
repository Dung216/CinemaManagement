using System.Diagnostics;
using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormMain : Form
    {
        private bool _isLoggingOut = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Khôi phục vị trí, kích thước và tùy chỉnh giao diện từ Registry (Yêu cầu 8)
                RestoreUserSettings();

                // Cập nhật thông tin thanh trạng thái
                statusCinema.Text = $"🏛️ {ConfigManager.CinemaName} - {ConfigManager.CinemaAddress}";
                UpdateUserStatus();

                // Phân quyền menu theo vai trò người dùng (Yêu cầu 9)
                ApplyRolePermissions();

                // Mở sẵn form bán vé làm màn hình chính
                OpenChildForm<FormTicketBooking>();
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi nạp FormMain: {ex.Message}", ex);
            }
        }

        private void RestoreUserSettings()
        {
            try
            {
                int x = RegistryHelper.WindowX;
                int y = RegistryHelper.WindowY;
                int w = RegistryHelper.WindowWidth;
                int h = RegistryHelper.WindowHeight;

                if (w >= 800 && h >= 600)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(Math.Max(0, x), Math.Max(0, y));
                    this.Size = new Size(w, h);
                }

                if (RegistryHelper.WindowState == 2)
                {
                    this.WindowState = FormWindowState.Maximized;
                }

                // Khôi phục Font từ Registry
                string fontName = RegistryHelper.FontFamilyName;
                float fontSize = RegistryHelper.FontSize;
                if (!string.IsNullOrEmpty(fontName))
                {
                    try
                    {
                        this.Font = new Font(fontName, fontSize > 0 ? fontSize : 9f);
                    }
                    catch { }
                }

                // Khôi phục Màu sắc chủ đạo từ Registry
                int colorArgb = RegistryHelper.ThemeColorArgb;
                if (colorArgb != 0)
                {
                    Color themeColor = Color.FromArgb(colorArgb);
                    menuStrip.BackColor = themeColor;
                    menuStrip.ForeColor = themeColor.GetBrightness() < 0.5 ? Color.White : Color.Black;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi khôi phục tùy chọn giao diện từ Registry: {ex.Message}", ex);
            }
        }

        private void SaveUserSettings()
        {
            try
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    RegistryHelper.WindowX = this.Left;
                    RegistryHelper.WindowY = this.Top;
                    RegistryHelper.WindowWidth = this.Width;
                    RegistryHelper.WindowHeight = this.Height;
                    RegistryHelper.WindowState = 0;
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    RegistryHelper.WindowState = 2;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi lưu thiết lập vào Registry: {ex.Message}", ex);
            }
        }

        public void UpdateUserStatus()
        {
            var user = DataManager.CurrentUser;
            if (user != null)
            {
                string roleText = user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) ? "Quản trị viên" : "Nhân viên quầy vé";
                statusUser.Text = $"👤 Người dùng: {user.FullName} ({roleText})";
                statusUser.ForeColor = user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(220, 53, 69) : Color.FromArgb(13, 110, 253);
            }
            else
            {
                statusUser.Text = "👤 Người dùng: Khách";
                statusUser.ForeColor = Color.Gray;
            }
        }

        // Tối thiểu 2 vai trò (quản trị, nhân viên) với menu khác nhau (Yêu cầu 9)
        public void ApplyRolePermissions()
        {
            var user = DataManager.CurrentUser;
            bool isAdmin = user != null && user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

            // Menu chỉ dành cho Quản trị viên
            menuUsers.Visible = isAdmin;
            menuBackup.Visible = isAdmin;
            menuRestore.Visible = isAdmin;

            if (!isAdmin)
            {
                menuUsers.Enabled = false;
                menuBackup.Enabled = false;
                menuRestore.Enabled = false;
            }
        }

        // Quản lý Form con không mở trùng (Yêu cầu 5)
        public T OpenChildForm<T>(Func<T>? factory = null) where T : Form
        {
            foreach (Form child in MdiChildren)
            {
                if (child is T existingForm)
                {
                    if (existingForm.WindowState == FormWindowState.Minimized)
                        existingForm.WindowState = FormWindowState.Normal;

                    existingForm.Activate();
                    existingForm.BringToFront();
                    return existingForm;
                }
            }

            T newForm = factory != null ? factory() : Activator.CreateInstance<T>();
            newForm.MdiParent = this;
            newForm.Show();
            return newForm;
        }

        public void OpenShowtimeWithMovie(string movieId)
        {
            var form = OpenChildForm<FormShowtimeManagement>();
            form.SelectMovie(movieId);
        }

        public void OpenTicketBookingWithShowtime(string showtimeId)
        {
            var form = OpenChildForm<FormTicketBooking>();
            form.SelectShowtimeById(showtimeId);
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            statusClock.Text = $"⏰ {DateTime.Now:HH:mm:ss  dd/MM/yyyy}";
        }

        #region Xử lý Menu Hệ Thống
        private void menuLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất tài khoản hiện tại không?",
                                          "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _isLoggingOut = true;
                CloseAllChildForms();

                Logger.Log($"Người dùng '{DataManager.CurrentUser?.Username}' đã đăng xuất.");
                DataManager.CurrentUser = null;

                using var loginForm = new FormLogin();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    _isLoggingOut = false;
                    UpdateUserStatus();
                    ApplyRolePermissions();
                    OpenChildForm<FormTicketBooking>();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void menuUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm<FormUserManagement>();
        }

        // Sao lưu thư mục dữ liệu (Yêu cầu 10)
        private void menuBackup_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog
            {
                Description = "Chọn thư mục lưu trữ bản sao lưu dữ liệu rạp chiếu phim"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string backupDir = BackupRestoreService.BackupData(fbd.SelectedPath);
                    MessageBox.Show($"Sao lưu toàn bộ dữ liệu thành công!\nThư mục sao lưu: {backupDir}",
                                    "Sao lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Logger.Log($"Lỗi sao lưu: {ex.Message}", ex);
                    MessageBox.Show($"Lỗi trong quá trình sao lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Khôi phục thư mục dữ liệu (Yêu cầu 10)
        private void menuRestore_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Khôi phục dữ liệu sẽ ghi đè lên dữ liệu hiện tại của hệ thống!\n" +
                                          "Bạn có chắc chắn muốn tiếp tục không?",
                                          "Cảnh báo khôi phục", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using var fbd = new FolderBrowserDialog
            {
                Description = "Chọn thư mục chứa bản sao lưu cần khôi phục (thư mục chứa users.txt, phim.txt...)"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BackupRestoreService.RestoreData(fbd.SelectedPath);
                    MessageBox.Show("Khôi phục dữ liệu thành công!\nToàn bộ dữ liệu mới đã được nạp vào hệ thống.",
                                    "Khôi phục thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đóng và mở lại các form con để cập nhật dữ liệu mới
                    CloseAllChildForms();
                    OpenChildForm<FormTicketBooking>();
                }
                catch (Exception ex)
                {
                    Logger.Log($"Lỗi khôi phục: {ex.Message}", ex);
                    MessageBox.Show($"Lỗi trong quá trình khôi phục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ColorDialog để người dùng tùy chỉnh màu sắc giao diện (Yêu cầu 6)
        private void menuColor_Click(object sender, EventArgs e)
        {
            using var cd = new ColorDialog
            {
                Color = menuStrip.BackColor,
                FullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                menuStrip.BackColor = cd.Color;
                menuStrip.ForeColor = cd.Color.GetBrightness() < 0.5 ? Color.White : Color.Black;
                RegistryHelper.ThemeColorArgb = cd.Color.ToArgb();
                MessageBox.Show("Đã áp dụng và lưu tùy chỉnh màu sắc vào Registry!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // FontDialog để người dùng tùy chỉnh phông chữ giao diện (Yêu cầu 6)
        private void menuFont_Click(object sender, EventArgs e)
        {
            using var fd = new FontDialog
            {
                Font = this.Font,
                ShowColor = false
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.Font = fd.Font;
                menuStrip.Font = fd.Font;
                statusStrip.Font = fd.Font;

                RegistryHelper.FontFamilyName = fd.Font.FontFamily.Name;
                RegistryHelper.FontSize = fd.Font.Size;
                MessageBox.Show("Đã áp dụng và lưu tùy chỉnh phông chữ vào Registry!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuOpenLog_Click(object sender, EventArgs e)
        {
            string logPath = Logger.GetLogPath();
            if (File.Exists(logPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo { FileName = logPath, UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi mở file log: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa có ghi nhận lỗi nào trong log.txt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Xử lý Menu Danh mục, Lịch chiếu, Bán vé, Thống kê
        private void menuMovies_Click(object sender, EventArgs e) => OpenChildForm<FormMovieManagement>();
        private void menuRooms_Click(object sender, EventArgs e) => OpenChildForm<FormRoomManagement>();
        private void menuShowtimeSchedule_Click(object sender, EventArgs e) => OpenChildForm<FormShowtimeManagement>();
        private void menuTicketBooking_Click(object sender, EventArgs e) => OpenChildForm<FormTicketBooking>();
        private void menuTicketRefund_Click(object sender, EventArgs e) => OpenChildForm<FormTicketRefund>();
        private void menuRevenueReport_Click(object sender, EventArgs e) => OpenChildForm<FormRevenueReport>();
        private void menuAbout_Click(object sender, EventArgs e) => OpenChildForm<FormAbout>();
        #endregion

        #region Xử lý Menu Cửa sổ (Yêu cầu 5)
        private void menuCascade_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);
        private void menuTileHorizontal_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileHorizontal);
        private void menuTileVertical_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileVertical);

        private void menuCloseAll_Click(object sender, EventArgs e) => CloseAllChildForms();

        private void CloseAllChildForms()
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
        }
        #endregion

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isLoggingOut) return;

            // Hộp thoại chuẩn hỏi xác nhận khi thoát (Yêu cầu 6)
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?",
                                          "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            SaveUserSettings();
            Logger.Log("Ứng dụng kết thúc phiên làm việc bình thường.");
        }
    }
}
