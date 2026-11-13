using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // Đọc tùy chọn ghi nhớ từ Registry
                if (RegistryHelper.RememberMe && !string.IsNullOrEmpty(RegistryHelper.SavedUsername))
                {
                    txtUsername.Text = RegistryHelper.SavedUsername;
                    chkRememberMe.Checked = true;
                    txtPassword.Focus();
                }
                else
                {
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi nạp cấu hình đăng nhập: {ex.Message}", ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra không rỗng và đưa con trỏ về ô sai (Yêu cầu 3)
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Tìm tài khoản trong DataManager (đọc từ users.txt)
            var user = DataManager.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                MessageBox.Show("Tài khoản không tồn tại trên hệ thống!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return;
            }

            // Kiểm tra tài khoản đã bị khóa chưa (Yêu cầu 9)
            if (user.IsLocked)
            {
                MessageBox.Show("Tài khoản này đã bị KHÓA do đăng nhập sai mật khẩu quá 3 lần liên tiếp!\n" +
                                "Vui lòng liên hệ Quản trị viên để mở khóa tài khoản.",
                                "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return;
            }

            // Kiểm tra mật khẩu
            if (user.Password != password)
            {
                user.FailedAttempts++;
                Logger.Log($"Đăng nhập sai mật khẩu lần {user.FailedAttempts}/3 đối với tài khoản '{username}'");

                if (user.FailedAttempts >= 3)
                {
                    user.IsLocked = true;
                    DataManager.SaveUsers();
                    Logger.Log($"Tài khoản '{username}' đã bị khóa do nhập sai 3 lần liên tiếp.");
                    MessageBox.Show("Bạn đã nhập sai mật khẩu 3 lần liên tiếp!\nTài khoản đã bị KHÓA để bảo đảm an toàn.",
                                    "Khóa tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    DataManager.SaveUsers();
                    int remaining = 3 - user.FailedAttempts;
                    MessageBox.Show($"Mật khẩu không chính xác!\nBạn còn {remaining} lần thử trước khi tài khoản bị khóa.",
                                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtPassword.Focus();
                txtPassword.SelectAll();
                return;
            }

            // Đăng nhập thành công -> Reset số lần sai
            user.FailedAttempts = 0;
            DataManager.SaveUsers();
            DataManager.CurrentUser = user;

            // Lưu tùy chọn người dùng vào Registry (Yêu cầu 8)
            RegistryHelper.RememberMe = chkRememberMe.Checked;
            RegistryHelper.SavedUsername = chkRememberMe.Checked ? username : string.Empty;

            Logger.Log($"Người dùng '{user.Username}' ({user.FullName} - {user.Role}) đã đăng nhập thành công.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
