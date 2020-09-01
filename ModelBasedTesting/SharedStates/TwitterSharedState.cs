using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using ModelBasedTesting.Helpers;

namespace ModelBasedTesting.SharedStates
{
    public class TwitterSharedState
    {

        private IWebDriver driver;

        public TwitterSharedState(Browser browser)
        {
            driver = browser.Driver;
        }

        public void e_StartBrowser()
        {
            driver.Navigate().GoToUrl("https://twitter.com");
        }

        public void v_LoginPage()
        {
            driver.FindElement(By.CssSelector("form[action=\"/sessions\"]"));
        }

        public void e_Login()
        {
            string pwd;
            const string USERNAME = "suphi_abi";
            using (StreamReader file = new StreamReader(@"twitter.txt"))
            {
                pwd = file.ReadLine();
            }
            IWebElement usernameElement = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div/main/div/div/div/div[1]/div[1]/div/form/div/div[1]/div/label/div/div[2]/div/input"));
            usernameElement.SendKeys(USERNAME);
            IWebElement passswordElement = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div/main/div/div/div/div[1]/div[1]/div/form/div/div[2]/div/label/div/div[2]/div/input"));
            IWebElement submitElement = driver.FindElement(By.CssSelector("div[data-testid=LoginForm_Login_Button]"));
            passswordElement.SendKeys(pwd);

            submitElement.Click();
            GraphWalkerClient.setData($"username=\"{USERNAME}\"");
        }

        public void e_Logout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement menu = driver.FindElement(By.CssSelector("div[data-testid=\"SideNav_AccountSwitcher_Button\"]"));
            menu.Click();
            IWebElement logout = driver.FindElement(By.CssSelector("a[data-testid=\"AccountSwitcher_Logout_Button\"]"));
            logout.Click();
            IWebElement confirm = driver.FindElement(By.CssSelector("div[data-testid=\"confirmationSheetConfirm\"]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(confirm));
            confirm.Click();
            GraphWalkerClient.setData("username=''");
        }

        public void v_Main()
        {
            string username = GraphWalkerClient.getData().GetValue("username").ToString();

            IWebElement profile = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/header/div/div/div/div[2]/div/div/div[2]/div/div[1]/div[1]/span/span"));
            profile.Text.Should().Be(username);
        }

        public void e_GoToHome()
        {
            IWebElement homeElement = driver.FindElement(By.CssSelector("a[data-testid=\"AppTabBar_Home_Link\"]"));
            homeElement.Click();
        }

        public void v_Home()
        {

        }

        public void e_OpenTweet()
        {

        }

        public void e_SendTweet()
        {

        }

        public void v_Tweet()
        {

        }

        public void e_DoLikeTweet()
        {

        }

        public void v_LikedTweet()
        {

        }

        public void e_GoToProfile()
        {
            IWebElement profileLinkElement = driver.FindElement(By.CssSelector("a[aria-label=\"Profile\"]"));
            profileLinkElement.Click();
        }

        public void v_Profile()
        {

        }
    }
}