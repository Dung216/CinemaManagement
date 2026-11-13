using Microsoft.Win32;

namespace CinemaManagement.Services
{
    public static class RegistryHelper
    {
        private const string SubKeyPath = @"Software\CinemaManagement";

        // Ghi nhớ đăng nhập
        public static bool RememberMe
        {
            get => GetDword("RememberMe", 0) == 1;
            set => SetDword("RememberMe", value ? 1 : 0);
        }

        public static string SavedUsername
        {
            get => GetString("SavedUsername", string.Empty);
            set => SetString("SavedUsername", value);
        }

        // Vị trí và kích thước form
        public static int WindowX
        {
            get => GetDword("WindowX", 100);
            set => SetDword("WindowX", value);
        }

        public static int WindowY
        {
            get => GetDword("WindowY", 100);
            set => SetDword("WindowY", value);
        }

        public static int WindowWidth
        {
            get => GetDword("WindowWidth", 1200);
            set => SetDword("WindowWidth", value);
        }

        public static int WindowHeight
        {
            get => GetDword("WindowHeight", 750);
            set => SetDword("WindowHeight", value);
        }

        public static int WindowState
        {
            get => GetDword("WindowState", 0); // 0: Normal, 2: Maximized
            set => SetDword("WindowState", value);
        }

        // Tùy chỉnh màu sắc & Font
        public static int ThemeColorArgb
        {
            get => GetDword("ThemeColorArgb", Color.FromArgb(33, 37, 41).ToArgb());
            set => SetDword("ThemeColorArgb", value);
        }

        public static string FontFamilyName
        {
            get => GetString("FontFamilyName", "Segoe UI");
            set => SetString("FontFamilyName", value);
        }

        public static float FontSize
        {
            get
            {
                string val = GetString("FontSize", "9");
                return float.TryParse(val, out float size) ? size : 9f;
            }
            set => SetString("FontSize", value.ToString());
        }

        private static string GetString(string keyName, string defaultValue)
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(SubKeyPath);
                if (key != null)
                {
                    object? val = key.GetValue(keyName);
                    if (val != null) return val.ToString() ?? defaultValue;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc Registry chuỗi [{keyName}]: {ex.Message}", ex);
            }
            return defaultValue;
        }

        private static void SetString(string keyName, string value)
        {
            try
            {
                using var key = Registry.CurrentUser.CreateSubKey(SubKeyPath);
                key?.SetValue(keyName, value ?? string.Empty);
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi Registry chuỗi [{keyName}]: {ex.Message}", ex);
            }
        }

        private static int GetDword(string keyName, int defaultValue)
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(SubKeyPath);
                if (key != null)
                {
                    object? val = key.GetValue(keyName);
                    if (val is int intVal) return intVal;
                    if (val != null && int.TryParse(val.ToString(), out int parsed)) return parsed;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi đọc Registry số [{keyName}]: {ex.Message}", ex);
            }
            return defaultValue;
        }

        private static void SetDword(string keyName, int value)
        {
            try
            {
                using var key = Registry.CurrentUser.CreateSubKey(SubKeyPath);
                key?.SetValue(keyName, value, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi ghi Registry số [{keyName}]: {ex.Message}", ex);
            }
        }
    }
}
