using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using ModelBasedTesting.Helpers;

namespace ModelBasedTesting.SharedStates
{
    public class USONPMSharedState
    {

        private IWebDriver driver;

        public USONPMSharedState(Browser browser)
        {
            driver = browser.Driver;
        }

        public void e_CloseManageReports()
        {
            Console.WriteLine("e_CloseManageReports");
        }


        public void e_CloseNewReport()
        {
            Console.WriteLine("e_CloseNewReport");
        }


        public void e_GoToDashboard()
        {
            driver.FindElement(By.CssSelector("div[data-help-overlay-key=TabDashBoard]")).Click();
        }


        public void e_GoToFavouriteReports()
        {
            driver.FindElement(By.CssSelector("div[data-help-overlay-key=TabFavorite]")).Click();
        }


        public void e_GoToPages()
        {
            IWebElement div = driver.FindElement(By.CssSelector(".logo-uson-pm"));
            div.FindElement(By.CssSelector("a")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement header = driver.FindElement(By.CssSelector("a[test-id=dropDownUser]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(header));
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"{i + 1} seconds have passed and waiting...");
                System.Threading.Thread.Sleep(1000);
            }
        }


        public void e_GoToManageReports()
        {
            Console.WriteLine("e_GoToManageReports");
        }


        public void e_GoToNewReport()
        {
            Console.WriteLine("e_GoToNewReport");
        }


        public void e_GoToPublicReports()
        {
            driver.FindElement(By.CssSelector("div[data-help-overlay-key=TabPublic]")).Click();
        }


        public void e_GoToSharedReports()
        {
            driver.FindElement(By.CssSelector("div[data-help-overlay-key=TabShared]")).Click();
        }


        public void e_Login()
        {
            IWebElement usernameElement = driver.FindElement(By.CssSelector("input[test-id=loginUserName]"));
            IWebElement passswordElement = driver.FindElement(By.CssSelector("input[test-id=loginUserPassword]"));
            IWebElement submitElement = driver.FindElement(By.CssSelector("button[test-id=loginButton]"));
            const string USERNAME = "admin";
            usernameElement.SendKeys(USERNAME);

            const string PASSWORD = "123";
            passswordElement.SendKeys(PASSWORD);

            submitElement.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement header = driver.FindElement(By.CssSelector("a[test-id=dropDownUser]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(header));
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"{i + 1} seconds have passed and waiting...");
                System.Threading.Thread.Sleep(1000);
            }
        }


        public void e_Logout()
        {
            driver.FindElement(By.CssSelector("a[test-id=dropDownUser]")).Click();
            driver.FindElement(By.CssSelector("a[title=Logout]")).Click();
        }


        public void e_GoToPrivateReports()
        {
            driver.FindElement(By.CssSelector("div[data-help-overlay-key=TabPrivate]")).Click();
        }


        public void e_StartBrowser()
        {
            driver.Navigate().GoToUrl("http://10.10.5.23/PM_9.0_AVEA/Login.aspx");
        }


        public void v_Dashboard()
        {
            Console.WriteLine("v_Dashboard");
        }


        public void v_FavouriteReports()
        {
            Console.WriteLine("v_FavouriteReports");
        }


        public void v_Home()
        {
            driver.FindElement(By.CssSelector("a[test-id=dropDownUser]")).Text.Contains("admin").Should().BeTrue();
        }


        public void v_Pages()
        {
            Console.WriteLine("v_Pages");
        }


        public void v_LoginPage()
        {
            driver.FindElements(By.CssSelector("pi-login-form")).Count.Should().Be(1);
        }


        public void v_ManageReports()
        {
            Console.WriteLine("v_ManageReports");
        }


        public void v_NewReport()
        {
            Console.WriteLine("v_NewReport");
        }


        public void v_PrivateReports()
        {
            Console.WriteLine("v_PrivateReports");
        }


        public void v_PublicReports()
        {
            Console.WriteLine("v_PublicReports");
        }


        public void v_SharedReports()
        {
            Console.WriteLine("v_SharedReports");
        }
    }
}