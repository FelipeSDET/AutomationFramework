using ConfigurationProvider;
using ConfigurationProvider.Classes;
using Tests.Models;
using WebDriverProvider.Classes;

namespace Tests.PageObjects
{
    [View("Login Page")]
    public partial class LoginPage : BasePageObject
    {
        public LoginPage(WebDriverFactory driverFactory) : base(driverFactory) { }
        public void LoginUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            LoginWithCredentials(user);
        }
    }
}
