using ConfigurationProvider.Classes;
using WebDriverProvider.Classes;

namespace Tests.PageObjects
{
    [View("Common Page")]
    public partial class CommonPage : BasePageObject
    {
        public CommonPage(WebDriverFactory driverFactory) : base(driverFactory) { }
    }
}
