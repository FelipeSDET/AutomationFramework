using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class Button : BaseWebElement
    {
        public Button(string name, Locator locator, WebDriverFactory driverFactory)
    : base(name, locator, driverFactory) { }

        public void Click()
        {
            _driverFactory.WaitFluentlyForElementToBeClickable(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            WebElement.Click();
        }
        public void DoubleClick()
        {
            _driverFactory.WaitFluentlyForElementToBeClickable(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            Actions actions = new Actions(_driverFactory.GetInstanceOf());
            actions.DoubleClick(WebElement).Perform();
        }
        public void RightClick()
        {
            _driverFactory.WaitFluentlyForElementToBeClickable(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            Actions actions = new Actions(_driverFactory.GetInstanceOf());
            actions.ContextClick(WebElement).Perform();
        }
    }
}
