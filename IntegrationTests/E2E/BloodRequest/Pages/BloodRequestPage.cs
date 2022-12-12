using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.E2E.BloodRequest.Pages
{
    public class BloodRequestPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:4200/manager/blood-req/new";

        public string Title => Driver.Title;

        //private IWebElement Grid => Driver.FindElement(By.ClassName("grid"));
        private ICollection<IWebElement> ApproveBtn => Driver.FindElements(By.ClassName("approveBtn"));

        public BloodRequestPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            //var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
            Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            /*
            wait.Until(condition =>
            {
                try
                {
                    return GridDisplayed();
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
            */
        }

        public void GridDisplayed()
        {
            //return Grid.Displayed;
        }

        public int CountGridElements()
        {
            return Driver.FindElements(By.ClassName("approveBtn")).Count;
        }

        public void Accept()
        {
            ApproveBtn.FirstOrDefault().Click(); 
        }

        public void Navigate() => Driver.Navigate().GoToUrl(URI);
    }
}
