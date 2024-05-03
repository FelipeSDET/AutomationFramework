using ConfigurationProvider.Classes.Elements;
using ConfigurationProvider.Classes;
using ConfigurationProvider.Elements;
using ConfigurationProvider.Enums;

namespace Tests.PageObjects
{
    public partial class CommonPage
    {
        [Element("CommonButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//*[contains(text(), '{0}')]")]
        public Button? CommonButton { get; }

        [Element("CommonDropdownById", ElementType.DropDown)]
        [Locator(LocatorType.Id, "{0}")]
        public DropDown? CommonDropdownById { get; }
    }
}
