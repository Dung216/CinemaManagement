namespace CinemaManagement.Forms
{
    partial class FormTicketBooking
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
            panelTop = new Panel();
            chkAutoFilterPastShows = new CheckBox();
            lblCurrentShowInfo = new Label();
            cboShowtimes = new ComboBox();
            lblSelectShow = new Label();
            dtpShowDate = new DateTimePicker();
            lblSelectDate = new Label();
            lblHeader = new Label();
            splitContainer = new SplitContainer();
            panelSeatMap = new Panel();
            panelSeatsContainer = new Panel();
            panelLegend = new Panel();
            lblLegendSold = new Label();
            boxLegendSold = new Label();
            lblLegendSelected = new Label();
            boxLegendSelected = new Label();
            lblLegendVip = new Label();
            boxLegendVip = new Label();
            lblLegendNormal = new Label();
            boxLegendNormal = new Label();
            lblScreen = new Label();
            panelCheckout = new Panel();
            btnResetSeats = new Button();
            btnPrintAndPay = new Button();
            grpTotal = new GroupBox();
            lblGrandTotalValue = new Label();
            lblGrandTotal = new Label();
            lblComboTotal = new Label();
            lblDiscountTotal = new Label();
            lblTicketTotal = new Label();
            grpCombos = new GroupBox();
            panelCombos = new FlowLayoutPanel();
            grpTicketType = new GroupBox();
            lblStudentDiscountNote = new Label();
            rdoStudent = new RadioButton();
            rdoAdult = new RadioButton();
            grpSelectedSeats = new GroupBox();
            lstSelectedSeats = new ListBox();
            timerAutoFilter = new System.Windows.Forms.Timer(components);
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelSeatMap.SuspendLayout();
            panelLegend.SuspendLayout();
            panelCheckout.SuspendLayout();
            grpTotal.SuspendLayout();
            grpCombos.SuspendLayout();
            grpTicketType.SuspendLayout();
            grpSelectedSeats.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(33, 37, 41);
            panelTop.Controls.Add(chkAutoFilterPastShows);
            panelTop.Controls.Add(lblCurrentShowInfo);
            panelTop.Controls.Add(cboShowtimes);
            panelTop.Controls.Add(lblSelectShow);
            panelTop.Controls.Add(dtpShowDate);
            panelTop.Controls.Add(lblSelectDate);
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1220, 110);
            panelTop.TabIndex = 0;
            // 
            // chkAutoFilterPastShows
            // 
            chkAutoFilterPastShows.AutoSize = true;
            chkAutoFilterPastShows.Checked = true;
            chkAutoFilterPastShows.CheckState = CheckState.Checked;
            chkAutoFilterPastShows.ForeColor = Color.FromArgb(255, 193, 7);
            chkAutoFilterPastShows.Location = new Point(885, 43);
            chkAutoFilterPastShows.Name = "chkAutoFilterPastShows";
            chkAutoFilterPastShows.Size = new Size(318, 24);
            chkAutoFilterPastShows.TabIndex = 6;
            chkAutoFilterPastShows.Text = "⏱️ Tự động ẩn suất đã chiếu (Timer)";
            chkAutoFilterPastShows.UseVisualStyleBackColor = true;
            chkAutoFilterPastShows.CheckedChanged += chkAutoFilterPastShows_CheckedChanged;
            // 
            // lblCurrentShowInfo
            // 
            lblCurrentShowInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblCurrentShowInfo.ForeColor = Color.FromArgb(220, 220, 220);
            lblCurrentShowInfo.Location = new Point(15, 75);
            lblCurrentShowInfo.Name = "lblCurrentShowInfo";
            lblCurrentShowInfo.Size = new Size(1190, 25);
            lblCurrentShowInfo.TabIndex = 5;
            lblCurrentShowInfo.Text = "Vui lòng chọn suất chiếu để nạp sơ đồ ghế";
            // 
            // cboShowtimes
            // 
            cboShowtimes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShowtimes.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cboShowtimes.FormattingEnabled = true;
            cboShowtimes.Location = new Point(390, 41);
            cboShowtimes.Name = "cboShowtimes";
            cboShowtimes.Size = new Size(480, 29);
            cboShowtimes.TabIndex = 4;
            cboShowtimes.SelectedIndexChanged += cboShowtimes_SelectedIndexChanged;
            // 
            // lblSelectShow
            // 
            lblSelectShow.AutoSize = true;
            lblSelectShow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectShow.ForeColor = Color.White;
            lblSelectShow.Location = new Point(260, 45);
            lblSelectShow.Name = "lblSelectShow";
            lblSelectShow.Size = new Size(125, 20);
            lblSelectShow.TabIndex = 3;
            lblSelectShow.Text = "Chọn suất chiếu:";
            // 
            // dtpShowDate
            // 
            dtpShowDate.CustomFormat = "dd/MM/yyyy";
            dtpShowDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dtpShowDate.Format = DateTimePickerFormat.Custom;
            dtpShowDate.Location = new Point(115, 41);
            dtpShowDate.Name = "dtpShowDate";
            dtpShowDate.Size = new Size(130, 29);
            dtpShowDate.TabIndex = 2;
            dtpShowDate.ValueChanged += dtpShowDate_ValueChanged;
            // 
            // lblSelectDate
            // 
            lblSelectDate.AutoSize = true;
            lblSelectDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectDate.ForeColor = Color.White;
            lblSelectDate.Location = new Point(15, 45);
            lblSelectDate.Name = "lblSelectDate";
            lblSelectDate.Size = new Size(93, 20);
            lblSelectDate.TabIndex = 1;
            lblSelectDate.Text = "Chọn ngày:";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.FromArgb(255, 193, 7);
            lblHeader.Location = new Point(12, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(491, 28);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🎟️ QUẦY BÁN VÉ THEO SƠ ĐỒ GHẾ THỜI GIAN THỰC";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 110);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelSeatMap);
            splitContainer.Panel1.Controls.Add(panelLegend);
            splitContainer.Panel1.Controls.Add(lblScreen);
            splitContainer.Panel1.Padding = new Padding(10);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelCheckout);
            splitContainer.Panel2.Padding = new Padding(10);
            splitContainer.Size = new Size(1220, 640);
            splitContainer.SplitterDistance = 770;
            splitContainer.TabIndex = 1;
            // 
            // panelSeatMap
            // 
            panelSeatMap.AutoScroll = true;
            panelSeatMap.BorderStyle = BorderStyle.FixedSingle;
            panelSeatMap.Controls.Add(panelSeatsContainer);
            panelSeatMap.Dock = DockStyle.Fill;
            panelSeatMap.Location = new Point(10, 50);
            panelSeatMap.Name = "panelSeatMap";
            panelSeatMap.Size = new Size(750, 530);
            panelSeatMap.TabIndex = 2;
            // 
            // panelSeatsContainer
            // 
            panelSeatsContainer.AutoSize = true;
            panelSeatsContainer.Location = new Point(15, 15);
            panelSeatsContainer.Name = "panelSeatsContainer";
            panelSeatsContainer.Size = new Size(700, 480);
            panelSeatsContainer.TabIndex = 0;
            // 
            // panelLegend
            // 
            panelLegend.BackColor = Color.FromArgb(248, 249, 250);
            panelLegend.BorderStyle = BorderStyle.FixedSingle;
            panelLegend.Controls.Add(lblLegendSold);
            panelLegend.Controls.Add(boxLegendSold);
            panelLegend.Controls.Add(lblLegendSelected);
            panelLegend.Controls.Add(boxLegendSelected);
            panelLegend.Controls.Add(lblLegendVip);
            panelLegend.Controls.Add(boxLegendVip);
            panelLegend.Controls.Add(lblLegendNormal);
            panelLegend.Controls.Add(boxLegendNormal);
            panelLegend.Dock = DockStyle.Bottom;
            panelLegend.Location = new Point(10, 580);
            panelLegend.Name = "panelLegend";
            panelLegend.Size = new Size(750, 50);
            panelLegend.TabIndex = 1;
            // 
            // lblLegendSold
            // 
            lblLegendSold.AutoSize = true;
            lblLegendSold.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLegendSold.Location = new Point(595, 15);
            lblLegendSold.Name = "lblLegendSold";
            lblLegendSold.Size = new Size(89, 20);
            lblLegendSold.TabIndex = 7;
            lblLegendSold.Text = "Ghế đã bán";
            // 
            // boxLegendSold
            // 
            boxLegendSold.BackColor = Color.FromArgb(220, 53, 69);
            boxLegendSold.BorderStyle = BorderStyle.FixedSingle;
            boxLegendSold.Location = new Point(560, 12);
            boxLegendSold.Name = "boxLegendSold";
            boxLegendSold.Size = new Size(28, 24);
            boxLegendSold.TabIndex = 6;
            // 
            // lblLegendSelected
            // 
            lblLegendSelected.AutoSize = true;
            lblLegendSelected.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLegendSelected.Location = new Point(415, 15);
            lblLegendSelected.Name = "lblLegendSelected";
            lblLegendSelected.Size = new Size(111, 20);
            lblLegendSelected.TabIndex = 5;
            lblLegendSelected.Text = "Ghế đang chọn";
            // 
            // boxLegendSelected
            // 
            boxLegendSelected.BackColor = Color.FromArgb(13, 110, 253);
            boxLegendSelected.BorderStyle = BorderStyle.FixedSingle;
            boxLegendSelected.Location = new Point(380, 12);
            boxLegendSelected.Name = "boxLegendSelected";
            boxLegendSelected.Size = new Size(28, 24);
            boxLegendSelected.TabIndex = 4;
            // 
            // lblLegendVip
            // 
            lblLegendVip.AutoSize = true;
            lblLegendVip.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLegendVip.Location = new Point(230, 15);
            lblLegendVip.Name = "lblLegendVip";
            lblLegendVip.Size = new Size(106, 20);
            lblLegendVip.TabIndex = 3;
            lblLegendVip.Text = "Ghế VIP trống";
            // 
            // boxLegendVip
            // 
            boxLegendVip.BackColor = Color.FromArgb(255, 193, 7);
            boxLegendVip.BorderStyle = BorderStyle.FixedSingle;
            boxLegendVip.Location = new Point(195, 12);
            boxLegendVip.Name = "boxLegendVip";
            boxLegendVip.Size = new Size(28, 24);
            boxLegendVip.TabIndex = 2;
            // 
            // lblLegendNormal
            // 
            lblLegendNormal.AutoSize = true;
            lblLegendNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLegendNormal.Location = new Point(55, 15);
            lblLegendNormal.Name = "lblLegendNormal";
            lblLegendNormal.Size = new Size(111, 20);
            lblLegendNormal.TabIndex = 1;
            lblLegendNormal.Text = "Ghế tiêu chuẩn";
            // 
            // boxLegendNormal
            // 
            boxLegendNormal.BackColor = Color.FromArgb(235, 240, 250);
            boxLegendNormal.BorderStyle = BorderStyle.FixedSingle;
            boxLegendNormal.Location = new Point(20, 12);
            boxLegendNormal.Name = "boxLegendNormal";
            boxLegendNormal.Size = new Size(28, 24);
            boxLegendNormal.TabIndex = 0;
            // 
            // lblScreen
            // 
            lblScreen.BackColor = Color.FromArgb(52, 58, 64);
            lblScreen.Dock = DockStyle.Top;
            lblScreen.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblScreen.ForeColor = Color.White;
            lblScreen.Location = new Point(10, 10);
            lblScreen.Name = "lblScreen";
            lblScreen.Size = new Size(750, 40);
            lblScreen.TabIndex = 0;
            lblScreen.Text = "══════════════════ MÀN HÌNH CHIẾU (SCREEN) ══════════════════";
            lblScreen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCheckout
            // 
            panelCheckout.Controls.Add(btnResetSeats);
            panelCheckout.Controls.Add(btnPrintAndPay);
            panelCheckout.Controls.Add(grpTotal);
            panelCheckout.Controls.Add(grpCombos);
            panelCheckout.Controls.Add(grpTicketType);
            panelCheckout.Controls.Add(grpSelectedSeats);
            panelCheckout.Dock = DockStyle.Fill;
            panelCheckout.Location = new Point(10, 10);
            panelCheckout.Name = "panelCheckout";
            panelCheckout.Size = new Size(426, 620);
            panelCheckout.TabIndex = 0;
            // 
            // btnResetSeats
            // 
            btnResetSeats.BackColor = Color.FromArgb(108, 117, 125);
            btnResetSeats.Cursor = Cursors.Hand;
            btnResetSeats.FlatStyle = FlatStyle.Flat;
            btnResetSeats.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetSeats.ForeColor = Color.White;
            btnResetSeats.Location = new Point(220, 565);
            btnResetSeats.Name = "btnResetSeats";
            btnResetSeats.Size = new Size(195, 45);
            btnResetSeats.TabIndex = 5;
            btnResetSeats.Text = "🔄 Bỏ chọn tất cả";
            btnResetSeats.UseVisualStyleBackColor = false;
            btnResetSeats.Click += btnResetSeats_Click;
            // 
            // btnPrintAndPay
            // 
            btnPrintAndPay.BackColor = Color.FromArgb(25, 135, 84);
            btnPrintAndPay.Cursor = Cursors.Hand;
            btnPrintAndPay.FlatStyle = FlatStyle.Flat;
            btnPrintAndPay.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrintAndPay.ForeColor = Color.White;
            btnPrintAndPay.Location = new Point(10, 565);
            btnPrintAndPay.Name = "btnPrintAndPay";
            btnPrintAndPay.Size = new Size(200, 45);
            btnPrintAndPay.TabIndex = 4;
            btnPrintAndPay.Text = "💳 THANH TOÁN && IN VÉ";
            btnPrintAndPay.UseVisualStyleBackColor = false;
            btnPrintAndPay.Click += btnPrintAndPay_Click;
            // 
            // grpTotal
            // 
            grpTotal.Controls.Add(lblGrandTotalValue);
            grpTotal.Controls.Add(lblGrandTotal);
            grpTotal.Controls.Add(lblComboTotal);
            grpTotal.Controls.Add(lblDiscountTotal);
            grpTotal.Controls.Add(lblTicketTotal);
            grpTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpTotal.Location = new Point(10, 420);
            grpTotal.Name = "grpTotal";
            grpTotal.Size = new Size(405, 135);
            grpTotal.TabIndex = 3;
            grpTotal.TabStop = false;
            grpTotal.Text = "Chi tiết thanh toán";
            // 
            // lblGrandTotalValue
            // 
            lblGrandTotalValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblGrandTotalValue.ForeColor = Color.FromArgb(220, 53, 69);
            lblGrandTotalValue.Location = new Point(180, 95);
            lblGrandTotalValue.Name = "lblGrandTotalValue";
            lblGrandTotalValue.Size = new Size(215, 30);
            lblGrandTotalValue.TabIndex = 4;
            lblGrandTotalValue.Text = "0 VNĐ";
            lblGrandTotalValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.AutoSize = true;
            lblGrandTotal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblGrandTotal.Location = new Point(15, 98);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(130, 25);
            lblGrandTotal.TabIndex = 3;
            lblGrandTotal.Text = "TỔNG CỘNG:";
            // 
            // lblComboTotal
            // 
            lblComboTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblComboTotal.Location = new Point(15, 72);
            lblComboTotal.Name = "lblComboTotal";
            lblComboTotal.Size = new Size(380, 20);
            lblComboTotal.TabIndex = 2;
            lblComboTotal.Text = "Tiền combo bắp nước: 0đ";
            // 
            // lblDiscountTotal
            // 
            lblDiscountTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDiscountTotal.ForeColor = Color.Green;
            lblDiscountTotal.Location = new Point(15, 48);
            lblDiscountTotal.Name = "lblDiscountTotal";
            lblDiscountTotal.Size = new Size(380, 20);
            lblDiscountTotal.TabIndex = 1;
            lblDiscountTotal.Text = "Giảm giá đối tượng: 0đ";
            // 
            // lblTicketTotal
            // 
            lblTicketTotal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTicketTotal.Location = new Point(15, 25);
            lblTicketTotal.Name = "lblTicketTotal";
            lblTicketTotal.Size = new Size(380, 20);
            lblTicketTotal.TabIndex = 0;
            lblTicketTotal.Text = "Tổng tiền vé (0 ghế): 0đ";
            // 
            // grpCombos
            // 
            grpCombos.Controls.Add(panelCombos);
            grpCombos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpCombos.Location = new Point(10, 260);
            grpCombos.Name = "grpCombos";
            grpCombos.Size = new Size(405, 155);
            grpCombos.TabIndex = 2;
            grpCombos.TabStop = false;
            grpCombos.Text = "🍿 Combo bắp nước (Điểm cộng)";
            // 
            // panelCombos
            // 
            panelCombos.AutoScroll = true;
            panelCombos.Dock = DockStyle.Fill;
            panelCombos.Location = new Point(3, 23);
            panelCombos.Name = "panelCombos";
            panelCombos.Size = new Size(399, 129);
            panelCombos.TabIndex = 0;
            // 
            // grpTicketType
            // 
            grpTicketType.Controls.Add(lblStudentDiscountNote);
            grpTicketType.Controls.Add(rdoStudent);
            grpTicketType.Controls.Add(rdoAdult);
            grpTicketType.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpTicketType.Location = new Point(10, 165);
            grpTicketType.Name = "grpTicketType";
            grpTicketType.Size = new Size(405, 90);
            grpTicketType.TabIndex = 1;
            grpTicketType.TabStop = false;
            grpTicketType.Text = "Loại vé & Ưu đãi đối tượng (RadioButton)";
            // 
            // lblStudentDiscountNote
            // 
            lblStudentDiscountNote.AutoSize = true;
            lblStudentDiscountNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lblStudentDiscountNote.ForeColor = Color.FromArgb(13, 110, 253);
            lblStudentDiscountNote.Location = new Point(15, 60);
            lblStudentDiscountNote.Name = "lblStudentDiscountNote";
            lblStudentDiscountNote.Size = new Size(331, 19);
            lblStudentDiscountNote.TabIndex = 2;
            lblStudentDiscountNote.Text = "* Mức giảm giá HS-SV được cấu hình trong App.config";
            // 
            // rdoStudent
            // 
            rdoStudent.AutoSize = true;
            rdoStudent.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdoStudent.Location = new Point(190, 28);
            rdoStudent.Name = "rdoStudent";
            rdoStudent.Size = new Size(168, 24);
            rdoStudent.TabIndex = 1;
            rdoStudent.Text = "Học sinh - Sinh viên";
            rdoStudent.UseVisualStyleBackColor = true;
            rdoStudent.CheckedChanged += TicketType_CheckedChanged;
            // 
            // rdoAdult
            // 
            rdoAdult.AutoSize = true;
            rdoAdult.Checked = true;
            rdoAdult.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdoAdult.Location = new Point(20, 28);
            rdoAdult.Name = "rdoAdult";
            rdoAdult.Size = new Size(99, 24);
            rdoAdult.TabIndex = 0;
            rdoAdult.TabStop = true;
            rdoAdult.Text = "Người lớn";
            rdoAdult.UseVisualStyleBackColor = true;
            rdoAdult.CheckedChanged += TicketType_CheckedChanged;
            // 
            // grpSelectedSeats
            // 
            grpSelectedSeats.Controls.Add(lstSelectedSeats);
            grpSelectedSeats.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpSelectedSeats.Location = new Point(10, 10);
            grpSelectedSeats.Name = "grpSelectedSeats";
            grpSelectedSeats.Size = new Size(405, 150);
            grpSelectedSeats.TabIndex = 0;
            grpSelectedSeats.TabStop = false;
            grpSelectedSeats.Text = "Danh sách ghế đang chọn (ListBox)";
            // 
            // lstSelectedSeats
            // 
            lstSelectedSeats.Dock = DockStyle.Fill;
            lstSelectedSeats.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lstSelectedSeats.FormattingEnabled = true;
            lstSelectedSeats.ItemHeight = 20;
            lstSelectedSeats.Location = new Point(3, 23);
            lstSelectedSeats.Name = "lstSelectedSeats";
            lstSelectedSeats.Size = new Size(399, 124);
            lstSelectedSeats.TabIndex = 0;
            // 
            // timerAutoFilter
            // 
            timerAutoFilter.Interval = 30000;
            timerAutoFilter.Tick += timerAutoFilter_Tick;
            // 
            // FormTicketBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 750);
            Controls.Add(splitContainer);
            Controls.Add(panelTop);
            Name = "FormTicketBooking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán vé theo sơ đồ ghế & Doanh thu - Phân hệ SV3";
            Load += FormTicketBooking_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelSeatMap.ResumeLayout(false);
            panelSeatMap.PerformLayout();
            panelLegend.ResumeLayout(false);
            panelLegend.PerformLayout();
            panelCheckout.ResumeLayout(false);
            grpTotal.ResumeLayout(false);
            grpTotal.PerformLayout();
            grpCombos.ResumeLayout(false);
            grpTicketType.ResumeLayout(false);
            grpTicketType.PerformLayout();
            grpSelectedSeats.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblHeader;
        private Label lblSelectDate;
        private DateTimePicker dtpShowDate;
        private Label lblSelectShow;
        private ComboBox cboShowtimes;
        private Label lblCurrentShowInfo;
        private CheckBox chkAutoFilterPastShows;
        private SplitContainer splitContainer;
        private Label lblScreen;
        private Panel panelLegend;
        private Label boxLegendNormal;
        private Label lblLegendNormal;
        private Label boxLegendVip;
        private Label lblLegendVip;
        private Label boxLegendSelected;
        private Label lblLegendSelected;
        private Label boxLegendSold;
        private Label lblLegendSold;
        private Panel panelSeatMap;
        private Panel panelSeatsContainer;
        private Panel panelCheckout;
        private GroupBox grpSelectedSeats;
        private ListBox lstSelectedSeats;
        private GroupBox grpTicketType;
        private RadioButton rdoAdult;
        private RadioButton rdoStudent;
        private Label lblStudentDiscountNote;
        private GroupBox grpCombos;
        private FlowLayoutPanel panelCombos;
        private GroupBox grpTotal;
        private Label lblTicketTotal;
        private Label lblDiscountTotal;
        private Label lblComboTotal;
        private Label lblGrandTotal;
        private Label lblGrandTotalValue;
        private Button btnPrintAndPay;
        private Button btnResetSeats;
        private System.Windows.Forms.Timer timerAutoFilter;
    }
}
