using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace IntegrationTests.E2E.BBRegistration.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:4200/manager/bb-register";
        public string Title => Driver.Title;
        private IWebElement Form => Driver.FindElement(By.TagName("form"));
        private IWebElement Submit => Driver.FindElement(By.Id("bb-register-submit"));
        private IWebElement Email => Driver.FindElement(By.Id("bb-register-email"));
        private IWebElement Name => Driver.FindElement(By.Id("bb-register-name"));
        private IWebElement Server => Driver.FindElement(By.Id("bb-register-server"));
        private IWebElement Error => Driver.FindElement(By.Id("bb-register-error"));

        public RegisterPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return FormDisplayed() && SubmitDisplayed();
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void SubmitForm()
        {
            Submit.Click();
        }

        public bool FormDisplayed()
        {
            return Form.Displayed;
        }
        public bool SubmitDisplayed()
        {
            return Submit.Displayed;
        }
        public void InsertName(string name)
        {
            Name.SendKeys(name);
        }

        public void InsertEmail(string email)
        {
            Email.SendKeys(email);
        }

        public void InsertServer(string server)
        {
            Server.SendKeys(server);
        }

        public string GetErrorMessage()
        {
            var el = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                        .Until(drv => drv.FindElement(By.Id("bb-register-error")));
            return el.Text; 
        }

        public string GetPopupMessage()
        {
            var el = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                        .Until(drv => drv.FindElement(By.ClassName("mat-simple-snack-bar-content")));
            return el.Text;
        }

        public bool ErrorDisplayed()
        {
            return Error.Displayed;
        }

        public void Navigate() => Driver.Navigate().GoToUrl(URI);
    }
}
