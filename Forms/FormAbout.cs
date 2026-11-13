using System.Text;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DỰ ÁN CUỐI KỲ: LẬP TRÌNH TRÊN MÔI TRƯỜNG WINDOWS");
            sb.AppendLine("Đề tài 10: Quản lý rạp chiếu phim (3–5 phòng chiếu)");
            sb.AppendLine("----------------------------------------------------------------------------------");
            sb.AppendLine("PHÂN HỆ BẮT BUỘC & PHÂN CÔNG THỰC HIỆN:");
            sb.AppendLine("1. SV1 – Phim & Phòng chiếu:");
            sb.AppendLine("   • Quản lý phim (poster bằng PictureBox, ListView kiểu LargeIcon & Details)");
            sb.AppendLine("   • Phòng chiếu (số hàng, số ghế, hàng VIP)");
            sb.AppendLine("   • Lọc phim theo thể loại (ComboBox)");
            sb.AppendLine("   • Nhập danh sách phim từ tập tin CSV (OpenFileDialog)");
            sb.AppendLine();
            sb.AppendLine("2. SV2 – Suất chiếu & Cây lịch chiếu:");
            sb.AppendLine("   • Lên lịch suất chiếu; thuật toán chống hai suất chồng giờ trong cùng phòng");
            sb.AppendLine("     (tính theo thời lượng phim + 15 phút dọn phòng cấu hình trong App.config)");
            sb.AppendLine("   • Cây Ngày -> Phim -> Suất (TreeView)");
            sb.AppendLine("   • Hủy suất chưa bán vé");
            sb.AppendLine();
            sb.AppendLine("3. SV3 – Bán vé & Doanh thu:");
            sb.AppendLine("   • Chọn suất -> sơ đồ ghế bằng Button tạo bằng code (Trống/Đã bán/Đang chọn/VIP)");
            sb.AppendLine("   • Loại vé người lớn / học sinh – sinh viên (RadioButton, giảm giá trong App.config)");
            sb.AppendLine("   • In vé / Hóa đơn ra tập tin TXT");
            sb.AppendLine("   • Thống kê doanh thu theo phim và theo ngày, xuất file TXT/CSV");
            sb.AppendLine();
            sb.AppendLine("4. NÂNG CAO (ĐIỂM CỘNG):");
            sb.AppendLine("   • Combo bắp nước khi đặt vé");
            sb.AppendLine("   • Trả vé trước giờ chiếu ít nhất 1 tiếng (60 phút)");
            sb.AppendLine("   • Timer tự động ẩn suất đã bắt đầu chiếu khỏi màn hình bán vé");
            sb.AppendLine("----------------------------------------------------------------------------------");
            sb.AppendLine($"Đơn vị rạp: {ConfigManager.CinemaName}");
            sb.AppendLine($"Địa chỉ: {ConfigManager.CinemaAddress} - Hotline: {ConfigManager.CinemaHotline}");

            rtbContent.Text = sb.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
