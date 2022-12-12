using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTests.E2E.ReportConfiguration.Pages
{
    public class ReportConfigurationPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/manager/report-configuration";
        public string Title => _driver.Title;
        private IWebElement Form => _driver.FindElement(By.TagName("form"));
        private IWebElement Submit => _driver.FindElement(By.Id("report-configuration-submit"));
        //private SelectElement BBSelect => new SelectElement(_driver.FindElement(By.Id("report-configuration-bb-select")));
        private IWebElement Frequency => _driver.FindElement(By.Id("report-configuration-frequency"));
        private IWebElement FrequencyTypeDay => _driver.FindElement(By.Id("report-configuration-frequency-type-day"));
        private IWebElement Period => _driver.FindElement(By.Id("report-configuration-period"));
        private IWebElement PeriodTypeDay => _driver.FindElement(By.Id("report-configuration-period-type-day"));
        private IWebElement Error => _driver.FindElement(By.Id("report-configuration-error"));

        public ReportConfigurationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
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
        //public void SelectBB(int id)
        //{
        //    BBSelect.SelectByIndex(id);
        //}

        public void MatSelectInput(string id, string value) {
            _driver.FindElement(By.Id(id)).Click();
            _driver.FindElement(By.Id(value)).Click();
        }

        public void InsertFrequency(string number)
        {
            Frequency.Clear();
            Frequency.SendKeys(number);
        }

        public void SelectFrequencyTypeDay()
        {
            FrequencyTypeDay.Click();
        }

        public void InsertPeriod(string number)
        {
            Period.Clear();
            Period.SendKeys(number);
        }

        public void SelectPeriodTypeDay()
        {
            PeriodTypeDay.Click();
        }

        public string GetErrorMessage()
        {
            var el = new WebDriverWait(_driver, TimeSpan.FromSeconds(30))
                        .Until(drv => drv.FindElement(By.Id("report-configuration-error")));
            return el.Text; 
        }

        public string GetPopupMessage()
        {
            var el = new WebDriverWait(_driver, TimeSpan.FromSeconds(30))
                        .Until(drv => drv.FindElement(By.ClassName("mat-simple-snack-bar-content")));
            return el.Text;
        }

        public bool ErrorDisplayed()
        {
            return Error.Displayed;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
    }
}
