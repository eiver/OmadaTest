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
    class CustomerCasesPage
    {
        IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public IWebElement FirstDownloadPdfButton
        {
            get
            {
                log.Info("Getting first Download PDF button");
                return driver.FindElement(By.ClassName("cases__button"));
            }
        }

        public TakedaCasePage ClickDownloadPDFButton()
        {
            log.Info("Clicking first Download PDF button");
            FirstDownloadPdfButton.Click();
            return new TakedaCasePage(driver);
        }
        
        public CustomerCasesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
