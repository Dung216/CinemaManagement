namespace CinemaManagement.Forms
{
    partial class FormRevenueReport
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
            panelTop = new Panel();
            lblHeader = new Label();
            panelFilter = new Panel();
            btnExportCsv = new Button();
            btnExportTxt = new Button();
            btnFilter = new Button();
            dtpToDate = new DateTimePicker();
            lblToDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblFromDate = new Label();
            panelSummary = new Panel();
            lblSummaryTotalRevenue = new Label();
            lblSummaryTotalTickets = new Label();
            tabControl = new TabControl();
            tabByMovie = new TabPage();
            lvByMovie = new ListView();
            colMovieId = new ColumnHeader();
            colMovieTitle = new ColumnHeader();
            colMovieGenre = new ColumnHeader();
            colMovieTicketCount = new ColumnHeader();
            colMovieRevenue = new ColumnHeader();
            colMoviePercentage = new ColumnHeader();
            tabByDate = new TabPage();
            lvByDate = new ListView();
            colDate = new ColumnHeader();
            colDateTicketCount = new ColumnHeader();
            colDateRevenue = new ColumnHeader();
            panelTop.SuspendLayout();
            panelFilter.SuspendLayout();
            panelSummary.SuspendLayout();
            tabControl.SuspendLayout();
            tabByMovie.SuspendLayout();
            tabByDate.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(33, 37, 41);
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1050, 55);
            panelTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.FromArgb(255, 193, 7);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(1050, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "📊 BÁO CÁO THỐNG KÊ DOANH THU (SV3)";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.FromArgb(248, 249, 250);
            panelFilter.BorderStyle = BorderStyle.FixedSingle;
            panelFilter.Controls.Add(btnExportCsv);
            panelFilter.Controls.Add(btnExportTxt);
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Controls.Add(dtpToDate);
            panelFilter.Controls.Add(lblToDate);
            panelFilter.Controls.Add(dtpFromDate);
            panelFilter.Controls.Add(lblFromDate);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 55);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1050, 55);
            panelFilter.TabIndex = 1;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.FromArgb(25, 135, 84);
            btnExportCsv.Cursor = Cursors.Hand;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(870, 11);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(160, 32);
            btnExportCsv.TabIndex = 6;
            btnExportCsv.Text = "📊 Xuất CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // btnExportTxt
            // 
            btnExportTxt.BackColor = Color.FromArgb(108, 117, 125);
            btnExportTxt.Cursor = Cursors.Hand;
            btnExportTxt.FlatStyle = FlatStyle.Flat;
            btnExportTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportTxt.ForeColor = Color.White;
            btnExportTxt.Location = new Point(695, 11);
            btnExportTxt.Name = "btnExportTxt";
            btnExportTxt.Size = new Size(160, 32);
            btnExportTxt.TabIndex = 5;
            btnExportTxt.Text = "📄 Xuất Báo Cáo TXT";
            btnExportTxt.UseVisualStyleBackColor = false;
            btnExportTxt.Click += btnExportTxt_Click;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(13, 110, 253);
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(480, 11);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(120, 32);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "🔍 Thống kê";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // dtpToDate
            // 
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(325, 13);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(130, 29);
            dtpToDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblToDate.Location = new Point(245, 17);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(79, 20);
            lblToDate.TabIndex = 2;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpFromDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(95, 13);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(130, 29);
            dtpFromDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblFromDate.Location = new Point(20, 17);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(70, 20);
            lblFromDate.TabIndex = 0;
            lblFromDate.Text = "Từ ngày:";
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.FromArgb(235, 245, 255);
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(lblSummaryTotalRevenue);
            panelSummary.Controls.Add(lblSummaryTotalTickets);
            panelSummary.Dock = DockStyle.Bottom;
            panelSummary.Location = new Point(0, 580);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(1050, 60);
            panelSummary.TabIndex = 2;
            // 
            // lblSummaryTotalRevenue
            // 
            lblSummaryTotalRevenue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummaryTotalRevenue.ForeColor = Color.FromArgb(220, 53, 69);
            lblSummaryTotalRevenue.Location = new Point(500, 15);
            lblSummaryTotalRevenue.Name = "lblSummaryTotalRevenue";
            lblSummaryTotalRevenue.Size = new Size(530, 30);
            lblSummaryTotalRevenue.TabIndex = 1;
            lblSummaryTotalRevenue.Text = "💰 TỔNG DOANH THU: 0 VNĐ";
            lblSummaryTotalRevenue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSummaryTotalTickets
            // 
            lblSummaryTotalTickets.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummaryTotalTickets.ForeColor = Color.FromArgb(13, 110, 253);
            lblSummaryTotalTickets.Location = new Point(20, 15);
            lblSummaryTotalTickets.Name = "lblSummaryTotalTickets";
            lblSummaryTotalTickets.Size = new Size(450, 30);
            lblSummaryTotalTickets.TabIndex = 0;
            lblSummaryTotalTickets.Text = "🎟️ TỔNG SỐ VÉ ĐÃ BÁN: 0 VÉ";
            lblSummaryTotalTickets.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabByMovie);
            tabControl.Controls.Add(tabByDate);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl.Location = new Point(0, 110);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1050, 470);
            tabControl.TabIndex = 3;
            // 
            // tabByMovie
            // 
            tabByMovie.Controls.Add(lvByMovie);
            tabByMovie.Location = new Point(4, 30);
            tabByMovie.Name = "tabByMovie";
            tabByMovie.Padding = new Padding(3);
            tabByMovie.Size = new Size(1042, 436);
            tabByMovie.TabIndex = 0;
            tabByMovie.Text = "🎬 Thống kê theo Phim";
            tabByMovie.UseVisualStyleBackColor = true;
            // 
            // lvByMovie
            // 
            lvByMovie.Columns.AddRange(new ColumnHeader[] { colMovieId, colMovieTitle, colMovieGenre, colMovieTicketCount, colMovieRevenue, colMoviePercentage });
            lvByMovie.Dock = DockStyle.Fill;
            lvByMovie.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lvByMovie.FullRowSelect = true;
            lvByMovie.GridLines = true;
            lvByMovie.Location = new Point(3, 3);
            lvByMovie.Name = "lvByMovie";
            lvByMovie.Size = new Size(1036, 430);
            lvByMovie.TabIndex = 0;
            lvByMovie.UseCompatibleStateImageBehavior = false;
            lvByMovie.View = View.Details;
            // 
            // colMovieId
            // 
            colMovieId.Text = "Mã Phim";
            colMovieId.Width = 100;
            // 
            // colMovieTitle
            // 
            colMovieTitle.Text = "Tên Phim";
            colMovieTitle.Width = 320;
            // 
            // colMovieGenre
            // 
            colMovieGenre.Text = "Thể Loại";
            colMovieGenre.Width = 200;
            // 
            // colMovieTicketCount
            // 
            colMovieTicketCount.Text = "Số Vé Bán";
            colMovieTicketCount.TextAlign = HorizontalAlignment.Right;
            colMovieTicketCount.Width = 120;
            // 
            // colMovieRevenue
            // 
            colMovieRevenue.Text = "Doanh Thu (VNĐ)";
            colMovieRevenue.TextAlign = HorizontalAlignment.Right;
            colMovieRevenue.Width = 180;
            // 
            // colMoviePercentage
            // 
            colMoviePercentage.Text = "Tỷ Lệ %";
            colMoviePercentage.TextAlign = HorizontalAlignment.Right;
            colMoviePercentage.Width = 100;
            // 
            // tabByDate
            // 
            tabByDate.Controls.Add(lvByDate);
            tabByDate.Location = new Point(4, 30);
            tabByDate.Name = "tabByDate";
            tabByDate.Padding = new Padding(3);
            tabByDate.Size = new Size(1042, 436);
            tabByDate.TabIndex = 1;
            tabByDate.Text = "📅 Thống kê theo Ngày";
            tabByDate.UseVisualStyleBackColor = true;
            // 
            // lvByDate
            // 
            lvByDate.Columns.AddRange(new ColumnHeader[] { colDate, colDateTicketCount, colDateRevenue });
            lvByDate.Dock = DockStyle.Fill;
            lvByDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lvByDate.FullRowSelect = true;
            lvByDate.GridLines = true;
            lvByDate.Location = new Point(3, 3);
            lvByDate.Name = "lvByDate";
            lvByDate.Size = new Size(1036, 430);
            lvByDate.TabIndex = 0;
            lvByDate.UseCompatibleStateImageBehavior = false;
            lvByDate.View = View.Details;
            // 
            // colDate
            // 
            colDate.Text = "Ngày";
            colDate.Width = 250;
            // 
            // colDateTicketCount
            // 
            colDateTicketCount.Text = "Số Vé Bán Ra";
            colDateTicketCount.TextAlign = HorizontalAlignment.Right;
            colDateTicketCount.Width = 200;
            // 
            // colDateRevenue
            // 
            colDateRevenue.Text = "Tổng Doanh Thu (VNĐ)";
            colDateRevenue.TextAlign = HorizontalAlignment.Right;
            colDateRevenue.Width = 250;
            // 
            // FormRevenueReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 640);
            Controls.Add(tabControl);
            Controls.Add(panelSummary);
            Controls.Add(panelFilter);
            Controls.Add(panelTop);
            Name = "FormRevenueReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo thống kê doanh thu - Phân hệ SV3";
            Load += FormRevenueReport_Load;
            panelTop.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelSummary.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabByMovie.ResumeLayout(false);
            tabByDate.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblHeader;
        private Panel panelFilter;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnFilter;
        private Button btnExportTxt;
        private Button btnExportCsv;
        private Panel panelSummary;
        private Label lblSummaryTotalTickets;
        private Label lblSummaryTotalRevenue;
        private TabControl tabControl;
        private TabPage tabByMovie;
        private TabPage tabByDate;
        private ListView lvByMovie;
        private ColumnHeader colMovieId;
        private ColumnHeader colMovieTitle;
        private ColumnHeader colMovieGenre;
        private ColumnHeader colMovieTicketCount;
        private ColumnHeader colMovieRevenue;
        private ColumnHeader colMoviePercentage;
        private ListView lvByDate;
        private ColumnHeader colDate;
        private ColumnHeader colDateTicketCount;
        private ColumnHeader colDateRevenue;
    }
}
