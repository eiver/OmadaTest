using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Pages
{
    class ContactPage
    {
        private readonly IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public IWebElement USWest
        {
            get
            {
                log.Info("Getting U.S. West tab");
                return driver.FindElements(By.XPath("//span[contains(@class, 'tabmenu__menu-item') and text() = 'U.S. West']")).Single();
            }
        }

        public IWebElement Denmark
        {
            get
            {
                log.Info("Getting Denmark tab");
                return driver.FindElements(By.XPath("//span[contains(@class, 'tabmenu__menu-item') and text() = 'Denmark']")).Single();
            }
        }

        public void ClickUSWest()
        {
            log.Info("Clicking on U.S. West tab");
            USWest.Click();
        }

        public void MouseOverDenmark()
        {
            log.Info("Moving mouse over Denmark tab");
            var mouseOver = new Actions(driver);
            mouseOver.MoveToElement(Denmark).Build().Perform();
        }

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
