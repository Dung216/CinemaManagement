namespace CinemaManagement.Forms
{
    partial class FormShowtimeManagement
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
            lblHeader = new Label();
            splitContainer = new SplitContainer();
            tvShowtimes = new TreeView();
            contextMenuTree = new ContextMenuStrip(components);
            menuTreeSelect = new ToolStripMenuItem();
            menuTreeBook = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            menuTreeDelete = new ToolStripMenuItem();
            panelTreeFilter = new Panel();
            btnExpandAll = new Button();
            btnBookSelected = new Button();
            dtpFilterDate = new DateTimePicker();
            chkAllDates = new CheckBox();
            lblTreeTitle = new Label();
            grpSchedule = new GroupBox();
            lblEndTimeInfo = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnClear = new Button();
            txtBasePrice = new TextBox();
            lblBasePrice = new Label();
            dtpStartTime = new DateTimePicker();
            lblStartTime = new Label();
            cboRoom = new ComboBox();
            lblRoom = new Label();
            cboMovie = new ComboBox();
            lblMovie = new Label();
            txtId = new TextBox();
            lblId = new Label();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            contextMenuTree.SuspendLayout();
            panelTreeFilter.SuspendLayout();
            grpSchedule.SuspendLayout();
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
            lblHeader.Text = "📅 PHÂN HỆ QUẢN LÝ SUẤT CHIẾU & LỊCH CHIẾU (SV2)";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 55);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(tvShowtimes);
            splitContainer.Panel1.Controls.Add(panelTreeFilter);
            splitContainer.Panel1.Padding = new Padding(10);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(grpSchedule);
            splitContainer.Panel2.Padding = new Padding(10);
            splitContainer.Size = new Size(1100, 625);
            splitContainer.SplitterDistance = 580;
            splitContainer.TabIndex = 1;
            // 
            // tvShowtimes
            // 
            tvShowtimes.ContextMenuStrip = contextMenuTree;
            tvShowtimes.Dock = DockStyle.Fill;
            tvShowtimes.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            tvShowtimes.Location = new Point(10, 110);
            tvShowtimes.Name = "tvShowtimes";
            tvShowtimes.Size = new Size(560, 505);
            tvShowtimes.TabIndex = 1;
            tvShowtimes.AfterSelect += tvShowtimes_AfterSelect;
            tvShowtimes.NodeMouseDoubleClick += tvShowtimes_NodeMouseDoubleClick;
            // 
            // contextMenuTree
            // 
            contextMenuTree.ImageScalingSize = new Size(20, 20);
            contextMenuTree.Items.AddRange(new ToolStripItem[] { menuTreeSelect, menuTreeBook, toolStripMenuItem1, menuTreeDelete });
            contextMenuTree.Name = "contextMenuTree";
            contextMenuTree.Size = new Size(224, 82);
            // 
            // menuTreeSelect
            // 
            menuTreeSelect.Name = "menuTreeSelect";
            menuTreeSelect.Size = new Size(223, 24);
            menuTreeSelect.Text = "👁️ Xem chi tiết";
            menuTreeSelect.Click += menuTreeSelect_Click;
            // 
            // menuTreeBook
            // 
            menuTreeBook.Name = "menuTreeBook";
            menuTreeBook.Size = new Size(223, 24);
            menuTreeBook.Text = "🎟️ Bán vé suất này";
            menuTreeBook.Click += menuTreeBook_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(220, 6);
            // 
            // menuTreeDelete
            // 
            menuTreeDelete.Name = "menuTreeDelete";
            menuTreeDelete.Size = new Size(223, 24);
            menuTreeDelete.Text = "🗑️ Hủy suất chiếu";
            menuTreeDelete.Click += menuTreeDelete_Click;
            // 
            // panelTreeFilter
            // 
            panelTreeFilter.Controls.Add(btnExpandAll);
            panelTreeFilter.Controls.Add(btnBookSelected);
            panelTreeFilter.Controls.Add(dtpFilterDate);
            panelTreeFilter.Controls.Add(chkAllDates);
            panelTreeFilter.Controls.Add(lblTreeTitle);
            panelTreeFilter.Dock = DockStyle.Top;
            panelTreeFilter.Location = new Point(10, 10);
            panelTreeFilter.Name = "panelTreeFilter";
            panelTreeFilter.Size = new Size(560, 100);
            panelTreeFilter.TabIndex = 0;
            // 
            // btnExpandAll
            // 
            btnExpandAll.Cursor = Cursors.Hand;
            btnExpandAll.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnExpandAll.Location = new Point(410, 62);
            btnExpandAll.Name = "btnExpandAll";
            btnExpandAll.Size = new Size(140, 30);
            btnExpandAll.TabIndex = 4;
            btnExpandAll.Text = "📂 Mở rộng cây";
            btnExpandAll.UseVisualStyleBackColor = true;
            btnExpandAll.Click += btnExpandAll_Click;
            // 
            // btnBookSelected
            // 
            btnBookSelected.BackColor = Color.FromArgb(25, 135, 84);
            btnBookSelected.Cursor = Cursors.Hand;
            btnBookSelected.FlatStyle = FlatStyle.Flat;
            btnBookSelected.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBookSelected.ForeColor = Color.White;
            btnBookSelected.Location = new Point(245, 62);
            btnBookSelected.Name = "btnBookSelected";
            btnBookSelected.Size = new Size(155, 30);
            btnBookSelected.TabIndex = 3;
            btnBookSelected.Text = "🎟️ Bán vé suất này";
            btnBookSelected.UseVisualStyleBackColor = false;
            btnBookSelected.Click += btnBookSelected_Click;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.CustomFormat = "dd/MM/yyyy";
            dtpFilterDate.Format = DateTimePickerFormat.Custom;
            dtpFilterDate.Location = new Point(125, 63);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(110, 27);
            dtpFilterDate.TabIndex = 2;
            dtpFilterDate.ValueChanged += dtpFilterDate_ValueChanged;
            // 
            // chkAllDates
            // 
            chkAllDates.AutoSize = true;
            chkAllDates.Checked = true;
            chkAllDates.CheckState = CheckState.Checked;
            chkAllDates.Location = new Point(10, 65);
            chkAllDates.Name = "chkAllDates";
            chkAllDates.Size = new Size(106, 24);
            chkAllDates.TabIndex = 1;
            chkAllDates.Text = "Tất cả ngày";
            chkAllDates.UseVisualStyleBackColor = true;
            chkAllDates.CheckedChanged += chkAllDates_CheckedChanged;
            // 
            // lblTreeTitle
            // 
            lblTreeTitle.AutoSize = true;
            lblTreeTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTreeTitle.ForeColor = Color.FromArgb(13, 110, 253);
            lblTreeTitle.Location = new Point(6, 10);
            lblTreeTitle.Name = "lblTreeTitle";
            lblTreeTitle.Size = new Size(330, 25);
            lblTreeTitle.TabIndex = 0;
            lblTreeTitle.Text = "🌳 CÂY LỊCH CHIẾU: NGÀY ➜ PHIM ➜ SUẤT";
            // 
            // grpSchedule
            // 
            grpSchedule.Controls.Add(lblEndTimeInfo);
            grpSchedule.Controls.Add(btnDelete);
            grpSchedule.Controls.Add(btnUpdate);
            grpSchedule.Controls.Add(btnAdd);
            grpSchedule.Controls.Add(btnClear);
            grpSchedule.Controls.Add(txtBasePrice);
            grpSchedule.Controls.Add(lblBasePrice);
            grpSchedule.Controls.Add(dtpStartTime);
            grpSchedule.Controls.Add(lblStartTime);
            grpSchedule.Controls.Add(cboRoom);
            grpSchedule.Controls.Add(lblRoom);
            grpSchedule.Controls.Add(cboMovie);
            grpSchedule.Controls.Add(lblMovie);
            grpSchedule.Controls.Add(txtId);
            grpSchedule.Controls.Add(lblId);
            grpSchedule.Dock = DockStyle.Fill;
            grpSchedule.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpSchedule.Location = new Point(10, 10);
            grpSchedule.Name = "grpSchedule";
            grpSchedule.Size = new Size(496, 605);
            grpSchedule.TabIndex = 0;
            grpSchedule.TabStop = false;
            grpSchedule.Text = "Lên lịch suất chiếu mới";
            // 
            // lblEndTimeInfo
            // 
            lblEndTimeInfo.BackColor = Color.FromArgb(240, 245, 255);
            lblEndTimeInfo.BorderStyle = BorderStyle.FixedSingle;
            lblEndTimeInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEndTimeInfo.ForeColor = Color.FromArgb(30, 60, 114);
            lblEndTimeInfo.Location = new Point(20, 290);
            lblEndTimeInfo.Name = "lblEndTimeInfo";
            lblEndTimeInfo.Padding = new Padding(10);
            lblEndTimeInfo.Size = new Size(455, 90);
            lblEndTimeInfo.TabIndex = 14;
            lblEndTimeInfo.Text = "ℹ️ Quy tắc chống trùng lịch: Thời gian chiếm phòng = Thời lượng phim + 15 phút dọn phòng. Hệ thống tự động kiểm tra và ngăn chặn hai suất chồng giờ trong cùng phòng.";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(365, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 40);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "🗑️ Hủy suất";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(13, 110, 253);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(250, 410);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 40);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(25, 135, 84);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(135, 410);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 40);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "➕ Lên lịch";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(20, 410);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 40);
            btnClear.TabIndex = 10;
            btnClear.Text = "🔄 Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtBasePrice
            // 
            txtBasePrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtBasePrice.Location = new Point(160, 235);
            txtBasePrice.Name = "txtBasePrice";
            txtBasePrice.Size = new Size(315, 29);
            txtBasePrice.TabIndex = 9;
            txtBasePrice.Text = "80000";
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBasePrice.Location = new Point(20, 240);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(125, 20);
            lblBasePrice.TabIndex = 8;
            lblBasePrice.Text = "Giá vé cơ bản (đ):";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpStartTime.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(160, 185);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(315, 29);
            dtpStartTime.TabIndex = 7;
            dtpStartTime.ValueChanged += dtpStartTime_ValueChanged;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblStartTime.Location = new Point(20, 190);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(108, 20);
            lblStartTime.TabIndex = 6;
            lblStartTime.Text = "Ngày giờ chiếu:";
            // 
            // cboRoom
            // 
            cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoom.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(160, 135);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(315, 29);
            cboRoom.TabIndex = 5;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRoom.Location = new Point(20, 140);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(94, 20);
            lblRoom.TabIndex = 4;
            lblRoom.Text = "Phòng chiếu:";
            // 
            // cboMovie
            // 
            cboMovie.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMovie.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cboMovie.FormattingEnabled = true;
            cboMovie.Location = new Point(160, 85);
            cboMovie.Name = "cboMovie";
            cboMovie.Size = new Size(315, 29);
            cboMovie.TabIndex = 3;
            cboMovie.SelectedIndexChanged += cboMovie_SelectedIndexChanged;
            // 
            // lblMovie
            // 
            lblMovie.AutoSize = true;
            lblMovie.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMovie.Location = new Point(20, 90);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(84, 20);
            lblMovie.TabIndex = 2;
            lblMovie.Text = "Chọn phim:";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(160, 35);
            txtId.Name = "txtId";
            txtId.Size = new Size(315, 29);
            txtId.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(20, 40);
            lblId.Name = "lblId";
            lblId.Size = new Size(130, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã suất chiếu (SC):";
            // 
            // FormShowtimeManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 680);
            Controls.Add(splitContainer);
            Controls.Add(panelTop);
            Name = "FormShowtimeManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý suất chiếu & Cây lịch chiếu - Phân hệ SV2";
            Load += FormShowtimeManagement_Load;
            panelTop.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            contextMenuTree.ResumeLayout(false);
            panelTreeFilter.ResumeLayout(false);
            panelTreeFilter.PerformLayout();
            grpSchedule.ResumeLayout(false);
            grpSchedule.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblHeader;
        private SplitContainer splitContainer;
        private Panel panelTreeFilter;
        private Label lblTreeTitle;
        private DateTimePicker dtpFilterDate;
        private CheckBox chkAllDates;
        private Button btnBookSelected;
        private Button btnExpandAll;
        private TreeView tvShowtimes;
        private GroupBox grpSchedule;
        private TextBox txtId;
        private Label lblId;
        private ComboBox cboMovie;
        private Label lblMovie;
        private ComboBox cboRoom;
        private Label lblRoom;
        private DateTimePicker dtpStartTime;
        private Label lblStartTime;
        private TextBox txtBasePrice;
        private Label lblBasePrice;
        private Label lblEndTimeInfo;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnClear;
        private ContextMenuStrip contextMenuTree;
        private ToolStripMenuItem menuTreeSelect;
        private ToolStripMenuItem menuTreeBook;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem menuTreeDelete;
    }
}
