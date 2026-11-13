using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
        }

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            cboRole.SelectedIndex = 0;
            RefreshUserList();
        }

        private void RefreshUserList()
        {
            lvUsers.Items.Clear();
            foreach (var u in DataManager.Users)
            {
                var lvi = new ListViewItem(u.Username) { Tag = u };
                lvi.SubItems.Add(u.FullName);
                lvi.SubItems.Add(u.Role);

                if (u.IsLocked)
                {
                    lvi.SubItems.Add("🔒 BỊ KHÓA (Quá 3 lần)");
                    lvi.ForeColor = Color.Red;
                }
                else
                {
                    lvi.SubItems.Add("✅ Bình thường");
                    lvi.ForeColor = Color.Black;
                }

                lvi.SubItems.Add(u.FailedAttempts.ToString());
                lvUsers.Items.Add(lvi);
            }
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0 && lvUsers.SelectedItems[0].Tag is User u)
            {
                txtUsername.Text = u.Username;
                txtPassword.Text = u.Password;
                txtFullName.Text = u.FullName;
                cboRole.SelectedItem = u.Role;
                btnUnlock.Enabled = u.IsLocked;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            cboRole.SelectedIndex = 0;
            btnUnlock.Enabled = false;
            txtUsername.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string role = cboRole.SelectedItem?.ToString() ?? "Staff";

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (DataManager.Users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Tên tài khoản '{username}' đã tồn tại! Vui lòng chọn tên khác.", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Họ và tên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            var newUser = new User(username, password, fullName, role, false, 0);
            DataManager.Users.Add(newUser);
            DataManager.SaveUsers();

            Logger.Log($"Thêm tài khoản mới: {newUser}");
            MessageBox.Show($"Thêm tài khoản '{username}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshUserList();
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            var user = DataManager.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                user.Password = txtPassword.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                user.FullName = txtFullName.Text.Trim();
            }

            user.Role = cboRole.SelectedItem?.ToString() ?? user.Role;
            DataManager.SaveUsers();

            Logger.Log($"Cập nhật tài khoản: {user}");
            MessageBox.Show($"Cập nhật tài khoản '{user.Username}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshUserList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            var user = DataManager.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DataManager.CurrentUser != null && DataManager.CurrentUser.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không thể xóa tài khoản hiện đang đăng nhập trên hệ thống!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var confirm = MessageBox.Show($"Xác nhận xóa tài khoản '{username}' ({user.FullName})?",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                DataManager.Users.Remove(user);
                DataManager.SaveUsers();
                Logger.Log($"Đã xóa tài khoản: {user}");
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshUserList();
                btnClear_Click(sender, e);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            var user = DataManager.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần mở khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            user.IsLocked = false;
            user.FailedAttempts = 0;
            DataManager.SaveUsers();

            Logger.Log($"Quản trị viên đã mở khóa tài khoản: {user.Username}");
            MessageBox.Show($"Đã mở khóa thành công cho tài khoản '{user.Username}'!\nSố lần thử sai đã được đặt lại về 0.",
                            "Mở khóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshUserList();
            btnUnlock.Enabled = false;
        }
    }
}
