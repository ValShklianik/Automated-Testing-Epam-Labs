using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Driver;
using Selenium.Pages;

namespace Selenium.Test.Pages
{
    [TestFixture]
    public class MainPageTest : BaseTest
    {
        private string clName = "success_title";
        private string leaveOpinion = "Thank you for your work!";

       
        [Test]
        public void OpenMainPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open();

            Assert.AreEqual(driver.Url, MainPage.URL);
        }

        
        [Test]
        public void LeaveOpinion()
        {
            MainPage mainPage = new MainPage(driver);
            ((MainPage)mainPage.Open()).LeaveOpinion(leaveOpinion);
            IWebElement title = driver.FindElement(By.ClassName(clName));

            Assert.IsTrue(title.Displayed);
        }

        [Test]
        public void OrderingAirTicketsRules()
        {
            MainPage mainPage = new MainPage(driver);
            ((MainPage)mainPage.Open()).OrderingAirTicketsRules();

            Assert.AreEqual(driver.Url, AviaRulesPage.URL);
        }

        [Test]
        public void OpenAirports()
        {
            MainPage mainPage = new MainPage(driver);
            ((MainPage)mainPage.Open()).OpenAirports();

            Assert.AreEqual(driver.Url, AirportPage.URL);
        }
    }
}
