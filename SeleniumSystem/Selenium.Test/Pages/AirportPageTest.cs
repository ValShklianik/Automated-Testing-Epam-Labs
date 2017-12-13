using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Driver;
using Selenium.Pages;
using System;
using System.Threading;
using System.Web;

namespace Selenium.Test.Pages
{
    [TestFixture]
    public class AirportPageTest : BaseTest
    {

        [TestCase("Минск")]
        [TestCase("Барселона")]
        [TestCase("Сальто")]
        public void FindByCity(string city)
        {
            MainPage mainPage = new MainPage(driver);
            ((AirportPage)((MainPage)mainPage.Open()).OpenAirports()).FindByCity(city);
            
            //encode because of russian letters
            Assert.IsTrue(string.Compare(driver.Url, 
                $"{AirportPage.URL}?search={HttpUtility.UrlEncode(city)}",
                StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        [Test]
        public void OpenMostPopularRussianAirport()
        {
            MainPage mainPage = new MainPage(driver);
            ((AirportPage)((MainPage)mainPage.Open()).OpenAirports()).OpenMostPopularRussianAirport();

            Assert.AreEqual(driver.Url, MostPopularRussianAirportPage.URL);
        }

        [Test]
        public void OpenAllRussianAirports()
        {
            MainPage mainPage = new MainPage(driver);
            ((AirportPage)((MainPage)mainPage.Open()).OpenAirports()).OpenAllRussianAirports();

            Assert.AreEqual(driver.Url, RussianAirportsPage.URL);
        }
    }
}
