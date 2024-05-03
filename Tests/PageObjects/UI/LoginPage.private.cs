using Tests.Models;

namespace Tests.PageObjects
{
    public partial class LoginPage
    {
        private void LoginWithCredentials(User user)
        {
            try
            {
                ClickButton("LoginButton", "Login Page");
                WriteInput("EmailTextBox", "Login Page", user.Email!);
                WriteInput("PasswordTextBox", "Login Page", user.Password!);
                ClickButton("LoginFinalButton", "Login Page");
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to Log In with Given Credentials. {e.Message}.", e.InnerException);
            }
        }
    }
}
