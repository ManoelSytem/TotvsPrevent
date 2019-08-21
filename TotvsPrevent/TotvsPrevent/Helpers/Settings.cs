
namespace TotvsPrevent.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string accesstoken = "AccessToken";
        private const string accesstokenTemp = "AccesstokenTemp";
        private const string produto = "Produto";
        private const string isRemembered = "IsRemembered";
        private const string username = "Username";
        private const string password = "Password";
        private static readonly string SettingsDefault = string.Empty;

        #endregion
        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault(username, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(username, value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(password, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(password, value);
            }
        }
        public static string IsRemembered
        {
            get
            {
                return AppSettings.GetValueOrDefault(isRemembered, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(isRemembered, value);
            }
        }
   
        public static string AccesstokenTemp
        {
            get
            {
                return AppSettings.GetValueOrDefault(accesstokenTemp, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(accesstokenTemp, value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(accesstoken, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(accesstoken, value);
            }
        }

        public static string Produto
        {
            get
            {
                return AppSettings.GetValueOrDefault(produto, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(produto, value);
            }
        }

    }
}
