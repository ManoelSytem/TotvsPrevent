
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
        private const string produto = "Produto";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


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
