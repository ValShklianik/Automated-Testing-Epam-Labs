using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Driver;

namespace Selenium.Test.Pages
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = DriverInstance.Get();
            DriverInstance.SetWaitTime(30);
        }

        [TearDown]
        public void Close()
        {
            DriverInstance.Close();
        }
    }
}
