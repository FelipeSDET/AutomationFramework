using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;
using TechTalk.SpecFlow;
using ConfigurationProvider;
using APIProvider.Classes;
using Tests.Models;
using Allure.Net.Commons;
using OpenQA.Selenium;

namespace Tests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public static AllureLifecycle allure = AllureLifecycle.Instance;
        private readonly ScenarioContext _scenarioContext;
        public readonly RestHelper? _todolyAPI_client;
        private WebDriverFactory? _factory;
        private string[] scenarioTags;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            scenarioTags = _scenarioContext.ScenarioInfo.ScenarioAndFeatureTags;
            if (!scenarioTags.Contains("ApiScenario"))
            {
                _factory = new WebDriverFactory();
            }
            else
            {
                _todolyAPI_client = new RestHelper(ConfigModel.API_TODO_LY_URL);
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
        }

        [BeforeFeature]
        public static void logBeforeFeatureExecution(FeatureContext _featureContext)
        {
            Logger.WriteLine($"================= Feature: {_featureContext.FeatureInfo.Title} =================");
        }

        [BeforeScenario(Order = 0)]
        public static void logBeforeScenarioExecution(ScenarioContext _scenarioContext)
        {
            Logger.WriteLine($"==== Scenario: {_scenarioContext.ScenarioInfo.Title} ====");
        }

        [BeforeStep]
        public static void LogBeforeStepExecution(ScenarioContext scenarioContext)
        {
            var stepInfo = scenarioContext.StepContext.StepInfo;
            Logger.WriteLine($"Executing step [{stepInfo.StepDefinitionType}]: {stepInfo.Text}");
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Logger.WriteLine($"==== BeforeScenario Hook: Create Driver & Log In ====");
            if (!scenarioTags.Contains("ApiScenario"))
            {
                if (!scenarioTags.Contains("LogInFeature"))
                {
                    User user = new User()
                    {
                        Email = ConfigModel.TESTUSER_EMAIL,
                        Password = ConfigModel.TESTUSER_PASSWORD
                    };

                    _factory?.NavigateToBaseUrl();
                }

                scenarioContext["DriverFactory"] = _factory;
            }
            else
            {
            }
        }

        [AfterStep]
        public static void logAfterStepExecution(ScenarioContext _scenarioContext)
        {
            string statusMessage = "Status: ";
            if (_scenarioContext.TestError != null)
            {
                statusMessage += "FAILED" + " => " + _scenarioContext.TestError.Message;
            }
            else
            {
                statusMessage += "PASSED";
            }

            Logger.WriteLine(statusMessage);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            if (!scenarioTags.Contains("ApiScenario"))
            {
                var factory = (WebDriverFactory)scenarioContext["DriverFactory"];

                if (factory is not null)
                {
                    var driver = factory.GetInstanceOf();

                    if (driver is not null)
                    {
                        factory.TerminateWebDriver();
                    }
                }
            }
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            var scenarioTags = scenarioContext.ScenarioInfo.ScenarioAndFeatureTags;
            if (scenarioContext.TestError != null && !scenarioTags.Contains("ApiScenario"))
            {
                byte[] screenshot = GetScreenshot(scenarioContext);
                if (screenshot != null)
                {
                    AllureApi.AddAttachment(
                        "Failed test screenshot",
                        "image/png",
                        screenshot,
                        ".png"
                    );
                }
            }
        }

        private static byte[] GetScreenshot(ScenarioContext scenarioContext)
        {
            var factory = (WebDriverFactory)scenarioContext["DriverFactory"];
            var driver = factory.GetInstanceOf();
            if (driver is ITakesScreenshot takesScreenshot)
            {
                return takesScreenshot.GetScreenshot().AsByteArray;
            }
            return null!;
        }
    }
}
