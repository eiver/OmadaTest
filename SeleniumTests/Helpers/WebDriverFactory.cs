using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Helpers
{
    public enum Browser
    {
        Firefox,
        Chrome
    }

    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Firefox:
                    return CreateFirefoxDriver();
                case Browser.Chrome:
                    return CreateChromeDriver();
                default:
                    throw new Exception("Unsupported browser");
            }
        }

        static IWebDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", TestContext.CurrentContext.WorkDirectory);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream pdf");
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("pdfjs.disabled", true);
            var driver = new FirefoxDriver(TestContext.CurrentContext.TestDirectory, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return driver;
        }

        static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", TestContext.CurrentContext.WorkDirectory);
            return new ChromeDriver(options);
        }
    }
}
