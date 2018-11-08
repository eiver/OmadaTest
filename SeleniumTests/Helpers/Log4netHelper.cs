using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Helpers
{
    class Log4netHelper
    {
        // Create a new file appender
        public static void ConfigureLog4net(string name, string fileName)
        {

            PatternLayout layout = new PatternLayout("%date{yyyy-MM-dd HH:mm:ss,fff} %-5level [%thread]: %message%newline");
            layout.ActivateOptions();

            LevelMatchFilter filter = new LevelMatchFilter();
            filter.LevelToMatch = Level.All;
            filter.ActivateOptions();

            var appender = new FileAppender();
            appender.Name = name;
            appender.File = fileName;
            appender.AppendToFile = false;

            appender.Layout = layout;
            appender.AddFilter(filter);
            appender.ActivateOptions();

            ILoggerRepository repository = LoggerManager.CreateRepository(name);
            BasicConfigurator.Configure(repository, appender);

        }

        public static ILog GetLogger()
        {
            return LogManager.GetLogger(TestContext.CurrentContext.Test.FullName, TestContext.CurrentContext.Test.FullName);
        }
    }
}
