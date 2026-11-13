namespace CinemaManagement.Models
{
    public class Room
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int TotalRows { get; set; } = 6;
        public int SeatsPerRow { get; set; } = 8;
        public string VipRows { get; set; } = "C,D"; // Danh sách hàng VIP cách nhau bằng dấu phẩy

        public int TotalSeats => TotalRows * SeatsPerRow;

        public Room() { }

        public Room(string id, string name, int totalRows, int seatsPerRow, string vipRows)
        {
            Id = id;
            Name = name;
            TotalRows = totalRows;
            SeatsPerRow = seatsPerRow;
            VipRows = vipRows;
        }

        public bool IsVipSeat(string seatCode)
        {
            if (string.IsNullOrWhiteSpace(seatCode) || string.IsNullOrWhiteSpace(VipRows))
                return false;

            char rowChar = seatCode.Trim().ToUpper()[0];
            string[] vipList = VipRows.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var vip in vipList)
            {
                if (vip.Trim().Equals(rowChar.ToString(), StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} ({TotalRows} hàng x {SeatsPerRow} ghế = {TotalSeats} chỗ, Hàng VIP: {VipRows})";
        }

        public string ToDataLine()
        {
            return $"{Id};{Name};{TotalRows};{SeatsPerRow};{VipRows}";
        }

        public static Room? FromDataLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split(';');
            if (parts.Length < 5) return null;

            string id = parts[0].Trim();
            string name = parts[1].Trim();
            if (!int.TryParse(parts[2].Trim(), out int totalRows)) totalRows = 6;
            if (!int.TryParse(parts[3].Trim(), out int seatsPerRow)) seatsPerRow = 8;
            string vipRows = parts[4].Trim();

            return new Room(id, name, totalRows, seatsPerRow, vipRows);
        }
    }
}
