namespace CinemaManagement.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Staff"; // "Admin" or "Staff"
        public bool IsLocked { get; set; } = false;
        public int FailedAttempts { get; set; } = 0;

        public User() { }

        public User(string username, string password, string fullName, string role, bool isLocked = false, int failedAttempts = 0)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Role = role;
            IsLocked = isLocked;
            FailedAttempts = failedAttempts;
        }

        public override string ToString()
        {
            return $"{Username} - {FullName} ({Role}) {(IsLocked ? "[BỊ KHÓA]" : "")}";
        }

        public string ToDataLine()
        {
            return $"{Username};{Password};{FullName};{Role};{IsLocked};{FailedAttempts}";
        }

        public static User? FromDataLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split(';');
            if (parts.Length < 4) return null;

            string username = parts[0].Trim();
            string password = parts[1].Trim();
            string fullName = parts[2].Trim();
            string role = parts[3].Trim();
            bool isLocked = parts.Length > 4 && bool.TryParse(parts[4].Trim(), out bool locked) && locked;
            int failedAttempts = parts.Length > 5 && int.TryParse(parts[5].Trim(), out int attempts) ? attempts : 0;

            return new User(username, password, fullName, role, isLocked, failedAttempts);
        }
    }
}
