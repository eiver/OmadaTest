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
    class SearchResult
    {
        IWebDriver driver;
        IWebElement webElement;
        private readonly ILog log = Log4netHelper.GetLogger();

        public IWebElement Link
        {
            get
            {
                return webElement.FindElements(By.XPath("./a")).Single();
            }
        }

        public string Title
        {
            get
            {
                return Link.Text;
            }
        }

        public GartnerIAMSummit2016LondonPage ClickLink()
        {
            log.Info("Clicking search result link");
            Link.Click();
            return new GartnerIAMSummit2016LondonPage(driver);
        }

        public SearchResult(IWebDriver driver, IWebElement webElement)
        {
            this.driver = driver;
            this.webElement = webElement;
        }
    }

    class SearchResultsPage
    {
        IWebDriver driver;
        private readonly ILog log = Log4netHelper.GetLogger();

        public List<SearchResult> SearchResults
        {
            get
            {
                log.Info("Getting search results");
                return driver.FindElements(By.ClassName("search-results__item")).ToList().ConvertAll(x => new SearchResult(driver, x));
            }
        }

        public SearchResult GartnerIAMSummit2016London
        {
            get
            {
                log.Info("Getting Gartner IAM Summit 2016 - London search result");
                return SearchResults.Single(x => x.Title.EndsWith("Gartner IAM Summit 2016 - London"));
            }
        }

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
