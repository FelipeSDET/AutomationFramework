using ConfigurationProvider.Classes;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TechTalk.SpecFlow;
using Tests.Models;
using WebDriverProvider.Configurations;
using ConfigurationProvider;
using Tests.StepDefinitions.UI;

namespace Tests.StepDefinition
{
    [Binding]
    public class LoginStepDefinition : CommonResourcesUI
    {
        public LoginStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"the user navigates to the login page")]
        public void GivenTheUserNavigatesToTheLandingPage()
        {
            _factory.NavigateToBaseUrl();
        }

        [Given(@"the user sums (.*) and (.*)")]
        public void GivenTheUserSumsAnd(int p0, int p1)
        {
            Assert.That((p0 + p1).Equals(4));
        }

        [When(@"the user inputs correct credentials to log in")]
        public void WhenTheUserInputsCorrectCredentialsToLogIn()
        {
            User user = new User()
            {
                Email = ConfigModel.TESTUSER_EMAIL,
                Password = ConfigModel.TESTUSER_PASSWORD,
            };
            _loginPageObject.LoginUser(user);
        }

        [When(@"the user inputs incorrect credentials to log in")]
        public void WhenTheUserInputsInorrectCredentialsToLogIn()
        {
            User incorrectUser = new User()
            {
                Email = "incorrectUser@gmail.com",
                Password = "incorrectPassword"
            };
            _loginPageObject.LoginUser(incorrectUser);
        }

        [Then(@"the user should be succesfully logged in")]
        public void ThenTheUserShouldBeSuccesfullyLoggedIn()
        {

        }

        [Then(@"the user should not be succesfully logged in")]
        public void ThenTheUserShouldNotBeSuccesfullyLoggedIn()
        {
            Assert.That(_loginPageObject.IsDisplayed("BadLogInAlert", "Login Page"), Is.True);
        }


    }
}
