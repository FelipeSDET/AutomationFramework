using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class CheckBox : BaseWebElement
    {
        public CheckBox(string name, Locator locator, WebDriverFactory driverFactory)
    : base(name, locator, driverFactory) { }

        public void Check()
        {
            _driverFactory.WaitFluentlyForElementToBeClickable(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            if (!WebElement.Selected)
            {
                WebElement.Click();
            }
        }

        public void Uncheck()
        {
            _driverFactory.WaitFluentlyForElementToBeClickable(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            if (WebElement.Selected)
            {
                WebElement.Click();
            }
        }
    }
}
