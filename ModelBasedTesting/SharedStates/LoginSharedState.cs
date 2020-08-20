using OpenQA.Selenium;
using FluentAssertions;
using System.Collections;
using ModelBasedTesting.Helpers;

namespace ModelBasedTesting.SharedStates
{

    public class LoginSharedState
    {
        static IWebDriver driver = Browser.GetWebDriver();

        public void e_StartBrowser()
        {
            driver.Navigate().GoToUrl("https://v30s6-qatst01/USON_7.0_WCP/app/login?localAccess=true");
        }

        public void v_LoginPage()
        {
            driver.FindElements(By.CssSelector(".form.login")).Count.Should().Be(1);
        }

        public void e_Login()
        {
            IWebElement usernameElement = driver.FindElement(By.CssSelector("input[test-id=loginUserName]"));
            IWebElement passswordElement = driver.FindElement(By.CssSelector("input[test-id=loginPassword]"));
            IWebElement submitElement = driver.FindElement(By.CssSelector("button[test-id=loginSubmit]"));
            const string USERNAME = "admin";
            usernameElement.SendKeys(USERNAME);

            const string PASSWORD = "123";
            passswordElement.SendKeys(PASSWORD);

            submitElement.Click();
        }

        public void v_HomePage()
        {
            System.Console.WriteLine("      Dummy test for HomePage");
        }
    }

}