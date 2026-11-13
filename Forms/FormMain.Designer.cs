namespace CinemaManagement.Forms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            menuSystem = new ToolStripMenuItem();
            menuLogout = new ToolStripMenuItem();
            menuUsers = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuBackup = new ToolStripMenuItem();
            menuRestore = new ToolStripMenuItem();
            menuTheme = new ToolStripMenuItem();
            menuColor = new ToolStripMenuItem();
            menuFont = new ToolStripMenuItem();
            menuOpenLog = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            menuExit = new ToolStripMenuItem();
            menuCatalog = new ToolStripMenuItem();
            menuMovies = new ToolStripMenuItem();
            menuRooms = new ToolStripMenuItem();
            menuShowtime = new ToolStripMenuItem();
            menuShowtimeSchedule = new ToolStripMenuItem();
            menuBooking = new ToolStripMenuItem();
            menuTicketBooking = new ToolStripMenuItem();
            menuTicketRefund = new ToolStripMenuItem();
            menuReport = new ToolStripMenuItem();
            menuRevenueReport = new ToolStripMenuItem();
            menuWindows = new ToolStripMenuItem();
            menuCascade = new ToolStripMenuItem();
            menuTileHorizontal = new ToolStripMenuItem();
            menuTileVertical = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            menuCloseAll = new ToolStripMenuItem();
            menuHelp = new ToolStripMenuItem();
            menuAbout = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusUser = new ToolStripStatusLabel();
            statusCinema = new ToolStripStatusLabel();
            statusClock = new ToolStripStatusLabel();
            timerClock = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuSystem, menuCatalog, menuShowtime, menuBooking, menuReport, menuWindows, menuHelp });
            menuStrip.Location = new Point(0, 0);
            menuStrip.MdiWindowListItem = menuWindows;
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1262, 29);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            // 
            // menuSystem
            // 
            menuSystem.DropDownItems.AddRange(new ToolStripItem[] { menuLogout, menuUsers, toolStripSeparator1, menuBackup, menuRestore, menuTheme, menuOpenLog, toolStripSeparator2, menuExit });
            menuSystem.Name = "menuSystem";
            menuSystem.Size = new Size(106, 25);
            menuSystem.Text = "⚙️ Hệ thống";
            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new Size(279, 26);
            menuLogout.Text = "🚪 Đăng xuất";
            menuLogout.Click += menuLogout_Click;
            // 
            // menuUsers
            // 
            menuUsers.Name = "menuUsers";
            menuUsers.Size = new Size(279, 26);
            menuUsers.Text = "👥 Quản trị tài khoản (Admin)";
            menuUsers.Click += menuUsers_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(276, 6);
            // 
            // menuBackup
            // 
            menuBackup.Name = "menuBackup";
            menuBackup.Size = new Size(279, 26);
            menuBackup.Text = "💾 Sao lưu dữ liệu (Backup)";
            menuBackup.Click += menuBackup_Click;
            // 
            // menuRestore
            // 
            menuRestore.Name = "menuRestore";
            menuRestore.Size = new Size(279, 26);
            menuRestore.Text = "🔄 Khôi phục dữ liệu (Restore)";
            menuRestore.Click += menuRestore_Click;
            // 
            // menuTheme
            // 
            menuTheme.DropDownItems.AddRange(new ToolStripItem[] { menuColor, menuFont });
            menuTheme.Name = "menuTheme";
            menuTheme.Size = new Size(279, 26);
            menuTheme.Text = "🎨 Tùy chỉnh giao diện";
            // 
            // menuColor
            // 
            menuColor.Name = "menuColor";
            menuColor.Size = new Size(257, 26);
            menuColor.Text = "🎨 Chọn màu sắc chủ đạo";
            menuColor.Click += menuColor_Click;
            // 
            // menuFont
            // 
            menuFont.Name = "menuFont";
            menuFont.Size = new Size(257, 26);
            menuFont.Text = "🔤 Chọn phông chữ";
            menuFont.Click += menuFont_Click;
            // 
            // menuOpenLog
            // 
            menuOpenLog.Name = "menuOpenLog";
            menuOpenLog.Size = new Size(279, 26);
            menuOpenLog.Text = "📝 Xem nhật ký lỗi (log.txt)";
            menuOpenLog.Click += menuOpenLog_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(276, 6);
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(279, 26);
            menuExit.Text = "❌ Thoát chương trình";
            menuExit.Click += menuExit_Click;
            // 
            // menuCatalog
            // 
            menuCatalog.DropDownItems.AddRange(new ToolStripItem[] { menuMovies, menuRooms });
            menuCatalog.Name = "menuCatalog";
            menuCatalog.Size = new Size(135, 25);
            menuCatalog.Text = "🎬 Danh mục (SV1)";
            // 
            // menuMovies
            // 
            menuMovies.Name = "menuMovies";
            menuMovies.Size = new Size(248, 26);
            menuMovies.Text = "📽️ Quản lý danh mục phim";
            menuMovies.Click += menuMovies_Click;
            // 
            // menuRooms
            // 
            menuRooms.Name = "menuRooms";
            menuRooms.Size = new Size(248, 26);
            menuRooms.Text = "🏛️ Quản lý phòng chiếu";
            menuRooms.Click += menuRooms_Click;
            // 
            // menuShowtime
            // 
            menuShowtime.DropDownItems.AddRange(new ToolStripItem[] { menuShowtimeSchedule });
            menuShowtime.Name = "menuShowtime";
            menuShowtime.Size = new Size(134, 25);
            menuShowtime.Text = "📅 Lịch chiếu (SV2)";
            // 
            // menuShowtimeSchedule
            // 
            menuShowtimeSchedule.Name = "menuShowtimeSchedule";
            menuShowtimeSchedule.Size = new Size(260, 26);
            menuShowtimeSchedule.Text = "🗓️ Quản lý & Cây lịch chiếu";
            menuShowtimeSchedule.Click += menuShowtimeSchedule_Click;
            // 
            // menuBooking
            // 
            menuBooking.DropDownItems.AddRange(new ToolStripItem[] { menuTicketBooking, menuTicketRefund });
            menuBooking.Name = "menuBooking";
            menuBooking.Size = new Size(116, 25);
            menuBooking.Text = "🎟️ Bán vé (SV3)";
            // 
            // menuTicketBooking
            // 
            menuTicketBooking.Name = "menuTicketBooking";
            menuTicketBooking.Size = new Size(268, 26);
            menuTicketBooking.Text = "🪑 Quầy bán vé theo sơ đồ ghế";
            menuTicketBooking.Click += menuTicketBooking_Click;
            // 
            // menuTicketRefund
            // 
            menuTicketRefund.Name = "menuTicketRefund";
            menuTicketRefund.Size = new Size(268, 26);
            menuTicketRefund.Text = "🔄 Tra cứu & Trả vé (trước 1h)";
            menuTicketRefund.Click += menuTicketRefund_Click;
            // 
            // menuReport
            // 
            menuReport.DropDownItems.AddRange(new ToolStripItem[] { menuRevenueReport });
            menuReport.Name = "menuReport";
            menuReport.Size = new Size(130, 25);
            menuReport.Text = "📊 Thống kê (SV3)";
            // 
            // menuRevenueReport
            // 
            menuRevenueReport.Name = "menuRevenueReport";
            menuRevenueReport.Size = new Size(257, 26);
            menuRevenueReport.Text = "📈 Báo cáo doanh thu bán vé";
            menuRevenueReport.Click += menuRevenueReport_Click;
            // 
            // menuWindows
            // 
            menuWindows.DropDownItems.AddRange(new ToolStripItem[] { menuCascade, menuTileHorizontal, menuTileVertical, toolStripSeparator3, menuCloseAll });
            menuWindows.Name = "menuWindows";
            menuWindows.Size = new Size(95, 25);
            menuWindows.Text = "🪟 Cửa sổ";
            // 
            // menuCascade
            // 
            menuCascade.Name = "menuCascade";
            menuCascade.Size = new Size(224, 26);
            menuCascade.Text = "📐 Xếp tầng (Cascade)";
            menuCascade.Click += menuCascade_Click;
            // 
            // menuTileHorizontal
            // 
            menuTileHorizontal.Name = "menuTileHorizontal";
            menuTileHorizontal.Size = new Size(224, 26);
            menuTileHorizontal.Text = "☰ Xếp ngang";
            menuTileHorizontal.Click += menuTileHorizontal_Click;
            // 
            // menuTileVertical
            // 
            menuTileVertical.Name = "menuTileVertical";
            menuTileVertical.Size = new Size(224, 26);
            menuTileVertical.Text = "☵ Xếp dọc";
            menuTileVertical.Click += menuTileVertical_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(221, 6);
            // 
            // menuCloseAll
            // 
            menuCloseAll.Name = "menuCloseAll";
            menuCloseAll.Size = new Size(224, 26);
            menuCloseAll.Text = "❌ Đóng tất cả";
            menuCloseAll.Click += menuCloseAll_Click;
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new ToolStripItem[] { menuAbout });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new Size(99, 25);
            menuHelp.Text = "ℹ️ Trợ giúp";
            // 
            // menuAbout
            // 
            menuAbout.Name = "menuAbout";
            menuAbout.Size = new Size(224, 26);
            menuAbout.Text = "📖 Giới thiệu đề tài 10";
            menuAbout.Click += menuAbout_Click;
            // 
            // statusStrip
            // 
            statusStrip.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusUser, statusCinema, statusClock });
            statusStrip.Location = new Point(0, 727);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1262, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // statusUser
            // 
            statusUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            statusUser.ForeColor = Color.FromArgb(13, 110, 253);
            statusUser.Name = "statusUser";
            statusUser.Size = new Size(200, 20);
            statusUser.Text = "👤 Người dùng: Chưa đăng nhập";
            // 
            // statusCinema
            // 
            statusCinema.Name = "statusCinema";
            statusCinema.Size = new Size(847, 20);
            statusCinema.Spring = true;
            statusCinema.Text = "🏛️ RẠP CHIẾU PHIM GALAXY STAR";
            // 
            // statusClock
            // 
            statusClock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            statusClock.ForeColor = Color.FromArgb(33, 37, 41);
            statusClock.Name = "statusClock";
            statusClock.Size = new Size(160, 20);
            statusClock.Text = "⏰ 00:00:00 01/01/2026";
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 753);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(1000, 650);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Rạp chiếu phim - Đề tài 10";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuSystem;
        private ToolStripMenuItem menuLogout;
        private ToolStripMenuItem menuUsers;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuBackup;
        private ToolStripMenuItem menuRestore;
        private ToolStripMenuItem menuTheme;
        private ToolStripMenuItem menuColor;
        private ToolStripMenuItem menuFont;
        private ToolStripMenuItem menuOpenLog;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem menuCatalog;
        private ToolStripMenuItem menuMovies;
        private ToolStripMenuItem menuRooms;
        private ToolStripMenuItem menuShowtime;
        private ToolStripMenuItem menuShowtimeSchedule;
        private ToolStripMenuItem menuBooking;
        private ToolStripMenuItem menuTicketBooking;
        private ToolStripMenuItem menuTicketRefund;
        private ToolStripMenuItem menuReport;
        private ToolStripMenuItem menuRevenueReport;
        private ToolStripMenuItem menuWindows;
        private ToolStripMenuItem menuCascade;
        private ToolStripMenuItem menuTileHorizontal;
        private ToolStripMenuItem menuTileVertical;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem menuCloseAll;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem menuAbout;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusUser;
        private ToolStripStatusLabel statusCinema;
        private ToolStripStatusLabel statusClock;
        private System.Windows.Forms.Timer timerClock;
    }
}
