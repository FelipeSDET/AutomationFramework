using WebDriverProvider.Enums;

namespace WebDriverProvider.Interfaces;
public interface IWebDriverConfiguration
{
    string BaseUrl { get; set; }
    string SeleniumGridUrl { get; set; }
    Browser Browser { get; set; }
    bool IsHeadless { get; set; }
    bool IsRemote { get; set; }
    TimeSpan ImplicitWait { get; set; }
    TimeSpan LongWait { get; set; }
    TimeSpan MediumWait { get; set; }
    TimeSpan PageLoad { get; set; }
    TimeSpan ShortWait { get; set; }
    TimeSpan SleepInterval { get; set; }
}