using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests.Pages
{
    class HomePage
    {
        private readonly IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();
        IWebElement SearchBox
        {
            get
            {
                log.Info("Getting Searchbox");
                return driver.FindElements(By.XPath("/html/body/header/div/div/div/form/input")).Single();
            }
        }

        public string FirstHeadline
        {
            get
            {
                log.Info("Getting first headline");
                return driver.FindElement(By.ClassName("headline__heading")).Text;
            }
        }

        public IWebElement NavigationBar
        {
            get
            {
                log.Info("Getting navigation bar");
                return driver.FindElements(By.Id("navigation")).Single();
            }
        }

        public IWebElement More
        {
            get
            {
                log.Info("Getting More... link");
                return NavigationBar.FindElements(By.LinkText("More...")).Single();
            }
        }

        public IWebElement News
        {
            get
            {
                log.Info("Getting News link");
                return NavigationBar.FindElements(By.XPath("//a[text()='News']")).Single();
            }
        }

        public IWebElement Contact
        {
            get
            {
                log.Info("Getting contact link");
                return driver.FindElements(By.ClassName("header__menulink--function-nav")).Single(x => x.Text == "Contact");
            }
        }

        public IWebElement ReadPrivacyPolicy
        {
            get
            {
                log.Info("Getting Read Privacy Policy link");
                return driver.FindElements(By.ClassName("cookiebar__read-more")).Single();
            }
        }

        public IWebElement CookiebarContainer
        {
            get
            {
                log.Info("Getting Cookiebar Container");
                return driver.FindElements(By.ClassName("cookiebar__container")).Single();
            }
        }

        public IWebElement CookiebarCloseButton
        {
            get
            {
                log.Info("Getting Cookiebar close button");
                return driver.FindElements(By.ClassName("cookiebar__button")).Single();
            }
        }

        public IWebElement Cases
        {
            get
            {
                log.Info("Getting Cases link");
                return driver.FindElements(By.ClassName("footer__menulink--submenu")).Single(x => x.Text == "Cases");
            }
        }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void MouseOverMore()
        {
            log.Info("Moving mouse over More... link");
            var mouseOver = new Actions(driver);
            mouseOver.MoveToElement(More).Build().Perform();
        }

        public NewsPage ClickNews()
        {
            // Wait for the news animation to finish
            log.Info("Waiting for news animation to finish");

            int previousHeight = -1;
            int newHeight = News.Size.Height;

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d =>
            {
                if(newHeight == previousHeight)
                {
                    log.Info("News Animation finished");
                    return true;
                }
                else
                {
                    previousHeight = newHeight;
                    newHeight = News.Size.Height;
                    log.Info($"News height changed: {News.Size.Height}");
                    return false;
                }
            });

            //new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(d => 
            //    {
            //        int previousHeight = -1;
            //        int newHeight = News.Size.Height;
            //        Stopwatch timeout = new Stopwatch();
            //        timeout.Start();
            //        while (newHeight != previousHeight)
            //        {
            //            Thread.Sleep(500);
            //            previousHeight = newHeight;
            //            newHeight = News.Size.Height;
            //            log.Info($"News height changed: {News.Size.Height}");
            //            if (timeout.Elapsed > TimeSpan.FromSeconds(2)) throw new TimeoutException("Timeout while waiting for the news animation to finish");
            //        }
            //        log.Info("News Animation finished");
            //        return true;
            //    });

            log.Info("Clicking news");
            News.Click();
            return new NewsPage(driver);
        }

        public void Open()
        {
            log.Info("Opening home page");
            driver.Navigate().GoToUrl(@"https://omada.net");
        }

        public SearchResultsPage Search(string text)
        {
            log.Info($"Entering in search box: {text}");
            SearchBox.SendKeys(text);
            SearchBox.Submit();
            return new SearchResultsPage(driver);
        }

        public ContactPage ClickContact()
        {
            log.Info("Clicking contact");
            Contact.Click();
            return new ContactPage(driver);
        }

        public PrivacyStatementPage ControlClickReadPrivacyPolicy()
        {
            log.Info("Opening privacy policy in new tab");
            Actions controlClick = new Actions(driver);
            controlClick.KeyDown(Keys.Control).MoveToElement(ReadPrivacyPolicy).Click().KeyUp(Keys.Control).Perform();

            return new PrivacyStatementPage(driver);
        }

        public void ClickCookiebarCloseButton()
        {
            log.Info("Clicking Cookiebar Close Button");
            CookiebarCloseButton.Click();
        }

        public CustomerCasesPage ClickCases()
        {
            log.Info("Clicking Cases link");
            Cases.Click();
            return new CustomerCasesPage(driver);
        }
    }
}
