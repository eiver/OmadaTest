using log4net;
using OpenQA.Selenium;
using SeleniumTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Pages
{
    class DownloadTakedaCasePage
    {
        IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public IWebElement DownloadCustomerCaseTakedaLink
        {
            get
            {
                log.Info("Getting Download Customer Case Takeda Link");
                return driver.FindElements(By.XPath("//a[text() = 'Download Customer Case: Takeda']")).Single();
            }
        }

        public void ClickDownloadCustomerCaseTakedaLink()
        {
            log.Info("Clicking on Download Customer Case Takeda Link");
            DownloadCustomerCaseTakedaLink.Click();
        }

        public DownloadTakedaCasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            log.Info("Opening Download Customer Case Takeda");
            driver.Navigate().GoToUrl(@"https://www.omada.net/en-us/more/customers/cases/takeda-case/download-case--takeda");
        }
    }
}
