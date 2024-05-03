using OpenQA.Selenium;
using WebDriverProvider.Interfaces;
using OpenQA.Selenium.Firefox;

namespace WebDriverProvider.Configurations
{
    public class FirefoxOptionsConfigurator : IBrowserOptionsConfigurator
    {
        public DriverOptions ConfigureOptions(bool isHeadless)
        {
            var options = new FirefoxOptions();
            options.AddArgument("--incognito");
            if (isHeadless)
            {
                options.AddArgument("--headless");
            }
            return options;
        }
    }
}