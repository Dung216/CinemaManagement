namespace CinemaManagement.Models
{
    public class Movie
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Duration { get; set; } = 90; // Thời lượng tính bằng phút
        public string AgeRating { get; set; } = "P"; // P: Phổ biến, K: Dưới 13 tuổi có kèm, T13: 13+, T16: 16+, T18: 18+
        public string Poster { get; set; } = string.Empty;

        public Movie() { }

        public Movie(string id, string title, string genre, int duration, string ageRating, string poster)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Duration = duration;
            AgeRating = ageRating;
            Poster = poster;
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} - {Genre} ({Duration} phút, {AgeRating})";
        }

        public string ToDataLine()
        {
            return $"{Id};{Title};{Genre};{Duration};{AgeRating};{Poster}";
        }

        public static Movie? FromDataLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split(';');
            if (parts.Length < 6) return null;

            string id = parts[0].Trim();
            string title = parts[1].Trim();
            string genre = parts[2].Trim();
            if (!int.TryParse(parts[3].Trim(), out int duration)) duration = 90;
            string ageRating = parts[4].Trim();
            string poster = parts[5].Trim();

            return new Movie(id, title, genre, duration, ageRating, poster);
        }
    }
}
