using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormTicketRefund : Form
    {
        private Ticket? _selectedTicket = null;
        private Showtime? _selectedShowtime = null;

        public FormTicketRefund()
        {
            InitializeComponent();
        }

        private void FormTicketRefund_Load(object sender, EventArgs e)
        {
            RefreshTicketsList();
        }

        private void RefreshTicketsList()
        {
            lvRecentTickets.Items.Clear();

            var tickets = DataManager.Tickets
                .OrderByDescending(t => t.SaleTime)
                .ToList();

            foreach (var t in tickets)
            {
                var s = DataManager.GetShowtimeById(t.ShowtimeId);
                var m = s != null ? DataManager.GetMovieById(s.MovieId) : null;
                var r = s != null ? DataManager.GetRoomById(s.RoomId) : null;

                var lvi = new ListViewItem(t.Id) { Tag = t };
                lvi.SubItems.Add(t.ShowtimeId);
                lvi.SubItems.Add(m?.Title ?? "N/A");
                lvi.SubItems.Add(r?.Name ?? "N/A");
                lvi.SubItems.Add(t.SeatCode);
                lvi.SubItems.Add($"{t.Price:N0}đ");
                lvi.SubItems.Add(s != null ? s.StartTime.ToString("dd/MM/yyyy HH:mm") : "N/A");

                if (s != null)
                {
                    TimeSpan remaining = s.StartTime - DateTime.Now;
                    if (remaining.TotalMinutes >= ConfigManager.RefundTimeLimitMinutes)
                    {
                        lvi.SubItems.Add("✅ Được trả vé");
                        lvi.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        lvi.SubItems.Add("❌ Không được trả");
                        lvi.ForeColor = Color.Gray;
                    }
                }
                else
                {
                    lvi.SubItems.Add("N/A");
                }

                lvRecentTickets.Items.Add(lvi);
            }
        }

        private void lvRecentTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRecentTickets.SelectedItems.Count > 0 && lvRecentTickets.SelectedItems[0].Tag is Ticket ticket)
            {
                DisplayTicketDetails(ticket);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtTicketId.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                RefreshTicketsList();
                return;
            }

            var ticket = DataManager.Tickets.FirstOrDefault(t => t.Id.Equals(keyword, StringComparison.OrdinalIgnoreCase) ||
                                                                t.SeatCode.Equals(keyword, StringComparison.OrdinalIgnoreCase));
            if (ticket != null)
            {
                DisplayTicketDetails(ticket);

                // Highlight item trong listview nếu có
                foreach (ListViewItem item in lvRecentTickets.Items)
                {
                    if (item.Tag is Ticket t && t.Id == ticket.Id)
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Không tìm thấy vé nào phù hợp với từ khóa '{keyword}'!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTicketId.Focus();
                txtTicketId.SelectAll();
            }
        }

        private void DisplayTicketDetails(Ticket ticket)
        {
            _selectedTicket = ticket;
            _selectedShowtime = DataManager.GetShowtimeById(ticket.ShowtimeId);

            var movie = _selectedShowtime != null ? DataManager.GetMovieById(_selectedShowtime.MovieId) : null;
            var room = _selectedShowtime != null ? DataManager.GetRoomById(_selectedShowtime.RoomId) : null;

            lblTicketCode.Text = $"🎫 Mã vé: {ticket.Id} ({ticket.TicketType})";
            lblSeatCode.Text = $"🪑 Vị trí ghế: {ticket.SeatCode}  |  💵 Giá bán: {ticket.Price:N0} VNĐ";
            lblMovieTitle.Text = $"🎬 Tên phim: {movie?.Title ?? "N/A"} ({movie?.Duration} phút)";
            lblRoomInfo.Text = $"🏛️ Phòng chiếu: {room?.Name ?? "N/A"}";
            lblShowtimeTime.Text = $"⏰ Giờ chiếu: {_selectedShowtime?.StartTime:dd/MM/yyyy HH:mm}";

            if (_selectedShowtime != null)
            {
                TimeSpan remaining = _selectedShowtime.StartTime - DateTime.Now;
                lblTimeRemaining.Text = $"⏱️ Thời gian còn lại: {(remaining.TotalMinutes > 0 ? $"{remaining.TotalMinutes:N0} phút" : "Đã qua giờ chiếu")}";

                int limitMins = ConfigManager.RefundTimeLimitMinutes;
                if (remaining.TotalMinutes >= limitMins)
                {
                    lblEligibility.Text = $"✅ HỢP LỆ ĐỂ TRẢ VÉ!\n(Thời gian còn lại {remaining.TotalMinutes:N0} phút >= {limitMins} phút quy định)";
                    lblEligibility.BackColor = Color.FromArgb(212, 237, 218);
                    lblEligibility.ForeColor = Color.FromArgb(21, 87, 36);
                    btnProcessRefund.Enabled = true;
                }
                else
                {
                    lblEligibility.Text = $"❌ KHÔNG ĐƯỢC PHÉP TRẢ VÉ!\n(Suất chiếu bắt đầu trong vòng {limitMins} phút hoặc đã kết thúc)";
                    lblEligibility.BackColor = Color.FromArgb(248, 215, 218);
                    lblEligibility.ForeColor = Color.FromArgb(114, 28, 36);
                    btnProcessRefund.Enabled = false;
                }
            }
            else
            {
                lblTimeRemaining.Text = "⏱️ Thời gian còn lại: N/A";
                lblEligibility.Text = "Không tìm thấy thông tin suất chiếu!";
                btnProcessRefund.Enabled = false;
            }
        }

        private void btnProcessRefund_Click(object sender, EventArgs e)
        {
            if (_selectedTicket == null || _selectedShowtime == null) return;

            // Kiểm tra lại quy tắc trả vé 1 tiếng
            if (!DataManager.CheckTicketRefundable(_selectedTicket.Id, out var ticket, out var showtime, out string message))
            {
                MessageBox.Show(message, "Từ chối trả vé", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var confirm = MessageBox.Show($"Xác nhận trả vé '{ticket!.Id}' ghế {ticket.SeatCode}?\n" +
                                          $"Số tiền hoàn trả lại cho khách: {ticket.Price:N0} VNĐ.\n" +
                                          "Ghế này sẽ được giải phóng và có thể bán lại ngay lập tức.",
                                          "Xác nhận hoàn tiền & Trả vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                DataManager.Tickets.Remove(ticket);
                DataManager.SaveTickets();

                Logger.Log($"Đã hoàn trả vé {ticket.Id} (Ghế: {ticket.SeatCode}, Giá: {ticket.Price:N0}đ, Suất: {ticket.ShowtimeId})");
                MessageBox.Show($"Hoàn trả vé thành công!\nĐã hoàn {ticket.Price:N0} VNĐ cho khách hàng.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshTicketsList();
                _selectedTicket = null;
                _selectedShowtime = null;
                btnProcessRefund.Enabled = false;
                lblEligibility.Text = "Vui lòng chọn vé để kiểm tra điều kiện hoàn trả";
                lblEligibility.BackColor = Color.FromArgb(240, 240, 240);
                lblEligibility.ForeColor = Color.Black;
                lblTicketCode.Text = "🎫 Mã vé: --";
                lblSeatCode.Text = "🪑 Vị trí ghế & Giá: --";
                lblMovieTitle.Text = "🎬 Tên phim: --";
                lblRoomInfo.Text = "🏛️ Phòng chiếu: --";
                lblShowtimeTime.Text = "⏰ Giờ chiếu: --";
                lblTimeRemaining.Text = "⏱️ Thời gian còn lại: --";
            }
        }
    }
}
