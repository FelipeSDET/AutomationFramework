using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverProvider.Interfaces;
using OpenQA.Selenium.Remote;

namespace WebDriverProvider.Configurations
{
    public class ChromeOptionsConfigurator : IBrowserOptionsConfigurator
    {
        public DriverOptions ConfigureOptions(bool isHeadless)
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            if (isHeadless)
            {
                options.AddArgument("--headless");
            }
            return options;
        }
    }
}