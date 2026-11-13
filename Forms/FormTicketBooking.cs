using System.Diagnostics;
using System.Text;
using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormTicketBooking : Form
    {
        private Showtime? _selectedShowtime = null;
        private readonly List<string> _selectedSeats = new List<string>();
        private readonly Dictionary<string, NumericUpDown> _comboCounters = new Dictionary<string, NumericUpDown>();

        // Màu sắc chuẩn theo yêu cầu
        private static readonly Color ColorNormalSeat = Color.FromArgb(235, 240, 250);
        private static readonly Color ColorVipSeat = Color.FromArgb(255, 193, 7);
        private static readonly Color ColorSelectedSeat = Color.FromArgb(13, 110, 253);
        private static readonly Color ColorSoldSeat = Color.FromArgb(220, 53, 69);

        public FormTicketBooking()
        {
            InitializeComponent();
        }

        private void FormTicketBooking_Load(object sender, EventArgs e)
        {
            lblStudentDiscountNote.Text = $"* Học sinh - Sinh viên được giảm {ConfigManager.StudentDiscountPercent}% giá vé (cấu hình trong App.config)";
            LoadCombosUi();
            dtpShowDate.Value = DateTime.Today;
            LoadShowtimesForDate();

            // Khởi động Timer tự ẩn suất chiếu đã qua (Yêu cầu nâng cao)
            timerAutoFilter.Start();
        }

        public void SelectShowtimeById(string showtimeId)
        {
            var showtime = DataManager.GetShowtimeById(showtimeId);
            if (showtime != null)
            {
                dtpShowDate.Value = showtime.StartTime.Date;
                LoadShowtimesForDate();

                for (int i = 0; i < cboShowtimes.Items.Count; i++)
                {
                    if (cboShowtimes.Items[i] is Showtime s && s.Id.Equals(showtimeId, StringComparison.OrdinalIgnoreCase))
                    {
                        cboShowtimes.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void LoadCombosUi()
        {
            panelCombos.Controls.Clear();
            _comboCounters.Clear();

            foreach (var combo in DataManager.Combos)
            {
                var panelItem = new Panel
                {
                    Width = panelCombos.Width - 25,
                    Height = 36,
                    Margin = new Padding(2)
                };

                var lblName = new Label
                {
                    Text = $"{combo.Name} ({combo.Price:N0}đ)",
                    Width = 260,
                    Location = new Point(0, 8),
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Regular)
                };

                var nudQty = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = 20,
                    Value = 0,
                    Width = 55,
                    Location = new Point(270, 5),
                    Tag = combo
                };
                nudQty.ValueChanged += (s, e) => CalculateTotal();

                panelItem.Controls.Add(lblName);
                panelItem.Controls.Add(nudQty);
                panelCombos.Controls.Add(panelItem);

                _comboCounters[combo.Id] = nudQty;
            }
        }

        private void dtpShowDate_ValueChanged(object sender, EventArgs e)
        {
            LoadShowtimesForDate();
        }

        private void chkAutoFilterPastShows_CheckedChanged(object sender, EventArgs e)
        {
            LoadShowtimesForDate();
        }

        private void timerAutoFilter_Tick(object sender, EventArgs e)
        {
            // Timer định kỳ kiểm tra và ẩn các suất đã bắt đầu chiếu khỏi danh sách
            if (chkAutoFilterPastShows.Checked && dtpShowDate.Value.Date == DateTime.Today)
            {
                // Kiểm tra xem trong dropdown hiện tại có suất nào đã bắt đầu chiếu chưa
                bool hasExpired = false;
                foreach (var item in cboShowtimes.Items)
                {
                    if (item is Showtime s && s.StartTime < DateTime.Now)
                    {
                        hasExpired = true;
                        break;
                    }
                }

                if (hasExpired)
                {
                    string currentSelectedId = _selectedShowtime?.Id ?? "";
                    LoadShowtimesForDate();

                    // Nếu suất đang chọn bị hết hạn
                    if (!string.IsNullOrEmpty(currentSelectedId) &&
                        !cboShowtimes.Items.OfType<Showtime>().Any(s => s.Id == currentSelectedId))
                    {
                        MessageBox.Show("Suất chiếu đang chọn vừa bắt đầu giờ chiếu và đã tự động đóng bán vé!",
                                        "Thông báo Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void LoadShowtimesForDate()
        {
            DateTime selectedDate = dtpShowDate.Value.Date;
            bool filterPast = chkAutoFilterPastShows.Checked;
            DateTime now = DateTime.Now;

            var shows = DataManager.Showtimes
                .Where(s => s.StartTime.Date == selectedDate)
                .Where(s => !filterPast || s.StartTime >= now)
                .OrderBy(s => s.StartTime)
                .ToList();

            cboShowtimes.Items.Clear();
            foreach (var s in shows)
            {
                cboShowtimes.Items.Add(s);
            }

            if (cboShowtimes.Items.Count > 0)
            {
                cboShowtimes.SelectedIndex = 0;
            }
            else
            {
                _selectedShowtime = null;
                lblCurrentShowInfo.Text = "Không có suất chiếu phù hợp cho ngày này hoặc các suất đều đã qua giờ chiếu.";
                panelSeatsContainer.Controls.Clear();
                _selectedSeats.Clear();
                lstSelectedSeats.Items.Clear();
                CalculateTotal();
            }
        }

        private void cboShowtimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedShowtime = cboShowtimes.SelectedItem as Showtime;
            _selectedSeats.Clear();
            lstSelectedSeats.Items.Clear();

            if (_selectedShowtime == null) return;

            var movie = DataManager.GetMovieById(_selectedShowtime.MovieId);
            var room = DataManager.GetRoomById(_selectedShowtime.RoomId);

            int soldCount = DataManager.Tickets.Count(t => t.ShowtimeId.Equals(_selectedShowtime.Id, StringComparison.OrdinalIgnoreCase));
            int totalSeats = room?.TotalSeats ?? 0;

            lblCurrentShowInfo.Text = $"🎬 Phim: {movie?.Title ?? "N/A"} ({movie?.AgeRating}) | " +
                                      $"🏛️ {room?.Name ?? "N/A"} | " +
                                      $"⏰ Giờ chiếu: {_selectedShowtime.StartTime:dd/MM/yyyy HH:mm} | " +
                                      $"💵 Giá cơ bản: {_selectedShowtime.BasePrice:N0}đ | " +
                                      $"📊 Đã bán: {soldCount}/{totalSeats} ghế";

            GenerateSeatMap();
            CalculateTotal();
        }

        // Tạo sơ đồ ghế bằng Button tạo bằng code (Yêu cầu SV3)
        private void GenerateSeatMap()
        {
            panelSeatsContainer.Controls.Clear();
            if (_selectedShowtime == null) return;

            var room = DataManager.GetRoomById(_selectedShowtime.RoomId);
            if (room == null) return;

            // Lấy danh sách ghế đã bán cho suất chiếu này (không bán trùng ghế)
            var soldSeats = DataManager.Tickets
                .Where(t => t.ShowtimeId.Equals(_selectedShowtime.Id, StringComparison.OrdinalIgnoreCase))
                .Select(t => t.SeatCode)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            int buttonWidth = 52;
            int buttonHeight = 44;
            int marginX = 8;
            int marginY = 8;

            panelSeatsContainer.SuspendLayout();

            for (int r = 0; r < room.TotalRows; r++)
            {
                char rowChar = (char)('A' + r);
                bool isVip = room.IsVipSeat(rowChar.ToString());

                // Label tên hàng ở đầu mỗi hàng ghế
                var lblRow = new Label
                {
                    Text = rowChar.ToString(),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(70, 80, 95),
                    Size = new Size(24, buttonHeight),
                    Location = new Point(0, r * (buttonHeight + marginY) + 10),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panelSeatsContainer.Controls.Add(lblRow);

                for (int c = 1; c <= room.SeatsPerRow; c++)
                {
                    string seatCode = $"{rowChar}{c}";
                    bool isSold = soldSeats.Contains(seatCode);

                    var btnSeat = new Button
                    {
                        Text = seatCode,
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(30 + (c - 1) * (buttonWidth + marginX), r * (buttonHeight + marginY) + 5),
                        Tag = seatCode,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                        Cursor = isSold ? Cursors.No : Cursors.Hand
                    };

                    btnSeat.FlatAppearance.BorderSize = 1;

                    if (isSold)
                    {
                        btnSeat.BackColor = ColorSoldSeat;
                        btnSeat.ForeColor = Color.White;
                        btnSeat.FlatAppearance.BorderColor = Color.DarkRed;
                    }
                    else if (isVip)
                    {
                        btnSeat.BackColor = ColorVipSeat;
                        btnSeat.ForeColor = Color.Black;
                        btnSeat.FlatAppearance.BorderColor = Color.DarkOrange;
                    }
                    else
                    {
                        btnSeat.BackColor = ColorNormalSeat;
                        btnSeat.ForeColor = Color.Black;
                        btnSeat.FlatAppearance.BorderColor = Color.LightSteelBlue;
                    }

                    btnSeat.Click += BtnSeat_Click;
                    panelSeatsContainer.Controls.Add(btnSeat);
                }
            }

            panelSeatsContainer.ResumeLayout();
        }

        private void BtnSeat_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || _selectedShowtime == null) return;

            string seatCode = btn.Tag?.ToString() ?? "";
            var room = DataManager.GetRoomById(_selectedShowtime.RoomId);
            if (room == null) return;

            // Kiểm tra ghế đã bán chưa -> Không bán trùng ghế (Yêu cầu SV3)
            bool isSold = DataManager.Tickets.Any(t => t.ShowtimeId.Equals(_selectedShowtime.Id, StringComparison.OrdinalIgnoreCase) &&
                                                      t.SeatCode.Equals(seatCode, StringComparison.OrdinalIgnoreCase));
            if (isSold)
            {
                MessageBox.Show($"Ghế {seatCode} đã được bán cho khán giả khác! Vui lòng chọn ghế khác.",
                                "Ghế không khả dụng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isVip = room.IsVipSeat(seatCode);

            // Xử lý bật/tắt chọn ghế
            if (_selectedSeats.Contains(seatCode))
            {
                _selectedSeats.Remove(seatCode);
                btn.BackColor = isVip ? ColorVipSeat : ColorNormalSeat;
                btn.ForeColor = Color.Black;
            }
            else
            {
                _selectedSeats.Add(seatCode);
                btn.BackColor = ColorSelectedSeat;
                btn.ForeColor = Color.White;
            }

            UpdateSelectedSeatsList();
            CalculateTotal();
        }

        private void UpdateSelectedSeatsList()
        {
            lstSelectedSeats.Items.Clear();
            if (_selectedShowtime == null) return;

            var room = DataManager.GetRoomById(_selectedShowtime.RoomId);
            decimal basePrice = _selectedShowtime.BasePrice;
            decimal vipSurcharge = ConfigManager.VipSurcharge;

            foreach (var seat in _selectedSeats.OrderBy(s => s))
            {
                bool isVip = room?.IsVipSeat(seat) ?? false;
                decimal price = basePrice + (isVip ? vipSurcharge : 0);
                string vipText = isVip ? $" [VIP +{vipSurcharge:N0}đ]" : " [Thường]";
                lstSelectedSeats.Items.Add($"Ghế {seat}{vipText} - Đơn giá: {price:N0}đ");
            }
        }

        private void TicketType_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            if (_selectedShowtime == null || _selectedSeats.Count == 0)
            {
                lblTicketTotal.Text = "Tổng tiền vé (0 ghế): 0đ";
                lblDiscountTotal.Text = "Giảm giá đối tượng: 0đ";
                lblComboTotal.Text = "Tiền combo bắp nước: 0đ";
                lblGrandTotalValue.Text = "0 VNĐ";
                return;
            }

            var room = DataManager.GetRoomById(_selectedShowtime.RoomId);
            decimal basePrice = _selectedShowtime.BasePrice;
            decimal vipSurcharge = ConfigManager.VipSurcharge;

            decimal totalTicketRaw = 0;
            foreach (var seat in _selectedSeats)
            {
                bool isVip = room?.IsVipSeat(seat) ?? false;
                totalTicketRaw += basePrice + (isVip ? vipSurcharge : 0);
            }

            // Tính giảm giá theo loại vé (App.config)
            decimal discount = 0;
            if (rdoStudent.Checked)
            {
                int discountPercent = ConfigManager.StudentDiscountPercent;
                discount = totalTicketRaw * discountPercent / 100m;
            }

            // Tính tiền combo bắp nước
            decimal totalCombos = 0;
            foreach (var kvp in _comboCounters)
            {
                int qty = (int)kvp.Value.Value;
                if (qty > 0)
                {
                    var combo = DataManager.Combos.FirstOrDefault(c => c.Id == kvp.Key);
                    if (combo != null)
                    {
                        totalCombos += combo.Price * qty;
                    }
                }
            }

            decimal grandTotal = totalTicketRaw - discount + totalCombos;

            lblTicketTotal.Text = $"Tổng tiền vé ({_selectedSeats.Count} ghế): {totalTicketRaw:N0}đ";
            lblDiscountTotal.Text = rdoStudent.Checked ? $"Giảm giá HS-SV ({ConfigManager.StudentDiscountPercent}%): -{discount:N0}đ" : "Giảm giá: 0đ";
            lblComboTotal.Text = $"Tiền combo bắp nước: {totalCombos:N0}đ";
            lblGrandTotalValue.Text = $"{grandTotal:N0} VNĐ";
        }

        private void btnResetSeats_Click(object sender, EventArgs e)
        {
            _selectedSeats.Clear();
            lstSelectedSeats.Items.Clear();
            foreach (var nud in _comboCounters.Values)
            {
                nud.Value = 0;
            }
            GenerateSeatMap();
            CalculateTotal();
        }

        // Thanh toán & In vé ra TXT (Yêu cầu SV3)
        private void btnPrintAndPay_Click(object sender, EventArgs e)
        {
            if (_selectedShowtime == null)
            {
                MessageBox.Show("Vui lòng chọn suất chiếu trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng nhấp chọn ít nhất một ghế trên sơ đồ!", "Chưa chọn ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var movie = DataManager.GetMovieById(_selectedShowtime.MovieId);
            var room = DataManager.GetRoomById(_selectedShowtime.RoomId);
            string ticketType = rdoStudent.Checked ? "Học sinh - Sinh viên" : "Người lớn";

            // Chuẩn bị thông tin combo
            var selectedCombos = new List<string>();
            decimal totalCombos = 0;
            foreach (var kvp in _comboCounters)
            {
                int qty = (int)kvp.Value.Value;
                if (qty > 0)
                {
                    var combo = DataManager.Combos.FirstOrDefault(c => c.Id == kvp.Key);
                    if (combo != null)
                    {
                        selectedCombos.Add($"{combo.Name}: {qty}");
                        totalCombos += combo.Price * qty;
                    }
                }
            }
            string comboString = string.Join(", ", selectedCombos);

            // Hộp thoại chuẩn hỏi xác nhận khi thanh toán (Yêu cầu 6)
            var confirm = MessageBox.Show($"Xác nhận thanh toán cho {_selectedSeats.Count} vé ghế: {string.Join(", ", _selectedSeats)}?\n" +
                                          $"Phim: {movie?.Title}\n" +
                                          $"Loại vé: {ticketType}\n" +
                                          $"Tổng tiền: {lblGrandTotalValue.Text}",
                                          "Xác nhận thanh toán vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                decimal basePrice = _selectedShowtime.BasePrice;
                decimal vipSurcharge = ConfigManager.VipSurcharge;
                int discountPercent = rdoStudent.Checked ? ConfigManager.StudentDiscountPercent : 0;

                string invoiceId = $"HD{DateTime.Now:yyyyMMdd_HHmmss}";
                var newTickets = new List<Ticket>();

                foreach (var seat in _selectedSeats)
                {
                    bool isVip = room?.IsVipSeat(seat) ?? false;
                    decimal rawPrice = basePrice + (isVip ? vipSurcharge : 0);
                    decimal finalPrice = rawPrice - (rawPrice * discountPercent / 100m);

                    string ticketId = $"VE{DateTime.Now:yyyyMMddHHmmss}_{seat}";
                    var ticket = new Ticket(ticketId, _selectedShowtime.Id, seat, ticketType, finalPrice, DateTime.Now, comboString);
                    newTickets.Add(ticket);
                    DataManager.Tickets.Add(ticket);
                }

                // Ghi vào tập tin ve.txt bằng StreamWriter (Yêu cầu 2)
                DataManager.SaveTickets();

                // In vé / Hóa đơn ra tập tin TXT (Yêu cầu SV3)
                string receiptContent = BuildReceiptText(invoiceId, movie, room, _selectedShowtime, ticketType, newTickets, selectedCombos, totalCombos);
                string receiptDir = Path.Combine(DataManager.GetDataDirectory(), "Tickets");
                if (!Directory.Exists(receiptDir)) Directory.CreateDirectory(receiptDir);
                string receiptPath = Path.Combine(receiptDir, $"{invoiceId}.txt");

                File.WriteAllText(receiptPath, receiptContent, Encoding.UTF8);
                Logger.Log($"Thanh toán thành công hóa đơn {invoiceId} gồm {newTickets.Count} vé. Đã in vé ra: {receiptPath}");

                // Thông báo và mở xem vé TXT
                var viewConfirm = MessageBox.Show($"Thanh toán và in vé thành công!\nMã hóa đơn: {invoiceId}\nTập tin vé đã lưu tại: {receiptPath}\n\nBạn có muốn mở tập tin vé TXT để in ngay không?",
                                                  "In vé thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (viewConfirm == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo { FileName = receiptPath, UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Lỗi mở file vé: {ex.Message}", ex);
                    }
                }

                // Đặt lại trạng thái sau khi bán vé thành công
                btnResetSeats_Click(sender, e);
                cboShowtimes_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi trong quá trình thanh toán và in vé: {ex.Message}", ex);
                MessageBox.Show($"Lỗi trong quá trình thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildReceiptText(string invoiceId, Movie? movie, Room? room, Showtime showtime, string ticketType, List<Ticket> tickets, List<string> combos, decimal comboTotal)
        {
            var sb = new StringBuilder();
            sb.AppendLine("==========================================================================");
            sb.AppendLine($"               {ConfigManager.CinemaName.ToUpper()}");
            sb.AppendLine($"           {ConfigManager.CinemaAddress}");
            sb.AppendLine($"                    Hotline: {ConfigManager.CinemaHotline}");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine("                       HÓA ĐƠN & VÉ XEM PHIM ĐIỆN TỬ");
            sb.AppendLine($"  Mã hóa đơn : {invoiceId}");
            sb.AppendLine($"  Ngày in    : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"  Thu ngân   : {DataManager.CurrentUser?.FullName ?? "Quầy vé số 1"}");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine($"  Phim        : {movie?.Title.ToUpper() ?? "N/A"} ({movie?.AgeRating})");
            sb.AppendLine($"  Thời lượng  : {movie?.Duration} phút");
            sb.AppendLine($"  Phòng chiếu : {room?.Name ?? "N/A"}");
            sb.AppendLine($"  Suất chiếu  : {showtime.StartTime:dd/MM/yyyy  -  HH:mm}");
            sb.AppendLine($"  Đối tượng   : {ticketType}");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine("  CHI TIẾT VÉ GHẾ:");

            decimal ticketTotal = 0;
            foreach (var t in tickets)
            {
                bool isVip = room?.IsVipSeat(t.SeatCode) ?? false;
                string vipLabel = isVip ? " [VIP]" : " [Thường]";
                sb.AppendLine(string.Format("    • Mã: {0,-20} | Ghế: {1,-5}{2,-8} | Giá: {3,12:N0} VNĐ", t.Id, t.SeatCode, vipLabel, t.Price));
                ticketTotal += t.Price;
            }

            if (combos.Count > 0)
            {
                sb.AppendLine("--------------------------------------------------------------------------");
                sb.AppendLine("  COMBO BẮP NƯỚC KÈM THEO:");
                foreach (var c in combos)
                {
                    sb.AppendLine($"    • {c}");
                }
                sb.AppendLine($"  Tổng tiền bắp nước: {comboTotal:N0} VNĐ");
            }

            decimal grandTotal = ticketTotal + comboTotal;
            sb.AppendLine("==========================================================================");
            sb.AppendLine($"  TỔNG CỘNG THANH TOÁN: {grandTotal:N0} VNĐ");
            sb.AppendLine("==========================================================================");
            sb.AppendLine("  LƯU Ý DÀNH CHO KHÁN GIẢ:");
            sb.AppendLine("  1. Vé có giá trị trong ngày và suất chiếu in trên vé.");
            sb.AppendLine($"  2. Quý khách muốn trả vé vui lòng thực hiện trước giờ chiếu {ConfigManager.RefundTimeLimitMinutes} phút.");
            sb.AppendLine("  3. Vui lòng mang theo vé hoặc hình ảnh mã hóa đơn khi vào phòng chiếu.");
            sb.AppendLine();
            sb.AppendLine("                CHÚC QUÝ KHÁCH XEM PHIM VUI VẺ!");
            sb.AppendLine("==========================================================================");

            return sb.ToString();
        }
    }
}
