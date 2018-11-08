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
    class GartnerIAMSummit2016LondonPage
    {
        private readonly IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public string Heading
        {
            get
            {
                log.Info("Getting Gartner IAM Summit 2016 London page heading");
                return driver.FindElement(By.ClassName("text__heading")).Text;
            }
        }

        public GartnerIAMSummit2016LondonPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
