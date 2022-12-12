using System;
using IntegrationTests.E2E.BBRegistration.Pages;
using IntegrationTests.E2E.ReportConfiguration.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace IntegrationTests.E2E.ReportConfiguration
{
    [Collection("collection")]
    public class ReportConfigurationTests 
    {
        private readonly IWebDriver _driver;
        private readonly ReportConfigurationPage _configurationPage;
        private readonly bool TEST_DISABLED = true;

        public ReportConfigurationTests()
        {
            if (TEST_DISABLED) return;

            ChromeOptions options = new();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            _driver = new ChromeDriver(options);

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            _configurationPage = new ReportConfigurationPage(_driver);
            _configurationPage.Navigate();
            js.ExecuteScript("window.localStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI5MzIwNTdjNy05YzkwLTQ5Y2QtOTk1ZC1jNGIwOGZlNzAyNjgiLCJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJtYW5hZ2VyIiwiZXhwIjoxNjcwODQ1OTE2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjE2MTc3LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMC8ifQ.HEDk9-oY5wMEK8D1glDZ1HQciK0CjAIJVkZpw00a-wU');");
            _driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 2);
            _configurationPage.Navigate();
            _driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 1);
            _configurationPage.EnsurePageIsDisplayed();

            Assert.True(_configurationPage.FormDisplayed());
            Assert.True(_configurationPage.SubmitDisplayed());
        }

        private void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void TestInvalidInput()
        {
            if (TEST_DISABLED) return;
            Assert.True(_configurationPage.FormDisplayed() && _configurationPage.SubmitDisplayed());
            Dispose();
        }

        [Fact]
        public void TestValidInput()
        {
            if (TEST_DISABLED) return;

            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 2);
            _configurationPage.MatSelectInput("report-configuration-bb-select", "bank1");
            _configurationPage.InsertFrequency("5");
            _configurationPage.SelectFrequencyTypeDay();
            _configurationPage.InsertPeriod("3");
            _configurationPage.SelectPeriodTypeDay();

            _configurationPage.SubmitForm();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);

            string expected = "Successfully updated";
            string actual = _configurationPage.GetPopupMessage();

            Assert.Equal(expected, actual);
            Dispose();
        }
    }
}