using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Xunit.Priority;

namespace IntegrationTests.E2E.BBRegistration
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class BBRegistrationTests
    {
        private readonly IWebDriver Driver;
        private readonly Pages.RegisterPage RegisterPage;
        private readonly bool TEST_DISABLED = true;

        public BBRegistrationTests()
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

            RegisterPage = new Pages.RegisterPage(Driver);
            RegisterPage.Navigate();
            js.ExecuteScript("window.localStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI5MzIwNTdjNy05YzkwLTQ5Y2QtOTk1ZC1jNGIwOGZlNzAyNjgiLCJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJtYW5hZ2VyIiwiZXhwIjoxNjcwODQ1OTE2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjE2MTc3LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMC8ifQ.HEDk9-oY5wMEK8D1glDZ1HQciK0CjAIJVkZpw00a-wU');");
            RegisterPage.Navigate();
            RegisterPage.EnsurePageIsDisplayed();

            Assert.True(RegisterPage.FormDisplayed()); 
            Assert.True(RegisterPage.SubmitDisplayed());
        }

        private void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact, Priority(1)]
        public void TestInvalidServer()
        {
            if (TEST_DISABLED) return;
            RegisterPage.InsertEmail("email123@gmail.com");
            RegisterPage.InsertName("name123");
            RegisterPage.InsertServer("server");

            RegisterPage.SubmitForm();

            string expected = "No such host is known. (server:80)";
            string actual = RegisterPage.GetErrorMessage();

            Assert.Equal(expected, actual);
        }

        [Fact, Priority(2)]
        public void TestValid()
        {
            if (TEST_DISABLED) return;
            RegisterPage.InsertEmail("email123@gmail.com");
            RegisterPage.InsertName("name123");
            RegisterPage.InsertServer("localhost:6555");

            RegisterPage.SubmitForm();

            string expected = "Blood bank registered successfully";
            string actual = RegisterPage.GetPopupMessage();

            Assert.Equal(expected, actual);
        }

        [Fact, Priority(3)]
        public void TestDuplicate()
        {
            if (TEST_DISABLED) return;
            RegisterPage.InsertEmail("email123@gmail.com");
            RegisterPage.InsertName("name123");
            RegisterPage.InsertServer("localhost:6555");

            RegisterPage.SubmitForm();

            string expected = "User with given email already exists.";
            string actual = RegisterPage.GetErrorMessage();

            Assert.Equal(expected, actual);
        }
    }
}
