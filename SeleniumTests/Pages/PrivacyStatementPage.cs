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
    class PrivacyStatementPage
    {
        private readonly IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public string Heading
        {
            get
            {
                log.Info("Getting Privacy Statement heading");
                return driver.FindElement(By.ClassName("text__heading")).Text;
            }
        }


        public PrivacyStatementPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
