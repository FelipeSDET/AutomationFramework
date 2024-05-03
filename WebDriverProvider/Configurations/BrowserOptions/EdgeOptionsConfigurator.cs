using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverProvider.Interfaces;
using OpenQA.Selenium.Edge;

namespace WebDriverProvider.Configurations
{
    public class EdgeOptionsConfigurator : IBrowserOptionsConfigurator
    {
        public DriverOptions ConfigureOptions(bool isHeadless)
        {
            var options = new EdgeOptions();
            options.AddArgument("--incognito");
            if (isHeadless)
            {
                options.AddArgument("--headless");
            }
            return options;
        }
    }
}