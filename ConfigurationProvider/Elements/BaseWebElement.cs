using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class BaseWebElement
    {
        public readonly WebDriverFactory _driverFactory;
        private readonly IWebDriver _driver;
        public string Name { get; set; }
        public Locator Locator { get; set; }
        private IWebElement? _webElement;
        public BaseWebElement(string name, Locator locator, WebDriverFactory driverFactory)
        {
            Name = name;
            Locator = locator;
            _driverFactory = driverFactory;
            _driver = _driverFactory.GetInstanceOf();
        }
        public IWebElement WebElement
        {
            get
            {
                if (_webElement == null)
                {
                    _webElement = _driver.FindElement(ConvertLocatorToBy(Locator));
                }
                return _webElement;
            }
        }
        public By ConvertLocatorToBy(Locator locator)
        {
            return locator.Type switch
            {
                LocatorType.XPath => By.XPath(locator.Value),
                LocatorType.Id => By.Id(locator.Value),
                _ => throw new NotImplementedException()
            };
        }
        public List<IWebElement> FindElements()
        {
            return _driver.FindElements(ConvertLocatorToBy(Locator)).ToList();
        }
        public string GetValue()
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            return WebElement.GetAttribute("value");
        }
        public bool Displayed()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
                return WebElement.Displayed;
            }
            catch
            {
                return false;
            }
        }
        public bool NotDisplayed()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToDisappear(ConvertLocatorToBy(Locator), ConfigModel.UI_ShortWait);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Hover()
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(WebElement).Perform();
        }

        public string GetColor()
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);
            return WebElement.GetCssValue("color");
        }


    }
}
