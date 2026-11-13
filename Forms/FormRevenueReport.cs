using System.Diagnostics;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormRevenueReport : Form
    {
        public FormRevenueReport()
        {
            InitializeComponent();
        }

        private void FormRevenueReport_Load(object sender, EventArgs e)
        {
            // Mặc định từ đầu tháng tới hôm nay
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpToDate.Value = DateTime.Today;

            LoadReportData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                MessageBox.Show("'Từ ngày' không thể lớn hơn 'Đến ngày'!", "Lỗi khoảng ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFromDate.Focus();
                return;
            }

            LoadReportData();
        }

        public void LoadReportData()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            var tickets = DataManager.Tickets
                .Where(t => t.SaleTime.Date >= fromDate && t.SaleTime.Date <= toDate)
                .ToList();

            decimal grandTotal = tickets.Sum(t => t.Price);
            int totalTickets = tickets.Count;

            lblSummaryTotalTickets.Text = $"🎟️ TỔNG SỐ VÉ ĐÃ BÁN: {totalTickets:N0} VÉ";
            lblSummaryTotalRevenue.Text = $"💰 TỔNG DOANH THU: {grandTotal:N0} VNĐ";

            // 1. Thống kê theo phim
            lvByMovie.Items.Clear();
            var movieGroups = tickets
                .GroupBy(t =>
                {
                    var showtime = DataManager.GetShowtimeById(t.ShowtimeId);
                    return showtime?.MovieId ?? "Khác";
                })
                .Select(g =>
                {
                    var movie = DataManager.GetMovieById(g.Key);
                    decimal rev = g.Sum(x => x.Price);
                    double pct = grandTotal > 0 ? (double)(rev / grandTotal * 100) : 0;
                    return new
                    {
                        MovieId = g.Key,
                        Title = movie?.Title ?? "Không xác định",
                        Genre = movie?.Genre ?? "N/A",
                        Count = g.Count(),
                        Revenue = rev,
                        Percentage = pct
                    };
                })
                .OrderByDescending(x => x.Revenue)
                .ToList();

            foreach (var mg in movieGroups)
            {
                var lvi = new ListViewItem(mg.MovieId);
                lvi.SubItems.Add(mg.Title);
                lvi.SubItems.Add(mg.Genre);
                lvi.SubItems.Add($"{mg.Count:N0}");
                lvi.SubItems.Add($"{mg.Revenue:N0}đ");
                lvi.SubItems.Add($"{mg.Percentage:F1}%");

                lvByMovie.Items.Add(lvi);
            }

            // 2. Thống kê theo ngày
            lvByDate.Items.Clear();
            var dateGroups = tickets
                .GroupBy(t => t.SaleTime.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Count = g.Count(),
                    Revenue = g.Sum(x => x.Price)
                })
                .OrderBy(x => x.Date)
                .ToList();

            foreach (var dg in dateGroups)
            {
                var lvi = new ListViewItem(dg.Date.ToString("dd/MM/yyyy (dddd)"));
                lvi.SubItems.Add($"{dg.Count:N0}");
                lvi.SubItems.Add($"{dg.Revenue:N0}đ");

                lvByDate.Items.Add(lvi);
            }
        }

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Lưu báo cáo thống kê doanh thu ra tập tin TXT",
                Filter = "Tập tin văn bản (*.txt)|*.txt|Tất cả tập tin (*.*)|*.*",
                FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BackupRestoreService.ExportRevenueToTxt(sfd.FileName, dtpFromDate.Value, dtpToDate.Value);
                    var openConfirm = MessageBox.Show("Xuất báo cáo TXT thành công!\nBạn có muốn mở tập tin vừa xuất không?",
                                                      "Hoàn tất xuất báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (openConfirm == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Lỗi xuất TXT: {ex.Message}", ex);
                    MessageBox.Show($"Lỗi khi xuất file TXT: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Lưu dữ liệu bán vé chi tiết ra tập tin CSV",
                Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*",
                FileName = $"DuLieuBanVe_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BackupRestoreService.ExportRevenueToCsv(sfd.FileName, dtpFromDate.Value, dtpToDate.Value);
                    var openConfirm = MessageBox.Show("Xuất dữ liệu CSV thành công!\nBạn có muốn mở tập tin vừa xuất không?",
                                                      "Hoàn tất xuất báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (openConfirm == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Lỗi xuất CSV: {ex.Message}", ex);
                    MessageBox.Show($"Lỗi khi xuất file CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
