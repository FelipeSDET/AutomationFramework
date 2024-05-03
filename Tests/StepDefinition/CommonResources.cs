using APIProvider.Classes;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDriverProvider.Classes;
using ConfigurationProvider;

namespace Tests.StepDefinitions.UI
{
    [Binding]
    public class CommonResourcesUI
    {
        protected readonly ScenarioContext _scenarioContext;
        protected readonly WebDriverFactory _factory;
        protected readonly CommonPage _commonPageObject;
        protected readonly LoginPage _loginPageObject;

        public CommonResourcesUI(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _commonPageObject = new CommonPage(_factory);
            _loginPageObject = new LoginPage(_factory);
        }
    }
}