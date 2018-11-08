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
    class TakedaCasePage
    {
        private readonly IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public IWebElement Form
        {
            get
            {
                log.Info("Getting contact form iframe");
                return driver.FindElement(By.XPath("//iframe"));
            }
        }

        public void FillForm()
        {
            log.Info("Filling out form");
            driver.SwitchTo().Frame(Form);
            var inputs = driver.FindElements(By.XPath("//input")).ToList();
            var selects = driver.FindElements(By.XPath("//select")).ToList();

            log.Info("Filling out first name");
            inputs[0].SendKeys("FirstName");

            log.Info("Filling out last name");
            inputs[1].SendKeys("LastName");

            log.Info("Filling out Title");
            inputs[2].SendKeys("Title");

            log.Info("Filling out company");
            inputs[3].SendKeys("Company");

            log.Info("Filling out email");
            inputs[4].SendKeys("email@test.com");

            log.Info("Filling out phone");
            inputs[5].SendKeys("123456789");

            log.Info("Clicking on Accept Omada's Privacy Policy");
            inputs[6].Click();

            log.Info("Filling out Employees");
            selects[0].SendKeys("u");

            log.Info("Filling out Level");
            selects[1].SendKeys("0");

            log.Info("Filling out Country");
            selects[2].SendKeys("c");

            log.Info("Scrolling page down");
            Form.SendKeys(Keys.PageDown);
        }
        public TakedaCasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
