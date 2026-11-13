namespace CinemaManagement.Forms
{
    partial class FormTicketRefund
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
            panelSearch = new Panel();
            btnSearch = new Button();
            txtTicketId = new TextBox();
            lblTicketId = new Label();
            splitContainer = new SplitContainer();
            lvRecentTickets = new ListView();
            colId = new ColumnHeader();
            colShowtime = new ColumnHeader();
            colMovie = new ColumnHeader();
            colRoom = new ColumnHeader();
            colSeat = new ColumnHeader();
            colPrice = new ColumnHeader();
            colShowDate = new ColumnHeader();
            colStatus = new ColumnHeader();
            grpTicketDetails = new GroupBox();
            lblRefundPolicy = new Label();
            btnProcessRefund = new Button();
            lblEligibility = new Label();
            lblTimeRemaining = new Label();
            lblShowtimeTime = new Label();
            lblRoomInfo = new Label();
            lblMovieTitle = new Label();
            lblSeatCode = new Label();
            lblTicketCode = new Label();
            panelTop.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            grpTicketDetails.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(33, 37, 41);
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1100, 55);
            panelTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.FromArgb(255, 193, 7);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(1100, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🔄 TRA CỨU & TRẢ VÉ TRƯỚC GIỜ CHIẾU 1 TIẾNG (ĐIỂM CỘNG NÂNG CAO)";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(248, 249, 250);
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtTicketId);
            panelSearch.Controls.Add(lblTicketId);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 55);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1100, 55);
            panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(13, 110, 253);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(480, 11);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 32);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tra cứu";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtTicketId
            // 
            txtTicketId.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtTicketId.Location = new Point(160, 13);
            txtTicketId.Name = "txtTicketId";
            txtTicketId.PlaceholderText = "Nhập mã vé (ví dụ: VE001, VE2026...)";
            txtTicketId.Size = new Size(300, 29);
            txtTicketId.TabIndex = 1;
            // 
            // lblTicketId
            // 
            lblTicketId.AutoSize = true;
            lblTicketId.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTicketId.Location = new Point(20, 17);
            lblTicketId.Name = "lblTicketId";
            lblTicketId.Size = new Size(130, 20);
            lblTicketId.TabIndex = 0;
            lblTicketId.Text = "Nhập mã cần tra:";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 110);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(lvRecentTickets);
            splitContainer.Panel1.Padding = new Padding(10);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(grpTicketDetails);
            splitContainer.Panel2.Padding = new Padding(10);
            splitContainer.Size = new Size(1100, 540);
            splitContainer.SplitterDistance = 640;
            splitContainer.TabIndex = 2;
            // 
            // lvRecentTickets
            // 
            lvRecentTickets.Columns.AddRange(new ColumnHeader[] { colId, colShowtime, colMovie, colRoom, colSeat, colPrice, colShowDate, colStatus });
            lvRecentTickets.Dock = DockStyle.Fill;
            lvRecentTickets.FullRowSelect = true;
            lvRecentTickets.GridLines = true;
            lvRecentTickets.Location = new Point(10, 10);
            lvRecentTickets.MultiSelect = false;
            lvRecentTickets.Name = "lvRecentTickets";
            lvRecentTickets.Size = new Size(620, 520);
            lvRecentTickets.TabIndex = 0;
            lvRecentTickets.UseCompatibleStateImageBehavior = false;
            lvRecentTickets.View = View.Details;
            lvRecentTickets.SelectedIndexChanged += lvRecentTickets_SelectedIndexChanged;
            // 
            // colId
            // 
            colId.Text = "Mã Vé";
            colId.Width = 100;
            // 
            // colShowtime
            // 
            colShowtime.Text = "Mã Suất";
            colShowtime.Width = 75;
            // 
            // colMovie
            // 
            colMovie.Text = "Tên Phim";
            colMovie.Width = 160;
            // 
            // colRoom
            // 
            colRoom.Text = "Phòng";
            colRoom.Width = 80;
            // 
            // colSeat
            // 
            colSeat.Text = "Ghế";
            colSeat.Width = 55;
            // 
            // colPrice
            // 
            colPrice.Text = "Giá Vé";
            colPrice.Width = 90;
            // 
            // colShowDate
            // 
            colShowDate.Text = "Giờ Chiếu";
            colShowDate.Width = 130;
            // 
            // colStatus
            // 
            colStatus.Text = "Khả Năng Trả";
            colStatus.Width = 120;
            // 
            // grpTicketDetails
            // 
            grpTicketDetails.Controls.Add(lblRefundPolicy);
            grpTicketDetails.Controls.Add(btnProcessRefund);
            grpTicketDetails.Controls.Add(lblEligibility);
            grpTicketDetails.Controls.Add(lblTimeRemaining);
            grpTicketDetails.Controls.Add(lblShowtimeTime);
            grpTicketDetails.Controls.Add(lblRoomInfo);
            grpTicketDetails.Controls.Add(lblMovieTitle);
            grpTicketDetails.Controls.Add(lblSeatCode);
            grpTicketDetails.Controls.Add(lblTicketCode);
            grpTicketDetails.Dock = DockStyle.Fill;
            grpTicketDetails.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            grpTicketDetails.Location = new Point(10, 10);
            grpTicketDetails.Name = "grpTicketDetails";
            grpTicketDetails.Size = new Size(436, 520);
            grpTicketDetails.TabIndex = 0;
            grpTicketDetails.TabStop = false;
            grpTicketDetails.Text = "Chi tiết vé & Điều kiện hoàn trả";
            // 
            // lblRefundPolicy
            // 
            lblRefundPolicy.BackColor = Color.FromArgb(255, 243, 205);
            lblRefundPolicy.BorderStyle = BorderStyle.FixedSingle;
            lblRefundPolicy.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblRefundPolicy.ForeColor = Color.FromArgb(102, 77, 3);
            lblRefundPolicy.Location = new Point(20, 420);
            lblRefundPolicy.Name = "lblRefundPolicy";
            lblRefundPolicy.Padding = new Padding(8);
            lblRefundPolicy.Size = new Size(395, 80);
            lblRefundPolicy.TabIndex = 8;
            lblRefundPolicy.Text = "📜 QUY ĐỊNH HOÀN VÉ:\nTheo quy định của rạp, vé chỉ được chấp nhận hoàn tiền khi thời gian hiện tại cách giờ bắt đầu chiếu tối thiểu 60 phút. Vé trả sẽ được xóa và mở lại chỗ trên sơ đồ ghế.";
            // 
            // btnProcessRefund
            // 
            btnProcessRefund.BackColor = Color.FromArgb(220, 53, 69);
            btnProcessRefund.Cursor = Cursors.Hand;
            btnProcessRefund.Enabled = false;
            btnProcessRefund.FlatStyle = FlatStyle.Flat;
            btnProcessRefund.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnProcessRefund.ForeColor = Color.White;
            btnProcessRefund.Location = new Point(20, 350);
            btnProcessRefund.Name = "btnProcessRefund";
            btnProcessRefund.Size = new Size(395, 45);
            btnProcessRefund.TabIndex = 7;
            btnProcessRefund.Text = "💸 XÁC NHẬN TRẢ VÉ && HOÀN TIỀN";
            btnProcessRefund.UseVisualStyleBackColor = false;
            btnProcessRefund.Click += btnProcessRefund_Click;
            // 
            // lblEligibility
            // 
            lblEligibility.BackColor = Color.FromArgb(240, 240, 240);
            lblEligibility.BorderStyle = BorderStyle.FixedSingle;
            lblEligibility.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblEligibility.ForeColor = Color.Black;
            lblEligibility.Location = new Point(20, 275);
            lblEligibility.Name = "lblEligibility";
            lblEligibility.Padding = new Padding(8);
            lblEligibility.Size = new Size(395, 55);
            lblEligibility.TabIndex = 6;
            lblEligibility.Text = "Vui lòng chọn vé để kiểm tra điều kiện hoàn trả";
            lblEligibility.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTimeRemaining
            // 
            lblTimeRemaining.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimeRemaining.Location = new Point(20, 235);
            lblTimeRemaining.Name = "lblTimeRemaining";
            lblTimeRemaining.Size = new Size(395, 25);
            lblTimeRemaining.TabIndex = 5;
            lblTimeRemaining.Text = "⏱️ Thời gian còn lại: --";
            // 
            // lblShowtimeTime
            // 
            lblShowtimeTime.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblShowtimeTime.Location = new Point(20, 195);
            lblShowtimeTime.Name = "lblShowtimeTime";
            lblShowtimeTime.Size = new Size(395, 25);
            lblShowtimeTime.TabIndex = 4;
            lblShowtimeTime.Text = "⏰ Giờ chiếu: --";
            // 
            // lblRoomInfo
            // 
            lblRoomInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRoomInfo.Location = new Point(20, 155);
            lblRoomInfo.Name = "lblRoomInfo";
            lblRoomInfo.Size = new Size(395, 25);
            lblRoomInfo.TabIndex = 3;
            lblRoomInfo.Text = "🏛️ Phòng chiếu: --";
            // 
            // lblMovieTitle
            // 
            lblMovieTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMovieTitle.Location = new Point(20, 115);
            lblMovieTitle.Name = "lblMovieTitle";
            lblMovieTitle.Size = new Size(395, 25);
            lblMovieTitle.TabIndex = 2;
            lblMovieTitle.Text = "🎬 Tên phim: --";
            // 
            // lblSeatCode
            // 
            lblSeatCode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSeatCode.Location = new Point(20, 75);
            lblSeatCode.Name = "lblSeatCode";
            lblSeatCode.Size = new Size(395, 25);
            lblSeatCode.TabIndex = 1;
            lblSeatCode.Text = "🪑 Vị trí ghế & Giá: --";
            // 
            // lblTicketCode
            // 
            lblTicketCode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTicketCode.Location = new Point(20, 35);
            lblTicketCode.Name = "lblTicketCode";
            lblTicketCode.Size = new Size(395, 25);
            lblTicketCode.TabIndex = 0;
            lblTicketCode.Text = "🎫 Mã vé: --";
            // 
            // FormTicketRefund
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(splitContainer);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Name = "FormTicketRefund";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tra cứu & Trả vé trước giờ chiếu 1 tiếng - Điểm cộng";
            Load += FormTicketRefund_Load;
            panelTop.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            grpTicketDetails.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblHeader;
        private Panel panelSearch;
        private Label lblTicketId;
        private TextBox txtTicketId;
        private Button btnSearch;
        private SplitContainer splitContainer;
        private ListView lvRecentTickets;
        private ColumnHeader colId;
        private ColumnHeader colShowtime;
        private ColumnHeader colMovie;
        private ColumnHeader colRoom;
        private ColumnHeader colSeat;
        private ColumnHeader colPrice;
        private ColumnHeader colShowDate;
        private ColumnHeader colStatus;
        private GroupBox grpTicketDetails;
        private Label lblTicketCode;
        private Label lblSeatCode;
        private Label lblMovieTitle;
        private Label lblRoomInfo;
        private Label lblShowtimeTime;
        private Label lblTimeRemaining;
        private Label lblEligibility;
        private Button btnProcessRefund;
        private Label lblRefundPolicy;
    }
}
