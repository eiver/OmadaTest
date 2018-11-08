using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Helpers
{
    class ScrollHelper
    {
        IWebDriver driver;
        public ScrollHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ScrollIntoViewCenter(IWebElement webElement)
        {
            string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, webElement);
        }
    }
}
