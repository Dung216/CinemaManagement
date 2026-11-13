namespace CinemaManagement.Forms
{
    partial class FormLogin
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
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            chkRememberMe = new CheckBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblHint = new Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(33, 37, 41);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(420, 85);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.ForeColor = Color.FromArgb(200, 200, 200);
            lblSubtitle.Location = new Point(12, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(396, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Hệ thống quản lý lịch chiếu & Quầy vé thông minh";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(255, 193, 7);
            lblTitle.Location = new Point(12, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(396, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎬 ĐĂNG NHẬP RẠP CHIẾU PHIM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsername.Location = new Point(45, 110);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(111, 21);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên tài khoản:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            txtUsername.Location = new Point(45, 135);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(330, 30);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblPassword.Location = new Point(45, 180);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 21);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            txtPassword.Location = new Point(45, 205);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(330, 30);
            txtPassword.TabIndex = 4;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(235, 242);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(140, 24);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(45, 242);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(147, 24);
            chkRememberMe.TabIndex = 5;
            chkRememberMe.Text = "Ghi nhớ tài khoản";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(13, 110, 253);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(45, 285);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(155, 42);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(108, 117, 125);
            btnExit.Cursor = Cursors.Hand;
            btnExit.DialogResult = DialogResult.Cancel;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(220, 285);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(155, 42);
            btnExit.TabIndex = 8;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblHint
            // 
            lblHint.ForeColor = Color.FromArgb(100, 100, 100);
            lblHint.Location = new Point(20, 345);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(380, 40);
            lblHint.TabIndex = 9;
            lblHint.Text = "Tài khoản mẫu: admin / admin123 (Quản trị)\nstaff / staff123 (Nhân viên) | Khóa sau 3 lần sai";
            lblHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(420, 395);
            Controls.Add(lblHint);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(chkRememberMe);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống - Quản lý rạp chiếu phim";
            Load += FormLogin_Load;
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelHeader;
        private Label lblSubtitle;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private CheckBox chkRememberMe;
        private Button btnLogin;
        private Button btnExit;
        private Label lblHint;
    }
}
