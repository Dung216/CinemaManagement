using System.Globalization;
using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormShowtimeManagement : Form
    {
        public FormShowtimeManagement()
        {
            InitializeComponent();
        }

        private void FormShowtimeManagement_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            dtpStartTime.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1);
            RefreshTreeView();
            UpdateEndTimeInfo();
        }

        public void SelectMovie(string movieId)
        {
            for (int i = 0; i < cboMovie.Items.Count; i++)
            {
                if (cboMovie.Items[i] is Movie m && m.Id.Equals(movieId, StringComparison.OrdinalIgnoreCase))
                {
                    cboMovie.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadComboBoxes()
        {
            cboMovie.Items.Clear();
            foreach (var m in DataManager.Movies)
            {
                cboMovie.Items.Add(m);
            }
            if (cboMovie.Items.Count > 0) cboMovie.SelectedIndex = 0;

            cboRoom.Items.Clear();
            foreach (var r in DataManager.Rooms)
            {
                cboRoom.Items.Add(r);
            }
            if (cboRoom.Items.Count > 0) cboRoom.SelectedIndex = 0;
        }

        public void RefreshTreeView()
        {
            tvShowtimes.BeginUpdate();
            tvShowtimes.Nodes.Clear();

            var query = DataManager.Showtimes.AsEnumerable();
            if (!chkAllDates.Checked)
            {
                DateTime filterDate = dtpFilterDate.Value.Date;
                query = query.Where(s => s.StartTime.Date == filterDate);
            }

            var dateGroups = query
                .OrderBy(s => s.StartTime)
                .GroupBy(s => s.StartTime.Date);

            foreach (var dateGrp in dateGroups)
            {
                var dateNode = new TreeNode($"📅 Ngày {dateGrp.Key:dd/MM/yyyy} ({dateGrp.Count()} suất)")
                {
                    ForeColor = Color.DarkBlue,
                    NodeFont = new Font(tvShowtimes.Font, FontStyle.Bold)
                };

                var movieGroups = dateGrp.GroupBy(s => s.MovieId);
                foreach (var movieGrp in movieGroups)
                {
                    var movie = DataManager.GetMovieById(movieGrp.Key);
                    string movieTitle = movie != null ? $"{movie.Title} ({movie.Duration} phút - {movie.AgeRating})" : $"Phim {movieGrp.Key}";
                    var movieNode = new TreeNode($"🎬 {movieTitle} - {movieGrp.Count()} suất")
                    {
                        ForeColor = Color.FromArgb(40, 167, 69)
                    };

                    foreach (var s in movieGrp.OrderBy(x => x.StartTime))
                    {
                        var room = DataManager.GetRoomById(s.RoomId);
                        int duration = movie?.Duration ?? 90;
                        DateTime endTime = s.StartTime.AddMinutes(duration);
                        int soldCount = DataManager.Tickets.Count(t => t.ShowtimeId.Equals(s.Id, StringComparison.OrdinalIgnoreCase));
                        int totalSeats = room?.TotalSeats ?? 0;

                        string showInfo = $"⏰ {s.StartTime:HH:mm} - {endTime:HH:mm} | {room?.Name ?? s.RoomId} | {s.BasePrice:N0}đ | Đã bán: {soldCount}/{totalSeats} vé";
                        var showNode = new TreeNode(showInfo)
                        {
                            Tag = s,
                            ForeColor = soldCount > 0 ? Color.FromArgb(220, 53, 69) : Color.Black
                        };
                        movieNode.Nodes.Add(showNode);
                    }

                    dateNode.Nodes.Add(movieNode);
                }

                tvShowtimes.Nodes.Add(dateNode);
            }

            tvShowtimes.ExpandAll();
            tvShowtimes.EndUpdate();
        }

        private void chkAllDates_CheckedChanged(object sender, EventArgs e)
        {
            dtpFilterDate.Enabled = !chkAllDates.Checked;
            RefreshTreeView();
        }

        private void dtpFilterDate_ValueChanged(object sender, EventArgs e)
        {
            if (!chkAllDates.Checked)
            {
                RefreshTreeView();
            }
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            if (btnExpandAll.Text.Contains("Mở rộng"))
            {
                tvShowtimes.ExpandAll();
                btnExpandAll.Text = "📁 Thu gọn cây";
            }
            else
            {
                tvShowtimes.CollapseAll();
                btnExpandAll.Text = "📂 Mở rộng cây";
            }
        }

        private void tvShowtimes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Showtime showtime)
            {
                DisplayShowtimeDetails(showtime);
            }
        }

        private void tvShowtimes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is Showtime showtime)
            {
                OpenBookingForShowtime(showtime);
            }
        }

        private void DisplayShowtimeDetails(Showtime showtime)
        {
            txtId.Text = showtime.Id;
            dtpStartTime.Value = showtime.StartTime;
            txtBasePrice.Text = showtime.BasePrice.ToString("F0");

            for (int i = 0; i < cboMovie.Items.Count; i++)
            {
                if (cboMovie.Items[i] is Movie m && m.Id.Equals(showtime.MovieId, StringComparison.OrdinalIgnoreCase))
                {
                    cboMovie.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cboRoom.Items.Count; i++)
            {
                if (cboRoom.Items[i] is Room r && r.Id.Equals(showtime.RoomId, StringComparison.OrdinalIgnoreCase))
                {
                    cboRoom.SelectedIndex = i;
                    break;
                }
            }

            UpdateEndTimeInfo();
        }

        private void UpdateEndTimeInfo()
        {
            var movie = cboMovie.SelectedItem as Movie;
            var room = cboRoom.SelectedItem as Room;
            int cleaning = ConfigManager.CleaningTimeMinutes;
            int duration = movie?.Duration ?? 90;

            DateTime start = dtpStartTime.Value;
            DateTime endMovie = start.AddMinutes(duration);
            DateTime endClean = endMovie.AddMinutes(cleaning);

            lblEndTimeInfo.Text = $"🎬 Phim: {movie?.Title ?? "N/A"} ({duration} phút)\n" +
                                  $"🏛️ Phòng chiếu: {room?.Name ?? "N/A"}\n" +
                                  $"⏱️ Thời gian chiếu: {start:HH:mm} - {endMovie:HH:mm}\n" +
                                  $"🧹 Kết thúc dọn phòng (+{cleaning}p): {endClean:HH:mm} (Chiếm phòng đến giờ này)";
        }

        private void cboMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEndTimeInfo();
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndTimeInfo();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtBasePrice.Text = "80000";
            dtpStartTime.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1);
            if (cboMovie.Items.Count > 0) cboMovie.SelectedIndex = 0;
            if (cboRoom.Items.Count > 0) cboRoom.SelectedIndex = 0;
            txtId.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: true)) return;

            string id = txtId.Text.Trim();
            var movie = (Movie)cboMovie.SelectedItem!;
            var room = (Room)cboRoom.SelectedItem!;
            DateTime startTime = dtpStartTime.Value;
            decimal basePrice = decimal.Parse(txtBasePrice.Text.Trim());

            var newShowtime = new Showtime(id, movie.Id, room.Id, startTime, basePrice);

            // Thuật toán kiểm tra không cho hai suất chồng giờ trong cùng phòng (Yêu cầu SV2)
            if (!DataManager.ValidateShowtimeConflict(newShowtime, out string conflictMessage))
            {
                MessageBox.Show(conflictMessage, "Xung đột lịch chiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartTime.Focus();
                return;
            }

            DataManager.Showtimes.Add(newShowtime);
            DataManager.SaveShowtimes();

            Logger.Log($"Lên lịch suất chiếu mới: {newShowtime}");
            MessageBox.Show($"Lên lịch suất chiếu '{id}' thành công!\n" +
                            $"Phim: {movie.Title}\nPhòng: {room.Name}\nGiờ chiếu: {startTime:dd/MM/yyyy HH:mm}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshTreeView();
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: false)) return;

            string id = txtId.Text.Trim();
            var showtime = DataManager.GetShowtimeById(id);
            if (showtime == null)
            {
                MessageBox.Show($"Không tìm thấy suất chiếu có mã '{id}' để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            var movie = (Movie)cboMovie.SelectedItem!;
            var room = (Room)cboRoom.SelectedItem!;
            DateTime startTime = dtpStartTime.Value;
            decimal basePrice = decimal.Parse(txtBasePrice.Text.Trim());

            var updatedShowtime = new Showtime(id, movie.Id, room.Id, startTime, basePrice);

            // Kiểm tra xung đột lịch
            if (!DataManager.ValidateShowtimeConflict(updatedShowtime, out string conflictMessage))
            {
                MessageBox.Show(conflictMessage, "Xung đột lịch chiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartTime.Focus();
                return;
            }

            showtime.MovieId = movie.Id;
            showtime.RoomId = room.Id;
            showtime.StartTime = startTime;
            showtime.BasePrice = basePrice;

            DataManager.SaveShowtimes();
            Logger.Log($"Cập nhật suất chiếu: {showtime}");
            MessageBox.Show("Cập nhật thông tin suất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshTreeView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Vui lòng chọn suất chiếu cần hủy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            var showtime = DataManager.GetShowtimeById(id);
            if (showtime == null)
            {
                MessageBox.Show($"Không tìm thấy suất chiếu có mã '{id}'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hủy suất chưa bán vé (Yêu cầu SV2): Nếu đã bán vé -> KHÔNG CHO HỦY
            if (DataManager.HasSoldTickets(id))
            {
                int ticketCount = DataManager.Tickets.Count(t => t.ShowtimeId.Equals(id, StringComparison.OrdinalIgnoreCase));
                MessageBox.Show($"Không thể hủy suất chiếu '{id}' vì suất này đã bán ra {ticketCount} vé cho khán giả!\n" +
                                "Để hủy suất này, quý khách phải hoàn/trả toàn bộ các vé đã bán trước.",
                                "Từ chối hủy suất chiếu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var movie = DataManager.GetMovieById(showtime.MovieId);
            var confirm = MessageBox.Show($"Xác nhận hủy suất chiếu '{showtime.Id}'?\nPhim: {movie?.Title}\nGiờ chiếu: {showtime.StartTime:dd/MM/yyyy HH:mm}",
                                          "Xác nhận hủy suất chiếu chưa bán vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                DataManager.Showtimes.Remove(showtime);
                DataManager.SaveShowtimes();
                Logger.Log($"Đã hủy suất chiếu: {showtime}");
                MessageBox.Show("Hủy suất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshTreeView();
                btnClear_Click(sender, e);
            }
        }

        private bool ValidateInputs(bool isNew)
        {
            string id = txtId.Text.Trim();
            string priceStr = txtBasePrice.Text.Trim();

            // Kiểm tra không rỗng và đưa con trỏ về ô sai (Yêu cầu 3)
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Mã suất chiếu không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return false;
            }

            if (isNew && DataManager.Showtimes.Any(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Mã suất chiếu '{id}' đã tồn tại! Vui lòng chọn mã khác.", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                txtId.SelectAll();
                return false;
            }

            if (cboMovie.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim cho suất chiếu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMovie.Focus();
                return false;
            }

            if (cboRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRoom.Focus();
                return false;
            }

            // Kiểm tra giá vé bằng TryParse (Yêu cầu 3)
            if (!decimal.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal basePrice) &&
                !decimal.TryParse(priceStr, out basePrice) || basePrice <= 0)
            {
                MessageBox.Show("Giá vé cơ bản phải là số dương hợp lệ (VNĐ)!", "Lỗi kiểu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBasePrice.Focus();
                txtBasePrice.SelectAll();
                return false;
            }

            return true;
        }

        private void btnBookSelected_Click(object sender, EventArgs e)
        {
            if (tvShowtimes.SelectedNode?.Tag is Showtime showtime)
            {
                OpenBookingForShowtime(showtime);
            }
            else
            {
                MessageBox.Show("Vui lòng nhấp chọn một suất chiếu cụ thể trên cây lịch chiếu để bán vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenBookingForShowtime(Showtime showtime)
        {
            if (MdiParent is FormMain main)
            {
                main.OpenTicketBookingWithShowtime(showtime.Id);
            }
        }

        private void menuTreeSelect_Click(object sender, EventArgs e)
        {
            if (tvShowtimes.SelectedNode?.Tag is Showtime showtime)
            {
                DisplayShowtimeDetails(showtime);
            }
        }

        private void menuTreeBook_Click(object sender, EventArgs e)
        {
            btnBookSelected_Click(sender, e);
        }

        private void menuTreeDelete_Click(object sender, EventArgs e)
        {
            if (tvShowtimes.SelectedNode?.Tag is Showtime showtime)
            {
                DisplayShowtimeDetails(showtime);
                btnDelete_Click(sender, e);
            }
        }
    }
}
