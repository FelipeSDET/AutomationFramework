using OpenQA.Selenium;
using WebDriverProvider.Enums;

namespace WebDriverProvider.Interfaces;
public interface IBrowserOptionsConfigurator
{
    DriverOptions ConfigureOptions(bool isHeadless);
}