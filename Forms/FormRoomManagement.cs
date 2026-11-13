using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormRoomManagement : Form
    {
        public FormRoomManagement()
        {
            InitializeComponent();
        }

        private void FormRoomManagement_Load(object sender, EventArgs e)
        {
            RefreshRoomList();
        }

        private void RefreshRoomList()
        {
            lvRooms.Items.Clear();
            foreach (var room in DataManager.Rooms)
            {
                var lvi = new ListViewItem(room.Id)
                {
                    Tag = room
                };
                lvi.SubItems.Add(room.Name);
                lvi.SubItems.Add(room.TotalRows.ToString());
                lvi.SubItems.Add(room.SeatsPerRow.ToString());
                lvi.SubItems.Add(room.TotalSeats.ToString());
                lvi.SubItems.Add(room.VipRows);

                lvRooms.Items.Add(lvi);
            }
        }

        private void lvRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRooms.SelectedItems.Count > 0 && lvRooms.SelectedItems[0].Tag is Room room)
            {
                txtId.Text = room.Id;
                txtName.Text = room.Name;
                txtRows.Text = room.TotalRows.ToString();
                txtSeatsPerRow.Text = room.SeatsPerRow.ToString();
                txtVipRows.Text = room.VipRows;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtRows.Clear();
            txtSeatsPerRow.Clear();
            txtVipRows.Clear();
            txtId.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: true)) return;

            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            int totalRows = int.Parse(txtRows.Text.Trim());
            int seatsPerRow = int.Parse(txtSeatsPerRow.Text.Trim());
            string vipRows = txtVipRows.Text.Trim().ToUpper();

            var newRoom = new Room(id, name, totalRows, seatsPerRow, vipRows);
            DataManager.Rooms.Add(newRoom);
            DataManager.SaveRooms();

            Logger.Log($"Thêm phòng chiếu mới: {newRoom}");
            MessageBox.Show($"Thêm phòng chiếu '{name}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshRoomList();
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: false)) return;

            string id = txtId.Text.Trim();
            var room = DataManager.GetRoomById(id);
            if (room == null)
            {
                MessageBox.Show($"Không tìm thấy phòng chiếu có mã '{id}' để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            room.Name = txtName.Text.Trim();
            room.TotalRows = int.Parse(txtRows.Text.Trim());
            room.SeatsPerRow = int.Parse(txtSeatsPerRow.Text.Trim());
            room.VipRows = txtVipRows.Text.Trim().ToUpper();

            DataManager.SaveRooms();
            Logger.Log($"Cập nhật phòng chiếu: {room}");
            MessageBox.Show($"Cập nhật thông tin phòng '{room.Name}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshRoomList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            var room = DataManager.GetRoomById(id);
            if (room == null)
            {
                MessageBox.Show($"Không tìm thấy phòng chiếu có mã '{id}'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra ràng buộc suất chiếu
            bool hasShowtime = DataManager.Showtimes.Any(s => s.RoomId.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (hasShowtime)
            {
                MessageBox.Show($"Không thể xóa phòng '{room.Name}' vì đã có suất chiếu được xếp vào phòng này!\n" +
                                "Vui lòng xóa các suất chiếu liên quan trước.",
                                "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng chiếu '{room.Name}' không?",
                                          "Xác nhận xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                DataManager.Rooms.Remove(room);
                DataManager.SaveRooms();
                Logger.Log($"Đã xóa phòng chiếu: {room}");
                MessageBox.Show("Xóa phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshRoomList();
                btnClear_Click(sender, e);
            }
        }

        private bool ValidateInputs(bool isNew)
        {
            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            string rowsStr = txtRows.Text.Trim();
            string seatsPerRowStr = txtSeatsPerRow.Text.Trim();

            // Kiểm tra không rỗng và đưa con trỏ về ô sai (Yêu cầu 3)
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Mã phòng chiếu không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return false;
            }

            if (isNew && DataManager.Rooms.Any(r => r.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Mã phòng '{id}' đã tồn tại! Vui lòng chọn mã khác.", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                txtId.SelectAll();
                return false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên phòng chiếu không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Kiểm tra số hàng bằng TryParse (Yêu cầu 3)
            if (!int.TryParse(rowsStr, out int rows) || rows < 1 || rows > 26)
            {
                MessageBox.Show("Số hàng ghế phải là số nguyên từ 1 đến 26 (tương ứng chữ cái từ A đến Z)!", "Lỗi kiểu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRows.Focus();
                txtRows.SelectAll();
                return false;
            }

            // Kiểm tra số ghế mỗi hàng bằng TryParse (Yêu cầu 3)
            if (!int.TryParse(seatsPerRowStr, out int seats) || seats < 1 || seats > 30)
            {
                MessageBox.Show("Số ghế mỗi hàng phải là số nguyên từ 1 đến 30!", "Lỗi kiểu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeatsPerRow.Focus();
                txtSeatsPerRow.SelectAll();
                return false;
            }

            return true;
        }
    }
}
