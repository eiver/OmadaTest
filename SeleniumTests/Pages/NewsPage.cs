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
    class NewsPage
    {
        private readonly IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public List<string> CasesHeadings
        {
            get
            {
                log.Info("Getting Cases headings");
                return driver.FindElements(By.ClassName("cases__heading")).ToList().ConvertAll(x=> { return x.Text; });
            }
        }



        public NewsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
