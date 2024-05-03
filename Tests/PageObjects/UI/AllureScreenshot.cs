using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class ScreenshotHelper
{
    public static void CaptureAllureReportScreenshot()
    {
        var options = new ChromeOptions();
        if (bool.Parse(Environment.GetEnvironmentVariable("IsRemote") ?? "false"))
        {
            options.AddArguments("--headless", "--no-sandbox", "--disable-dev-shm-usage");
        }

        using (var driver = new ChromeDriver(options))
        {
            driver.Navigate().GoToUrl("(System.DefaultWorkingDirectory)/allure_report/index.html");
            var screenshot = driver.GetScreenshot();
            screenshot.SaveAsFile("allure-report.png");
        }
    }
}