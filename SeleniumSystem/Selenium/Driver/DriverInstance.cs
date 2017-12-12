using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.Events;
using Selenium.Logging;

namespace Selenium.Driver
{
    public static class DriverInstance
    {
        private static IWebDriver driver;
        private static readonly ILogger logger = new NLogger();

        public static IWebDriver Get()
        {
            if (driver == null)
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();

                    var firingDriver = new EventFiringWebDriver(driver);

                    firingDriver.ElementClicked += (sender, args) =>
                    {
                        logger.Debug(DateTime.Now, "element clicked");
                    };

                    firingDriver.ElementClicking += (sender, args) =>
                    {
                        logger.Debug(DateTime.Now, "element clicking");
                    };

                    firingDriver.FindElementCompleted += (sender, args) =>
                    {
                        logger.Debug(DateTime.Now, "element found");
                    };

                    firingDriver.ExceptionThrown += (sender, args) =>
                    {
                        Exception e = args.ThrownException;
                        logger.Error(DateTime.Now, e?.Message, e?.StackTrace);
                    };

                    driver = firingDriver;
                }
            }

            return driver;
        }

        public static void SetWaitTime(int seconds)
        {
            if (driver != null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
        }

        public static void Close()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
