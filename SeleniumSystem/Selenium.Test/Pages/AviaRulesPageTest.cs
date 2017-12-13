using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Driver;
using Selenium.Pages;
using System.Linq;
using System.Threading;

namespace Selenium.Test.Pages
{
    [TestFixture]
    public class AviaRulesPageTest : BaseTest
    {

        [Test]
        public void GoToBuyingAirTickets()
        {
            MainPage mainPage = new MainPage(driver);
            ((AviaRulesPage)((MainPage)mainPage.Open()).OrderingAirTicketsRules()).GoToBuyingAirTickets(); ;
            
            Assert.AreEqual(driver.Url, MainPage.URL);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AnswerSurvey(bool isSurveyUseful)
        {
            MainPage mainPage = new MainPage(driver);
            ((AviaRulesPage)((MainPage)mainPage.Open()).OrderingAirTicketsRules()).AnswerSurvey(isSurveyUseful); ;
            Thread.Sleep(1_000); //wait for 1 second

            IWebElement thanksForAnAnswer = driver.FindElement(By.ClassName("publication-voting"));
            Assert.AreEqual(thanksForAnAnswer.Text, "Спасибо за ответ");
        }

        [TestCase(RulesEnum.general)]
        [TestCase(RulesEnum.documents)]
        [TestCase(RulesEnum.contact)]
        [TestCase(RulesEnum.delivery)]
        [TestCase(RulesEnum.exchange)]
        [TestCase(RulesEnum.moneyback)]
        [TestCase(RulesEnum.payment)]
        [TestCase(RulesEnum.process)]
        public void ChooseSection(RulesEnum rules)
        {
            MainPage mainPage = new MainPage(driver);
            ((AviaRulesPage)((MainPage)mainPage.Open()).OrderingAirTicketsRules()).ChooseSection(rules); ;

            Assert.AreEqual(driver.Url, AviaRulesPage.URL + AviaRulesPage.SECTION);
        }
    }
}
