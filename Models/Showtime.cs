using System.Globalization;

namespace CinemaManagement.Models
{
    public class Showtime
    {
        public string Id { get; set; } = string.Empty;
        public string MovieId { get; set; } = string.Empty;
        public string RoomId { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public decimal BasePrice { get; set; } = 80000;

        public Showtime() { }

        public Showtime(string id, string movieId, string roomId, DateTime startTime, decimal basePrice)
        {
            Id = id;
            MovieId = movieId;
            RoomId = roomId;
            StartTime = startTime;
            BasePrice = basePrice;
        }

        public override string ToString()
        {
            return $"[{Id}] {StartTime:dd/MM/yyyy HH:mm} - Phim: {MovieId} - Phòng: {RoomId} - Giá: {BasePrice:N0}đ";
        }

        public string ToDataLine()
        {
            return $"{Id};{MovieId};{RoomId};{StartTime:yyyy-MM-dd HH:mm};{BasePrice}";
        }

        public static Showtime? FromDataLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split(';');
            if (parts.Length < 5) return null;

            string id = parts[0].Trim();
            string movieId = parts[1].Trim();
            string roomId = parts[2].Trim();

            if (!DateTime.TryParseExact(parts[3].Trim(), new[] { "yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm:ss", "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime))
            {
                if (!DateTime.TryParse(parts[3].Trim(), out startTime))
                    return null;
            }

            if (!decimal.TryParse(parts[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal basePrice))
            {
                if (!decimal.TryParse(parts[4].Trim(), out basePrice))
                    basePrice = 80000;
            }

            return new Showtime(id, movieId, roomId, startTime, basePrice);
        }
    }
}
