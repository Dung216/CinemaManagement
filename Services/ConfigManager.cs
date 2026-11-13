using System.Configuration;

namespace CinemaManagement.Services
{
    public static class ConfigManager
    {
        public static string CinemaName => GetAppSetting("CinemaName", "TRUNG TÂM CHIẾU PHIM QUỐC GIA - GALAXY CINEMA");
        public static string CinemaAddress => GetAppSetting("CinemaAddress", "Số 87 Đường Láng Hạ, Đống Đa, Hà Nội");
        public static string CinemaHotline => GetAppSetting("CinemaHotline", "1900 6017");
        public static string DataDirectory => GetAppSetting("DataDirectory", "Data");

        public static int StudentDiscountPercent
        {
            get
            {
                string val = GetAppSetting("StudentDiscountPercent", "20");
                return int.TryParse(val, out int percent) ? percent : 20;
            }
        }

        public static int CleaningTimeMinutes
        {
            get
            {
                string val = GetAppSetting("CleaningTimeMinutes", "15");
                return int.TryParse(val, out int mins) ? mins : 15;
            }
        }

        public static int RefundTimeLimitMinutes
        {
            get
            {
                string val = GetAppSetting("RefundTimeLimitMinutes", "60");
                return int.TryParse(val, out int mins) ? mins : 60;
            }
        }

        public static decimal VipSurcharge
        {
            get
            {
                string val = GetAppSetting("VipSurcharge", "15000");
                return decimal.TryParse(val, out decimal surcharge) ? surcharge : 15000;
            }
        }

        private static string GetAppSetting(string key, string defaultValue)
        {
            try
            {
                string? val = ConfigurationManager.AppSettings[key];
                return !string.IsNullOrEmpty(val) ? val : defaultValue;
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc cấu hình App.config [{key}]: {ex.Message}", ex);
                return defaultValue;
            }
        }
    }
}
