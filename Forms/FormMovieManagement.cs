using System.Text;
using CinemaManagement.Models;
using CinemaManagement.Services;

namespace CinemaManagement.Forms
{
    public partial class FormMovieManagement : Form
    {
        private List<Movie> _currentDisplayedMovies = new List<Movie>();

        public FormMovieManagement()
        {
            InitializeComponent();
        }

        private void FormMovieManagement_Load(object sender, EventArgs e)
        {
            try
            {
                cboAgeRating.SelectedIndex = 0;
                LoadGenreFilter();
                RefreshMovieList();
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi nạp danh sách phim: {ex.Message}", ex);
                MessageBox.Show($"Lỗi nạp danh sách phim: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGenreFilter()
        {
            cboFilterGenre.Items.Clear();
            cboFilterGenre.Items.Add("-- Tất cả thể loại --");

            var genres = DataManager.Movies
                .SelectMany(m => m.Genre.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(g => g.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(g => g)
                .ToList();

            foreach (var g in genres)
            {
                cboFilterGenre.Items.Add(g);
            }
            cboFilterGenre.SelectedIndex = 0;
        }

        private void RefreshMovieList()
        {
            string selectedGenre = cboFilterGenre.SelectedIndex > 0 ? cboFilterGenre.SelectedItem?.ToString() ?? "" : "";

            if (string.IsNullOrEmpty(selectedGenre))
            {
                _currentDisplayedMovies = DataManager.Movies.ToList();
            }
            else
            {
                _currentDisplayedMovies = DataManager.Movies
                    .Where(m => m.Genre.Contains(selectedGenre, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            lvMovies.BeginUpdate();
            lvMovies.Items.Clear();
            imageListLarge.Images.Clear();

            int imgIndex = 0;
            foreach (var movie in _currentDisplayedMovies)
            {
                // Nạp poster đồ họa vào ImageList cho chế độ LargeIcon
                Image posterImg = PosterHelper.GetPoster(movie, 110, 150);
                imageListLarge.Images.Add(movie.Id, posterImg);

                var lvi = new ListViewItem(movie.Id, imgIndex++)
                {
                    Text = lvMovies.View == View.LargeIcon ? $"{movie.Title}\n({movie.Duration}p - {movie.AgeRating})" : movie.Id,
                    Tag = movie
                };

                // Các cột cho chế độ Details
                lvi.SubItems.Add(movie.Title);
                lvi.SubItems.Add(movie.Genre);
                lvi.SubItems.Add($"{movie.Duration} phút");
                lvi.SubItems.Add(movie.AgeRating);
                lvi.SubItems.Add(movie.Poster);

                lvMovies.Items.Add(lvi);
            }
            lvMovies.EndUpdate();
        }

        private void cboFilterGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMovieList();
        }

        private void btnViewMode_Click(object sender, EventArgs e)
        {
            if (lvMovies.View == View.LargeIcon)
            {
                lvMovies.View = View.Details;
                btnViewMode.Text = "🖼️ Chế độ xem: Bảng (Click đổi Poster)";
            }
            else
            {
                lvMovies.View = View.LargeIcon;
                btnViewMode.Text = "📋 Chế độ xem: Poster (Click đổi Bảng)";
            }
            RefreshMovieList();
        }

        private void lvMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count > 0)
            {
                var movie = lvMovies.SelectedItems[0].Tag as Movie;
                if (movie != null)
                {
                    DisplayMovieDetails(movie);
                }
            }
        }

        private void DisplayMovieDetails(Movie movie)
        {
            txtId.Text = movie.Id;
            txtTitle.Text = movie.Title;
            txtGenre.Text = movie.Genre;
            txtDuration.Text = movie.Duration.ToString();
            txtPoster.Text = movie.Poster;

            for (int i = 0; i < cboAgeRating.Items.Count; i++)
            {
                string itemStr = cboAgeRating.Items[i]?.ToString() ?? "";
                if (itemStr.StartsWith(movie.AgeRating, StringComparison.OrdinalIgnoreCase))
                {
                    cboAgeRating.SelectedIndex = i;
                    break;
                }
            }

            // Hiển thị poster bằng PictureBox (Yêu cầu SV1)
            picPoster.Image = PosterHelper.GetPoster(movie, picPoster.Width, picPoster.Height);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtTitle.Clear();
            txtGenre.Clear();
            txtDuration.Clear();
            txtPoster.Clear();
            cboAgeRating.SelectedIndex = 0;
            picPoster.Image = null;
            txtId.Focus();
        }

        private void btnBrowsePoster_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn hình ảnh Poster cho phim",
                Filter = "Tập tin hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Tất cả tập tin (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPoster.Text = Path.GetFileName(ofd.FileName);
                try
                {
                    picPoster.Image = Image.FromFile(ofd.FileName);
                }
                catch (Exception ex)
                {
                    Logger.Log($"Lỗi mở ảnh poster: {ex.Message}", ex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: true)) return;

            string id = txtId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string genre = txtGenre.Text.Trim();
            int duration = int.Parse(txtDuration.Text.Trim());
            string ageRating = cboAgeRating.SelectedItem!.ToString()!.Split('-')[0].Trim();
            string poster = string.IsNullOrWhiteSpace(txtPoster.Text) ? $"{id.ToLower()}.jpg" : txtPoster.Text.Trim();

            var newMovie = new Movie(id, title, genre, duration, ageRating, poster);
            DataManager.Movies.Add(newMovie);
            DataManager.SaveMovies();

            Logger.Log($"Thêm phim mới: {newMovie}");
            MessageBox.Show($"Thêm phim '{title}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadGenreFilter();
            RefreshMovieList();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: false)) return;

            string id = txtId.Text.Trim();
            var movie = DataManager.GetMovieById(id);
            if (movie == null)
            {
                MessageBox.Show($"Không tìm thấy phim có mã '{id}' để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            movie.Title = txtTitle.Text.Trim();
            movie.Genre = txtGenre.Text.Trim();
            movie.Duration = int.Parse(txtDuration.Text.Trim());
            movie.AgeRating = cboAgeRating.SelectedItem!.ToString()!.Split('-')[0].Trim();
            movie.Poster = string.IsNullOrWhiteSpace(txtPoster.Text) ? $"{id.ToLower()}.jpg" : txtPoster.Text.Trim();

            DataManager.SaveMovies();
            Logger.Log($"Cập nhật phim: {movie}");
            MessageBox.Show($"Cập nhật thông tin phim '{movie.Title}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadGenreFilter();
            RefreshMovieList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã phim cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            var movie = DataManager.GetMovieById(id);
            if (movie == null)
            {
                MessageBox.Show($"Không tìm thấy phim có mã '{id}'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra ràng buộc suất chiếu
            bool hasShowtime = DataManager.Showtimes.Any(s => s.MovieId.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (hasShowtime)
            {
                MessageBox.Show($"Không thể xóa phim '{movie.Title}' vì phim đang có suất chiếu trong hệ thống!\n" +
                                "Vui lòng xóa các suất chiếu liên quan trước.",
                                "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Hộp thoại chuẩn hỏi xác nhận khi xóa (Yêu cầu 6)
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa phim '{movie.Title}' (Mã: {movie.Id}) không?",
                                          "Xác nhận xóa phim", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                DataManager.Movies.Remove(movie);
                DataManager.SaveMovies();
                Logger.Log($"Đã xóa phim: {movie}");
                MessageBox.Show("Xóa phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGenreFilter();
                RefreshMovieList();
                ClearInputs();
            }
        }

        private bool ValidateInputs(bool isNew)
        {
            string id = txtId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string genre = txtGenre.Text.Trim();
            string durationStr = txtDuration.Text.Trim();

            // Kiểm tra không rỗng và đưa con trỏ về ô sai (Yêu cầu 3)
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Mã phim không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return false;
            }

            if (isNew && DataManager.Movies.Any(m => m.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Mã phim '{id}' đã tồn tại! Vui lòng nhập mã khác không trùng.", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                txtId.SelectAll();
                return false;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Tên phim không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Thể loại phim không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGenre.Focus();
                return false;
            }

            // Kiểm tra đúng kiểu bằng TryParse (Yêu cầu 3)
            if (!int.TryParse(durationStr, out int duration) || duration <= 0)
            {
                MessageBox.Show("Thời lượng phim phải là số nguyên dương hợp lệ (phút)!", "Lỗi kiểu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuration.Focus();
                txtDuration.SelectAll();
                return false;
            }

            if (cboAgeRating.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giới hạn độ tuổi xem phim!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAgeRating.Focus();
                return false;
            }

            return true;
        }

        // Nhập danh sách phim từ tập tin CSV (Yêu cầu SV1)
        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn tập tin CSV danh sách phim cần nhập",
                Filter = "Tập tin CSV (*.csv)|*.csv|Tập tin văn bản (*.txt)|*.txt|Tất cả tập tin (*.*)|*.*",
                InitialDirectory = Path.Combine(DataManager.GetDataDirectory(), "SampleData")
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int importedCount = 0;
                    int skippedCount = 0;

                    using var reader = new StreamReader(ofd.FileName, Encoding.UTF8);
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#") || line.StartsWith("Ma;"))
                            continue;

                        var movie = Movie.FromDataLine(line);
                        if (movie != null)
                        {
                            // Kiểm tra không trùng mã
                            if (!DataManager.Movies.Any(m => m.Id.Equals(movie.Id, StringComparison.OrdinalIgnoreCase)))
                            {
                                DataManager.Movies.Add(movie);
                                importedCount++;
                            }
                            else
                            {
                                skippedCount++;
                            }
                        }
                    }

                    DataManager.SaveMovies();
                    LoadGenreFilter();
                    RefreshMovieList();

                    Logger.Log($"Nhập CSV thành công từ {ofd.FileName}: Thêm {importedCount} phim, Bỏ qua {skippedCount} phim trùng mã.");
                    MessageBox.Show($"Nhập thành công {importedCount} phim mới!\n(Bỏ qua {skippedCount} phim do trùng mã hoặc sai định dạng).",
                                    "Kết quả nhập dữ liệu CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Logger.Log($"Lỗi nhập CSV: {ex.Message}", ex);
                    MessageBox.Show($"Lỗi khi đọc file CSV: {ex.Message}", "Lỗi nhập file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuSelect_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count > 0 && lvMovies.SelectedItems[0].Tag is Movie movie)
            {
                DisplayMovieDetails(movie);
            }
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            menuSelect_Click(sender, e);
            txtTitle.Focus();
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            menuSelect_Click(sender, e);
            btnDelete_Click(sender, e);
        }

        private void menuSchedule_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count > 0 && lvMovies.SelectedItems[0].Tag is Movie movie)
            {
                if (MdiParent is FormMain main)
                {
                    main.OpenShowtimeWithMovie(movie.Id);
                }
            }
        }
    }
}
