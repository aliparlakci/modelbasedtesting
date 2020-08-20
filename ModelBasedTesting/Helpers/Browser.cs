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
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--ignore-ssl-errors=yes", "--ignore-certificate-errors");
                driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application\", options = options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            return driver;
        }
    }
}