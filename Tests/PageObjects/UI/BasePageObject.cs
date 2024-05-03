using AngleSharp.Dom;
using ConfigurationProvider.Classes;
using ConfigurationProvider.Classes.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverProvider.Classes;

namespace Tests.PageObjects
{
    public abstract class BasePageObject
    {
        public WebDriverFactory _driverFactory;
        public readonly IWebDriver _driver;
        public BasePageObject(WebDriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
            _driver = _driverFactory.GetInstanceOf();
        }
        public void ClickButton(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _button = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _button.Click();
            }
            catch (Exception firstAttemptException)
            {
                try
                {
                    var _button = UIElementFactory.GetPOElement("ClosePopupButton", "Welcome Page", _driverFactory);
                    _button.Click();
                    SendGlobalEscape();

                    var _buttonRetry = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                    _buttonRetry.Click();
                }
                catch (Exception secondAttemptException)
                {
                    throw new Exception($"Unable to click the button after retry. First attempt: {firstAttemptException.Message}. Second attempt: {secondAttemptException.Message}.", secondAttemptException);
                }
            }
        }

        public void DoubleClickButton(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _button = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _button.DoubleClick();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to double click the button. {e.Message}.", e.InnerException);
            }
        }

        public void RightClickButton(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _button = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _button.RightClick();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to right click the button. {e.Message}.", e.InnerException);
            }
        }

        public void SendGlobalEscape()
        {
            try
            {
                Thread.Sleep(3000);
                Actions actions = new Actions(_driver);
                actions.SendKeys(Keys.Escape).Perform();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the button. {e.Message}.", e.InnerException);
            }
        }
        public void CheckElement(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _checkbox = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _checkbox.Check();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to check the element. {e.Message}.", e.InnerException);
            }
        }
        public void UncheckElement(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _checkbox = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _checkbox.Uncheck();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to uncheck the element. {e.Message}.", e.InnerException);
            }
        }
        public void CheckboxState(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _checkbox = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _checkbox.Uncheck();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to uncheck the element. {e.Message}.", e.InnerException);
            }
        }
        public void WriteInput(string elementName, string pageView, string argument = "")
        {
            try
            {
                var _textBox = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _textBox.SendKeys(argument);

            }
            catch (Exception e)
            {
                throw new Exception($"Unable to write the input. {e.Message}.", e.InnerException);
            }
        }
        public string ElementValue(string elementName, string pageView, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                return _element.GetValue();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to retrieve the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }

        public void SelectElementByValue(string elementName, string pageView, string value, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _element.SelectValue(value);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to set the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }
        public void SelectElementByText(string elementName, string pageView, string textToFind, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _element.SelectText(textToFind);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to set the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }
        public void SelectElementByContainingText(string elementName, string pageView, string value, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _element.SelectByTextContaining(value);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to set the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }

        public bool IsDisplayed(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                return _element.Displayed();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to find the element {elementName}. {e.Message}.", e.InnerException);
            }
        }

        public List<IWebElement> RetrieveElements(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                return _element.FindElements();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to find the elements {elementName}. {e.Message}.", e.InnerException);
            }
        }

        public void ElementHover(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _element.Hover();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to find the element {elementName}. {e.Message}.", e.InnerException);
            }
        }

        public string AttributeValue(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                return _element.GetColor();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to find the element {elementName}. {e.Message}.", e.InnerException);
            }
        }


    }
}
