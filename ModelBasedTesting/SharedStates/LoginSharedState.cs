using OpenQA.Selenium;
using FluentAssertions;
using System.Collections;
using ModelBasedTesting.Helpers;

namespace ModelBasedTesting.SharedStates
{
    public class LoginSharedState
    {
        public void e_StartBrowser()
        {
            System.Console.WriteLine("      Executing the action e_StartBrowser");
        }

        public void e_Login()
        {
            System.Console.WriteLine("      Executing the action e_Login");
        }

        public void v_LoginPage()
        {
            System.Console.WriteLine("      Testing the v_LoginPage");
        }

        public void v_HomePage()
        {
            System.Console.WriteLine("      Testing the v_HomePage");
        }

    }
    // public class LoginSharedState
    // {
    //     static IWebDriver driver = Browser.GetWebDriver();

    //     public void e_StartBrowser()
    //     {
    //         driver.Navigate().GoToUrl("https://v30s6-qatst01/USON_7.0_WCP/app/login?localAccess=true");
    //     }

    //     public void v_LoginPage()
    //     {
    //         driver.FindElements(By.ClassName("form login")).Count.Should().Be(1);
    //     }

    //     public void e_Login()
    //     {
    //         IWebElement usernameElement = driver.FindElement(By.CssSelector("input[test-id=loginUserName]"));
    //         IWebElement passswordElement = driver.FindElement(By.CssSelector("input[test-id=loginPassword]"));
    //         IWebElement submitElement = driver.FindElement(By.CssSelector("button[test-id=loginSubmit]"));
    //         const string USERNAME = "admin";
    //         usernameElement.SendKeys(USERNAME);

    //         const string PASSWORD = "123";
    //         passswordElement.SendKeys(PASSWORD);

    //         submitElement.Click();
    //     }
    // }

}