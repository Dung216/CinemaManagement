namespace CinemaManagement.Forms
{
    partial class FormMovieManagement
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
            panelControls = new Panel();
            grpFilter = new GroupBox();
            btnImportCsv = new Button();
            btnViewMode = new Button();
            cboFilterGenre = new ComboBox();
            lblFilter = new Label();
            grpMovieInfo = new GroupBox();
            btnBrowsePoster = new Button();
            txtPoster = new TextBox();
            lblPoster = new Label();
            picPoster = new PictureBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnClear = new Button();
            cboAgeRating = new ComboBox();
            lblAgeRating = new Label();
            txtDuration = new TextBox();
            lblDuration = new Label();
            txtGenre = new TextBox();
            lblGenre = new Label();
            txtTitle = new TextBox();
            lblTitle = new Label();
            txtId = new TextBox();
            lblId = new Label();
            lvMovies = new ListView();
            colId = new ColumnHeader();
            colTitle = new ColumnHeader();
            colGenre = new ColumnHeader();
            colDuration = new ColumnHeader();
            colAgeRating = new ColumnHeader();
            colPoster = new ColumnHeader();
            contextMenuStrip = new ContextMenuStrip(components);
            menuSelect = new ToolStripMenuItem();
            menuEdit = new ToolStripMenuItem();
            menuDelete = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            menuSchedule = new ToolStripMenuItem();
            imageListLarge = new ImageList(components);
            panelTop.SuspendLayout();
            panelControls.SuspendLayout();
            grpFilter.SuspendLayout();
            grpMovieInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            contextMenuStrip.SuspendLayout();
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
            lblHeader.Text = "🎬 PHÂN HỆ QUẢN LÝ DANH MỤC PHIM (SV1)";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(grpFilter);
            panelControls.Controls.Add(grpMovieInfo);
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 55);
            panelControls.Name = "panelControls";
            panelControls.Padding = new Padding(10);
            panelControls.Size = new Size(1100, 310);
            panelControls.TabIndex = 1;
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(btnImportCsv);
            grpFilter.Controls.Add(btnViewMode);
            grpFilter.Controls.Add(cboFilterGenre);
            grpFilter.Controls.Add(lblFilter);
            grpFilter.Dock = DockStyle.Bottom;
            grpFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpFilter.Location = new Point(10, 245);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(1080, 55);
            grpFilter.TabIndex = 1;
            grpFilter.TabStop = false;
            grpFilter.Text = "Bộ lọc & Tiện ích";
            // 
            // btnImportCsv
            // 
            btnImportCsv.BackColor = Color.FromArgb(25, 135, 84);
            btnImportCsv.Cursor = Cursors.Hand;
            btnImportCsv.FlatStyle = FlatStyle.Flat;
            btnImportCsv.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportCsv.ForeColor = Color.White;
            btnImportCsv.Location = new Point(880, 18);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(180, 30);
            btnImportCsv.TabIndex = 3;
            btnImportCsv.Text = "📥 Nhập phim từ CSV";
            btnImportCsv.UseVisualStyleBackColor = false;
            btnImportCsv.Click += btnImportCsv_Click;
            // 
            // btnViewMode
            // 
            btnViewMode.BackColor = Color.FromArgb(108, 117, 125);
            btnViewMode.Cursor = Cursors.Hand;
            btnViewMode.FlatStyle = FlatStyle.Flat;
            btnViewMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewMode.ForeColor = Color.White;
            btnViewMode.Location = new Point(660, 18);
            btnViewMode.Name = "btnViewMode";
            btnViewMode.Size = new Size(200, 30);
            btnViewMode.TabIndex = 2;
            btnViewMode.Text = "🖼️ Đổi chế độ xem (Poster / Bảng)";
            btnViewMode.UseVisualStyleBackColor = false;
            btnViewMode.Click += btnViewMode_Click;
            // 
            // cboFilterGenre
            // 
            cboFilterGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterGenre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cboFilterGenre.FormattingEnabled = true;
            cboFilterGenre.Location = new Point(185, 20);
            cboFilterGenre.Name = "cboFilterGenre";
            cboFilterGenre.Size = new Size(240, 28);
            cboFilterGenre.TabIndex = 1;
            cboFilterGenre.SelectedIndexChanged += cboFilterGenre_SelectedIndexChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilter.Location = new Point(20, 23);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(153, 20);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Lọc phim theo thể loại:";
            // 
            // grpMovieInfo
            // 
            grpMovieInfo.Controls.Add(btnBrowsePoster);
            grpMovieInfo.Controls.Add(txtPoster);
            grpMovieInfo.Controls.Add(lblPoster);
            grpMovieInfo.Controls.Add(picPoster);
            grpMovieInfo.Controls.Add(btnDelete);
            grpMovieInfo.Controls.Add(btnUpdate);
            grpMovieInfo.Controls.Add(btnAdd);
            grpMovieInfo.Controls.Add(btnClear);
            grpMovieInfo.Controls.Add(cboAgeRating);
            grpMovieInfo.Controls.Add(lblAgeRating);
            grpMovieInfo.Controls.Add(txtDuration);
            grpMovieInfo.Controls.Add(lblDuration);
            grpMovieInfo.Controls.Add(txtGenre);
            grpMovieInfo.Controls.Add(lblGenre);
            grpMovieInfo.Controls.Add(txtTitle);
            grpMovieInfo.Controls.Add(lblTitle);
            grpMovieInfo.Controls.Add(txtId);
            grpMovieInfo.Controls.Add(lblId);
            grpMovieInfo.Dock = DockStyle.Top;
            grpMovieInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpMovieInfo.Location = new Point(10, 10);
            grpMovieInfo.Name = "grpMovieInfo";
            grpMovieInfo.Size = new Size(1080, 230);
            grpMovieInfo.TabIndex = 0;
            grpMovieInfo.TabStop = false;
            grpMovieInfo.Text = "Thông tin chi tiết phim";
            // 
            // btnBrowsePoster
            // 
            btnBrowsePoster.Cursor = Cursors.Hand;
            btnBrowsePoster.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnBrowsePoster.Location = new Point(480, 142);
            btnBrowsePoster.Name = "btnBrowsePoster";
            btnBrowsePoster.Size = new Size(90, 28);
            btnBrowsePoster.TabIndex = 11;
            btnBrowsePoster.Text = "Chọn ảnh...";
            btnBrowsePoster.UseVisualStyleBackColor = true;
            btnBrowsePoster.Click += btnBrowsePoster_Click;
            // 
            // txtPoster
            // 
            txtPoster.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtPoster.Location = new Point(110, 143);
            txtPoster.Name = "txtPoster";
            txtPoster.Size = new Size(360, 27);
            txtPoster.TabIndex = 10;
            // 
            // lblPoster
            // 
            lblPoster.AutoSize = true;
            lblPoster.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPoster.Location = new Point(20, 146);
            lblPoster.Name = "lblPoster";
            lblPoster.Size = new Size(80, 20);
            lblPoster.TabIndex = 9;
            lblPoster.Text = "File Poster:";
            // 
            // picPoster
            // 
            picPoster.BorderStyle = BorderStyle.FixedSingle;
            picPoster.Location = new Point(915, 20);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(145, 195);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabIndex = 14;
            picPoster.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(475, 185);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 34);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(13, 110, 253);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(350, 185);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 34);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(25, 135, 84);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(225, 185);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 34);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(100, 185);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 34);
            btnClear.TabIndex = 12;
            btnClear.Text = "🔄 Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // cboAgeRating
            // 
            cboAgeRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAgeRating.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cboAgeRating.FormattingEnabled = true;
            cboAgeRating.Items.AddRange(new object[] { "P - Mọi độ tuổi", "K - Dưới 13 tuổi có kèm", "T13 - Từ 13 tuổi trở lên", "T16 - Từ 16 tuổi trở lên", "T18 - Từ 18 tuổi trở lên" });
            cboAgeRating.Location = new Point(700, 103);
            cboAgeRating.Name = "cboAgeRating";
            cboAgeRating.Size = new Size(190, 28);
            cboAgeRating.TabIndex = 8;
            // 
            // lblAgeRating
            // 
            lblAgeRating.AutoSize = true;
            lblAgeRating.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblAgeRating.Location = new Point(590, 106);
            lblAgeRating.Name = "lblAgeRating";
            lblAgeRating.Size = new Size(99, 20);
            lblAgeRating.TabIndex = 7;
            lblAgeRating.Text = "Độ tuổi xem:";
            // 
            // txtDuration
            // 
            txtDuration.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtDuration.Location = new Point(700, 65);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(190, 27);
            txtDuration.TabIndex = 6;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDuration.Location = new Point(590, 68);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(106, 20);
            lblDuration.TabIndex = 5;
            lblDuration.Text = "Thời lượng (p):";
            // 
            // txtGenre
            // 
            txtGenre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtGenre.Location = new Point(110, 103);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(460, 27);
            txtGenre.TabIndex = 4;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblGenre.Location = new Point(20, 106);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(65, 20);
            lblGenre.TabIndex = 3;
            lblGenre.Text = "Thể loại:";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitle.Location = new Point(110, 65);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(460, 27);
            txtTitle.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(20, 68);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(73, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tên phim:";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(110, 28);
            txtId.Name = "txtId";
            txtId.Size = new Size(180, 27);
            txtId.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(20, 31);
            lblId.Name = "lblId";
            lblId.Size = new Size(71, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã phim:";
            // 
            // lvMovies
            // 
            lvMovies.Columns.AddRange(new ColumnHeader[] { colId, colTitle, colGenre, colDuration, colAgeRating, colPoster });
            lvMovies.ContextMenuStrip = contextMenuStrip;
            lvMovies.Dock = DockStyle.Fill;
            lvMovies.FullRowSelect = true;
            lvMovies.GridLines = true;
            lvMovies.LargeImageList = imageListLarge;
            lvMovies.Location = new Point(0, 365);
            lvMovies.MultiSelect = false;
            lvMovies.Name = "lvMovies";
            lvMovies.Size = new Size(1100, 335);
            lvMovies.TabIndex = 2;
            lvMovies.UseCompatibleStateImageBehavior = false;
            lvMovies.View = View.LargeIcon;
            lvMovies.SelectedIndexChanged += lvMovies_SelectedIndexChanged;
            // 
            // colId
            // 
            colId.Text = "Mã Phim";
            colId.Width = 90;
            // 
            // colTitle
            // 
            colTitle.Text = "Tên Phim";
            colTitle.Width = 260;
            // 
            // colGenre
            // 
            colGenre.Text = "Thể Loại";
            colGenre.Width = 180;
            // 
            // colDuration
            // 
            colDuration.Text = "Thời Lượng";
            colDuration.Width = 110;
            // 
            // colAgeRating
            // 
            colAgeRating.Text = "Độ Tuổi";
            colAgeRating.Width = 90;
            // 
            // colPoster
            // 
            colPoster.Text = "File Poster";
            colPoster.Width = 150;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { menuSelect, menuEdit, menuDelete, toolStripMenuItem1, menuSchedule });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(224, 114);
            // 
            // menuSelect
            // 
            menuSelect.Name = "menuSelect";
            menuSelect.Size = new Size(223, 24);
            menuSelect.Text = "👁️ Xem chi tiết";
            menuSelect.Click += menuSelect_Click;
            // 
            // menuEdit
            // 
            menuEdit.Name = "menuEdit";
            menuEdit.Size = new Size(223, 24);
            menuEdit.Text = "✏️ Sửa phim này";
            menuEdit.Click += menuEdit_Click;
            // 
            // menuDelete
            // 
            menuDelete.Name = "menuDelete";
            menuDelete.Size = new Size(223, 24);
            menuDelete.Text = "🗑️ Xóa phim này";
            menuDelete.Click += menuDelete_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(220, 6);
            // 
            // menuSchedule
            // 
            menuSchedule.Name = "menuSchedule";
            menuSchedule.Size = new Size(223, 24);
            menuSchedule.Text = "📅 Lên lịch suất chiếu...";
            menuSchedule.Click += menuSchedule_Click;
            // 
            // imageListLarge
            // 
            imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
            imageListLarge.ImageSize = new Size(110, 150);
            imageListLarge.TransparentColor = Color.Transparent;
            // 
            // FormMovieManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(lvMovies);
            Controls.Add(panelControls);
            Controls.Add(panelTop);
            Name = "FormMovieManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phim - Phân hệ SV1";
            Load += FormMovieManagement_Load;
            panelTop.ResumeLayout(false);
            panelControls.ResumeLayout(false);
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            grpMovieInfo.ResumeLayout(false);
            grpMovieInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblHeader;
        private Panel panelControls;
        private GroupBox grpMovieInfo;
        private TextBox txtId;
        private Label lblId;
        private TextBox txtTitle;
        private Label lblTitle;
        private TextBox txtGenre;
        private Label lblGenre;
        private TextBox txtDuration;
        private Label lblDuration;
        private ComboBox cboAgeRating;
        private Label lblAgeRating;
        private Button btnBrowsePoster;
        private TextBox txtPoster;
        private Label lblPoster;
        private PictureBox picPoster;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnClear;
        private GroupBox grpFilter;
        private Label lblFilter;
        private ComboBox cboFilterGenre;
        private Button btnViewMode;
        private Button btnImportCsv;
        private ListView lvMovies;
        private ColumnHeader colId;
        private ColumnHeader colTitle;
        private ColumnHeader colGenre;
        private ColumnHeader colDuration;
        private ColumnHeader colAgeRating;
        private ColumnHeader colPoster;
        private ImageList imageListLarge;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem menuSelect;
        private ToolStripMenuItem menuEdit;
        private ToolStripMenuItem menuDelete;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem menuSchedule;
    }
}
