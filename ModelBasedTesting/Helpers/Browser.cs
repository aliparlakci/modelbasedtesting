using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ModelBasedTesting.Helpers
{
    class Browser
    {
        private static IWebDriver driver;

        static int timeOut = 10;

        public static IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            return driver;
        }
    }
}