using WebDriverProvider.Enums;
using Microsoft.Extensions.Configuration;
using WebDriverProvider.Interfaces;

namespace WebDriverProvider.Configurations
{
    public class WebDriverConfiguration : IWebDriverConfiguration
    {
        [ConfigurationKeyName("BaseUrl")]
        public string BaseUrl { get; set; }
        [ConfigurationKeyName("BrowserStackUrl")]
        public string BrowserStackUrl { get; set; }
        [ConfigurationKeyName("SeleniumGridUrl")]
        public string SeleniumGridUrl { get; set; }
        [ConfigurationKeyName("Browser")]
        public Browser Browser { get; set; }
        [ConfigurationKeyName("IsHeadless")]
        public bool IsHeadless { get; set; }
        [ConfigurationKeyName("IsRemote")]
        public bool IsRemote { get; set; }
        [ConfigurationKeyName("PageLoad")]
        public TimeSpan PageLoad { get; set; }
        [ConfigurationKeyName("ImplicitWait")]
        public TimeSpan ImplicitWait { get; set; }
        [ConfigurationKeyName("ShortWait")]
        public TimeSpan ShortWait { get; set; }
        [ConfigurationKeyName("MediumWait")]
        public TimeSpan MediumWait { get; set; }
        [ConfigurationKeyName("LongWait")]
        public TimeSpan LongWait { get; set; }
        [ConfigurationKeyName("SleepInterval")]
        public TimeSpan SleepInterval { get; set; }

        public WebDriverConfiguration()
        {
            BaseUrl = string.Empty;
            BrowserStackUrl = string.Empty;
            SeleniumGridUrl = string.Empty;
        }
    }
}