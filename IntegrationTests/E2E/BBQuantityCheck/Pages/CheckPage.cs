using Grpc.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationTests.E2E.BBQuantityCheck.Pages
{
    public class CheckPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:4200/integration/bloodtypes";
        public string Title => Driver.Title;
        private IWebElement Form => Driver.FindElement(By.TagName("form"));
        private IWebElement Submit => Driver.FindElement(By.Id("check-submit"));
        private IWebElement User => Driver.FindElement(By.Id("check-user"));
        private IWebElement BloodBank => Driver.FindElement(By.Id("check-bb"));
        private IWebElement BloodType => Driver.FindElement(By.Id("check-blood-type"));
        private IWebElement Key => Driver.FindElement(By.Id("check-key"));
        private IWebElement QuantityCheck => Driver.FindElement(By.Id("check-quantity"));
        private IWebElement QuantityInput => Driver.FindElement(By.Id("check-quantity-input"));
        private IWebElement Error => Driver.FindElement(By.Id("mat-error-0"));

        public CheckPage(IWebDriver driver)
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

        public bool IsBlank()
        {
            if (User.Text.Equals("") || BloodBank.Text.Equals(""))
                return true;
            return false;
        }

        public bool FormDisplayed()
        {
            return Form.Displayed;
        }
        public bool SubmitDisplayed()
        {
            return Submit.Displayed;
        }
        public void MatSelectBloodType(string id)
        {
            BloodType.Click();
            Driver.FindElement(By.Id(id)).Click();
        }

        public void InsertKey(string key)
        {
            Key.SendKeys(key);
        }

        public void CheckQuantity()
        {
            QuantityCheck.Click();
        }

        public void InsertQuantity(string number)
        {
            QuantityInput.SendKeys(number);
        }

        public void InsertUser(string name)
        {
            User.SendKeys(name);
        }

        public void InsertBB(string name)
        {
            BloodBank.SendKeys(name);
        }

        public string GetErrorMessage()
        {
            var el = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
                        .Until(drv => drv.FindElement(By.Id("mat-error-0")));
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
