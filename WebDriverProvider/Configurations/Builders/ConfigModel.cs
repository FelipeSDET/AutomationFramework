using WebDriverProvider.Classes;
using WebDriverProvider.Enums;
using WebDriverProvider.Interfaces;

namespace WebDriverProvider.Configurations
{
    public class ConfigModel
    {
        public static readonly string API_TODO_LY_URL = ConfigBuilder.Instance.GetString("API", "ApiHostUrl");
        public static readonly TimeSpan API_PageLoad = ConfigBuilder.Instance.GetTimeSpan("API", "PageLoad");
        public static readonly TimeSpan API_ImplicitWait = ConfigBuilder.Instance.GetTimeSpan("API", "ImplicitWait");
        public static readonly TimeSpan API_ShortWait = ConfigBuilder.Instance.GetTimeSpan("API", "ShortWait");
        public static readonly TimeSpan API_MediumWait = ConfigBuilder.Instance.GetTimeSpan("API", "MediumWait");
        public static readonly TimeSpan API_LongWait = ConfigBuilder.Instance.GetTimeSpan("API", "LongWait");
        public static readonly TimeSpan API_SleepInterval = ConfigBuilder.Instance.GetTimeSpan("API", "SleepInterval");

        public static readonly string UI_HOST_URL = ConfigBuilder.Instance.GetString("UI", "UiHostUrl");
        public static readonly string SELENIUMGRIDURL = ConfigBuilder.Instance.GetString("UI", "SeleniumGridUrl");
        public static readonly Browser BROWSER = (Browser)Enum.Parse(typeof(Browser), ConfigBuilder.Instance.GetString("UI", "Browser"), true);
        public static readonly bool ISHEADLESS = ConfigBuilder.Instance.GetBool("UI", "Isheadless");
        public static readonly bool ISREMOTE = ConfigBuilder.Instance.GetBool("UI", "IsRemote");
        public static readonly TimeSpan UI_ImplicitWait = ConfigBuilder.Instance.GetTimeSpan("UI", "ImplicitWait");
        public static readonly TimeSpan UI_LongWait = ConfigBuilder.Instance.GetTimeSpan("UI", "LongWait");
        public static readonly TimeSpan UI_MediumWait = ConfigBuilder.Instance.GetTimeSpan("UI", "MediumWait");
        public static readonly TimeSpan UI_PageLoad = ConfigBuilder.Instance.GetTimeSpan("UI", "PageLoad");
        public static readonly TimeSpan UI_ShortWait = ConfigBuilder.Instance.GetTimeSpan("UI", "ShortWait");
        public static readonly TimeSpan UI_SleepInterval = ConfigBuilder.Instance.GetTimeSpan("UI", "SleepInterval");

        public static readonly string TESTUSER_EMAIL = ConfigBuilder.Instance.GetString("TESTUSER_EMAIL");
        public static readonly string TESTUSER_PASSWORD = ConfigBuilder.Instance.GetString("TESTUSER_PASSWORD");
    }
}
