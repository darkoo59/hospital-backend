using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Priority;
using Xunit;
using OpenQA.Selenium;
using IntegrationTests.E2E.BBRegistration.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace IntegrationTests.E2E.BBQuantityCheck
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class BBQuantityCheckTests
    {
        private readonly IWebDriver Driver;
        private readonly Pages.CheckPage CheckPage;
        private readonly bool TEST_DISABLED = false;

        public BBQuantityCheckTests()
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

            CheckPage = new Pages.CheckPage(Driver);
            CheckPage.Navigate();
            //eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJlbWFpbDJAZ21haWwuY29tIiwiZXhwIjoxNjczMjkyMjk1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAvIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0MjAwLyJ9.aLBtIZricdofJFDJQjE8cqRsNEHV-XvWG7t9UFFb6Xa0BwJxF3O5qu8w25F4GHy4bLWO54rmKO9wpNE52HkkAQ
            js.ExecuteScript("window.localStorage.setItem('third-party-token', 'eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJlbWFpbDJAZ21haWwuY29tIiwiZXhwIjoxNjczMjkyMjk1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAvIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0MjAwLyJ9.aLBtIZricdofJFDJQjE8cqRsNEHV-XvWG7t9UFFb6Xa0BwJxF3O5qu8w25F4GHy4bLWO54rmKO9wpNE52HkkAQ');");
            js.ExecuteScript("window.localStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI0OTJmYzJlMi1iZDcwLTQzY2ItODg0Mi01YTEyMzJmNjk2YzUiLCJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJtYW5hZ2VyIiwiZXhwIjoxNjcwODQyNzU0LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjE2MTc3LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMC8ifQ.HI6Qy2_wihdLkyscPIiCK9aASsexCdXAZt6YlmbwNB4');");
            CheckPage.Navigate();
            CheckPage.EnsurePageIsDisplayed();

            Assert.True(CheckPage.FormDisplayed());
            Assert.True(CheckPage.SubmitDisplayed());
        }

        [Fact, Priority(1)]
        public void TestValidInputWithoutQuantity()
        {
            if (TEST_DISABLED) return;

            Driver.ExecuteJavaScript("document.getElementById('check-user').removeAttribute('readonly')");
            CheckPage.InsertUser("email2@gmail.com");
            Driver.ExecuteJavaScript("document.getElementById('check-bb').removeAttribute('readonly')");
            CheckPage.InsertBB("app2");
            CheckPage.MatSelectBloodType("A-");
            CheckPage.InsertKey("kljuc_2");

            CheckPage.SubmitForm();


            string expected = "Blood of the desired type is available";
            string actual = CheckPage.GetPopupMessage();
            Assert.Equal(expected, actual);
        }

        [Fact, Priority(2)]
        public void TestValidInputWithQuantity()
        {
            if (TEST_DISABLED) return;

            Driver.ExecuteJavaScript("document.getElementById('check-user').removeAttribute('readonly')");
            CheckPage.InsertUser("email2@gmail.com");
            Driver.ExecuteJavaScript("document.getElementById('check-bb').removeAttribute('readonly')");
            CheckPage.InsertBB("app2");
            CheckPage.MatSelectBloodType("A-");
            CheckPage.InsertKey("kljuc_2");
            CheckPage.CheckQuantity();
            CheckPage.InsertQuantity("1");

            CheckPage.SubmitForm();


            string expected = "Blood of the desired type is available";
            string actual = CheckPage.GetPopupMessage();
            Assert.Equal(expected, actual);
        }

        [Fact, Priority(3)]
        public void TestInvalidKey()
        {
            if (TEST_DISABLED) return;

            Driver.ExecuteJavaScript("document.getElementById('check-user').removeAttribute('readonly')");
            CheckPage.InsertUser("email2@gmail.com");
            Driver.ExecuteJavaScript("document.getElementById('check-bb').removeAttribute('readonly')");
            CheckPage.InsertBB("app2");
            CheckPage.MatSelectBloodType("A-");
            CheckPage.InsertKey("wrong");

            CheckPage.SubmitForm();


            string expected = "API key is not valid";
            string actual = CheckPage.GetErrorMessage();
            Assert.Equal(expected, actual);
        }

        private void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
