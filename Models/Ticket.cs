using System.Globalization;

namespace CinemaManagement.Models
{
    public class Ticket
    {
        public string Id { get; set; } = string.Empty;
        public string ShowtimeId { get; set; } = string.Empty;
        public string SeatCode { get; set; } = string.Empty;
        public string TicketType { get; set; } = "Người lớn"; // "Người lớn" hoặc "Học sinh - Sinh viên"
        public decimal Price { get; set; } = 0;
        public DateTime SaleTime { get; set; } = DateTime.Now;
        public string ComboDetails { get; set; } = string.Empty;

        public Ticket() { }

        public Ticket(string id, string showtimeId, string seatCode, string ticketType, decimal price, DateTime saleTime, string comboDetails = "")
        {
            Id = id;
            ShowtimeId = showtimeId;
            SeatCode = seatCode;
            TicketType = ticketType;
            Price = price;
            SaleTime = saleTime;
            ComboDetails = comboDetails;
        }

        public override string ToString()
        {
            return $"[{Id}] Suất: {ShowtimeId} | Ghế: {SeatCode} | {TicketType} | {Price:N0}đ | {SaleTime:dd/MM/yyyy HH:mm}";
        }

        public string ToDataLine()
        {
            return $"{Id};{ShowtimeId};{SeatCode};{TicketType};{Price};{SaleTime:yyyy-MM-dd HH:mm};{ComboDetails}";
        }

        public static Ticket? FromDataLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split(';');
            if (parts.Length < 6) return null;

            string id = parts[0].Trim();
            string showtimeId = parts[1].Trim();
            string seatCode = parts[2].Trim();
            string ticketType = parts[3].Trim();

            if (!decimal.TryParse(parts[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                if (!decimal.TryParse(parts[4].Trim(), out price))
                    price = 0;
            }

            if (!DateTime.TryParseExact(parts[5].Trim(), new[] { "yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm:ss", "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime saleTime))
            {
                if (!DateTime.TryParse(parts[5].Trim(), out saleTime))
                    saleTime = DateTime.Now;
            }

            string comboDetails = parts.Length > 6 ? parts[6].Trim() : string.Empty;

            return new Ticket(id, showtimeId, seatCode, ticketType, price, saleTime, comboDetails);
        }
    }
}
