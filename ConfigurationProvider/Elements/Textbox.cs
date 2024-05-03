using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class TextBox : BaseWebElement
    {
        public TextBox(string name, Locator locator, WebDriverFactory driverFactory)
    : base(name, locator, driverFactory) { }

        public void SendKeys(string keyToSend)
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), ConfigModel.UI_LongWait);

            WebElement.Clear();
            WebElement.SendKeys(keyToSend);
            WebElement.SendKeys(Keys.Tab);
        }
    }
}
