using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Logging;

namespace ModelBasedTesting.Helpers
{
    public class Browser
    {
        public IWebDriver Driver { get; private set; }

        public Browser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-ssl-errors=yes", "--ignore-certificate-errors", "--window-size=1600,900");
            options.AddArgument("no-sandbox");
            Driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application\", options = options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}