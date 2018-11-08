using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Helpers
{
    class ScreenshotHelper
    {
        ITakesScreenshot screenshotTaker;
        int screenshotNumber = 0;
        public ScreenshotHelper(ITakesScreenshot screenshotTaker)
        {
            this.screenshotTaker = screenshotTaker;
        }

        public void SaveScreenshot(string name)
        {
            string fileName = $"{TestContext.CurrentContext.Test.FullName} - {screenshotNumber.ToString("D4")} {name}.jpeg";
            screenshotTaker?.GetScreenshot().SaveAsFile(Path.Combine(TestContext.CurrentContext.WorkDirectory, fileName), ScreenshotImageFormat.Jpeg);
            screenshotNumber++;
        }
    }
}
