using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ModelBasedTesting.Helpers
{
    class Browser
    {
        private static IWebDriver driver;

        public static IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application\");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            return driver;
        }
    }
}