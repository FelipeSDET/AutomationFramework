using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverProvider.Configurations;

namespace WebDriverProvider.Classes;
public partial class WebDriverFactory
{
    private void SetupTimeouts()
    {
        _webDriver.Manage().Timeouts().PageLoad = ConfigModel.UI_PageLoad;
        _webDriver.Manage().Timeouts().ImplicitWait = ConfigModel.UI_ImplicitWait;
    }

    public IWebDriver GetInstanceOf()
    {
        return _webDriver;
    }
    public void NavigateToBaseUrl()
    {
        _webDriver.Navigate().GoToUrl(ConfigModel.UI_HOST_URL);
    }

    public void NavigateToUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException($"'{nameof(url)}' cannot be null or whitespace.", nameof(url));

        _webDriver.Navigate().GoToUrl(url);
    }

    public string GetCurrentUrl()
    {
        var url = _webDriver.Url;

        return url;
    }

    public string GetCurrentTitle()
    {
        var title = _webDriver.Title;

        return title;
    }

    public void SwitchToFirstTab()
    {
        var firstTab = _webDriver.WindowHandles.First();

        _webDriver.SwitchTo().Window(firstTab);
    }

    public void SwitchToLastTab()
    {
        var lastTab = _webDriver.WindowHandles.Last();

        _webDriver.SwitchTo().Window(lastTab);
    }

    public void CloseTab()
    {
        _webDriver.Close();
    }

    public void TerminateWebDriver()
    {
        _webDriver.Close();
        _webDriver.Quit();
        _webDriver.Dispose();
    }
}
