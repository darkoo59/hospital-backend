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
        private readonly bool TEST_DISABLED = false;

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

            BloodRequestPage = new Pages.BloodRequestPage(Driver);
            BloodRequestAcceptedPage = new BloodRequestAcceptedPage(Driver);
            BloodRequestPage.Navigate();
            BloodRequestPage.EnsurePageIsDisplayed();

            Assert.True(BloodRequestPage.GridDisplayed());
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

            BloodRequestPage.Accept();

            var el = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

            int requestsAfterApprove = BloodRequestPage.CountGridElements();

            Assert.Equal(newRequests - 1, requestsAfterApprove);

        }
    }
}
