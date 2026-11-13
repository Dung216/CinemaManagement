using System.Globalization;

namespace CinemaManagement.Models
{
    public class SnackCombo
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;

        public SnackCombo() { }

        public SnackCombo(string id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} - {Price:N0}đ ({Description})";
        }

        public string ToDataLine()
        {
            return $"{Id};{Name};{Price};{Description}";
        }

        public static SnackCombo? FromDataLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split(';');
            if (parts.Length < 3) return null;

            string id = parts[0].Trim();
            string name = parts[1].Trim();
            if (!decimal.TryParse(parts[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                if (!decimal.TryParse(parts[2].Trim(), out price))
                    price = 0;
            }
            string description = parts.Length > 3 ? parts[3].Trim() : string.Empty;

            return new SnackCombo(id, name, price, description);
        }
    }
}
