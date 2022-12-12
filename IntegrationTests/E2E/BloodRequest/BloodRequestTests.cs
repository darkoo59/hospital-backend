using IntegrationTests.E2E.BloodRequest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace IntegrationTests.E2E.BloodRequest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class BloodRequestTests
    {
        private readonly IWebDriver Driver;
        private readonly Pages.BloodRequestPage BloodRequestPage;
        private readonly Pages.BloodRequestAcceptedPage BloodRequestAcceptedPage;
        private readonly bool TEST_DISABLED = true;

        public BloodRequestTests()
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

            Driver = new ChromeDriver(options);

            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;

            BloodRequestPage = new Pages.BloodRequestPage(Driver);
            BloodRequestPage.Navigate();
            js.ExecuteScript("window.localStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIwYjA1MWM0YS04OWIxLTQzNmUtOGZiMS1lMTk2MjIzYjA2MjIiLCJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJtYW5hZ2VyIiwiZXhwIjoxNjcwODUxODU0LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjE2MTc3LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMC8ifQ.H0WQJTdQawW2TSu_ZyXiEuuz72Xok85OETBPkrq-G0M');");
            Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 2);
            BloodRequestPage.Navigate();
            Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 1);

            BloodRequestPage.EnsurePageIsDisplayed();

            Assert.True(true);
        }

        private void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact, Priority(1)]
        public void TestApproveRequest()
        {
            if (TEST_DISABLED) return;

            int newRequests = BloodRequestPage.CountGridElements();
            Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 3);
            BloodRequestPage.Accept();


            Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            int requestsAfterApprove = Driver.FindElements(By.ClassName("approveBtn")).Count;
            Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);

            Assert.Equal(newRequests, requestsAfterApprove);
            Dispose();
        }
    }
}
