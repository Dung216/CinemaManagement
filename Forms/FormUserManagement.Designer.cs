namespace CinemaManagement.Forms
{
    partial class FormUserManagement
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
            panelControls = new Panel();
            grpUserInfo = new GroupBox();
            btnUnlock = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnClear = new Button();
            cboRole = new ComboBox();
            lblRole = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lvUsers = new ListView();
            colUsername = new ColumnHeader();
            colFullName = new ColumnHeader();
            colRole = new ColumnHeader();
            colStatus = new ColumnHeader();
            colFailedAttempts = new ColumnHeader();
            panelTop.SuspendLayout();
            panelControls.SuspendLayout();
            grpUserInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(33, 37, 41);
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(880, 55);
            panelTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.FromArgb(255, 193, 7);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(880, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "👥 QUẢN TRỊ NGƯỜI DÙNG & MỞ KHÓA TÀI KHOẢN (ADMIN)";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(grpUserInfo);
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 55);
            panelControls.Name = "panelControls";
            panelControls.Padding = new Padding(10);
            panelControls.Size = new Size(880, 205);
            panelControls.TabIndex = 1;
            // 
            // grpUserInfo
            // 
            grpUserInfo.Controls.Add(btnUnlock);
            grpUserInfo.Controls.Add(btnDelete);
            grpUserInfo.Controls.Add(btnUpdate);
            grpUserInfo.Controls.Add(btnAdd);
            grpUserInfo.Controls.Add(btnClear);
            grpUserInfo.Controls.Add(cboRole);
            grpUserInfo.Controls.Add(lblRole);
            grpUserInfo.Controls.Add(txtFullName);
            grpUserInfo.Controls.Add(lblFullName);
            grpUserInfo.Controls.Add(txtPassword);
            grpUserInfo.Controls.Add(lblPassword);
            grpUserInfo.Controls.Add(txtUsername);
            grpUserInfo.Controls.Add(lblUsername);
            grpUserInfo.Dock = DockStyle.Fill;
            grpUserInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpUserInfo.Location = new Point(10, 10);
            grpUserInfo.Name = "grpUserInfo";
            grpUserInfo.Size = new Size(860, 185);
            grpUserInfo.TabIndex = 0;
            grpUserInfo.TabStop = false;
            grpUserInfo.Text = "Thông tin tài khoản";
            // 
            // btnUnlock
            // 
            btnUnlock.BackColor = Color.FromArgb(255, 193, 7);
            btnUnlock.Cursor = Cursors.Hand;
            btnUnlock.FlatStyle = FlatStyle.Flat;
            btnUnlock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUnlock.ForeColor = Color.Black;
            btnUnlock.Location = new Point(640, 135);
            btnUnlock.Name = "btnUnlock";
            btnUnlock.Size = new Size(160, 34);
            btnUnlock.TabIndex = 12;
            btnUnlock.Text = "🔓 Mở khóa tài khoản";
            btnUnlock.UseVisualStyleBackColor = false;
            btnUnlock.Click += btnUnlock_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(515, 135);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 34);
            btnDelete.TabIndex = 11;
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
            btnUpdate.Location = new Point(390, 135);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 34);
            btnUpdate.TabIndex = 10;
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
            btnAdd.Location = new Point(265, 135);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 34);
            btnAdd.TabIndex = 9;
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
            btnClear.Location = new Point(140, 135);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "🔄 Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "Staff", "Admin" });
            cboRole.Location = new Point(550, 78);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(250, 28);
            cboRole.TabIndex = 7;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRole.Location = new Point(440, 81);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(55, 20);
            lblRole.TabIndex = 6;
            lblRole.Text = "Vai trò:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtFullName.Location = new Point(150, 78);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 27);
            txtFullName.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblFullName.Location = new Point(30, 81);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(550, 35);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(440, 38);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(150, 35);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.Location = new Point(30, 38);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên tài khoản:";
            // 
            // lvUsers
            // 
            lvUsers.Columns.AddRange(new ColumnHeader[] { colUsername, colFullName, colRole, colStatus, colFailedAttempts });
            lvUsers.Dock = DockStyle.Fill;
            lvUsers.FullRowSelect = true;
            lvUsers.GridLines = true;
            lvUsers.Location = new Point(0, 260);
            lvUsers.MultiSelect = false;
            lvUsers.Name = "lvUsers";
            lvUsers.Size = new Size(880, 290);
            lvUsers.TabIndex = 2;
            lvUsers.UseCompatibleStateImageBehavior = false;
            lvUsers.View = View.Details;
            lvUsers.SelectedIndexChanged += lvUsers_SelectedIndexChanged;
            // 
            // colUsername
            // 
            colUsername.Text = "Tên Tài Khoản";
            colUsername.Width = 140;
            // 
            // colFullName
            // 
            colFullName.Text = "Họ và Tên";
            colFullName.Width = 240;
            // 
            // colRole
            // 
            colRole.Text = "Vai Trò";
            colRole.Width = 120;
            // 
            // colStatus
            // 
            colStatus.Text = "Trạng Thái Khóa";
            colStatus.Width = 180;
            // 
            // colFailedAttempts
            // 
            colFailedAttempts.Text = "Số Lần Sai";
            colFailedAttempts.Width = 100;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 550);
            Controls.Add(lvUsers);
            Controls.Add(panelControls);
            Controls.Add(panelTop);
            Name = "FormUserManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản trị người dùng & Mở khóa tài khoản";
            Load += FormUserManagement_Load;
            panelTop.ResumeLayout(false);
            panelControls.ResumeLayout(false);
            grpUserInfo.ResumeLayout(false);
            grpUserInfo.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblHeader;
        private Panel panelControls;
        private GroupBox grpUserInfo;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtFullName;
        private Label lblFullName;
        private ComboBox cboRole;
        private Label lblRole;
        private Button btnClear;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnUnlock;
        private ListView lvUsers;
        private ColumnHeader colUsername;
        private ColumnHeader colFullName;
        private ColumnHeader colRole;
        private ColumnHeader colStatus;
        private ColumnHeader colFailedAttempts;
    }
}
