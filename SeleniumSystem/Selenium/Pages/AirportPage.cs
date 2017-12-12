using OpenQA.Selenium;
using System.Linq;
using System.Threading;
using Selenium.Constants;

namespace Selenium.Pages
{
    public class AirportPage : Page
    {
        public static string URL { get; private set; } = "https://avia.tutu.ru/airport/";
        public static string SEARCH { get; private set; } = "";

        public AirportPage(IWebDriver driver) : base(driver)
        {
        }

        public AirportPage FindByCity(string city)
        {
            IWebElement input = driver.FindElement(By.CssSelector(AirportPageSelectors.InputCitySelector));
            input.SendKeys(city);

            IWebElement findButton = driver.FindElement(By.CssSelector(AirportPageSelectors.ButtonCitySeletor));
            findButton.Click();

            SEARCH = $"?search={city}";
            return this;
        }

        public AirportPage OpenMostPopularRussianAirport()
        {
            //find list
            IWebElement topList = driver
                .FindElements(By.CssSelector(AirportPageSelectors.TopListSelector))
                .First();

            //select first airport in the list
            IWebElement firstItem = topList
                .FindElements(By.CssSelector(AirportPageSelectors.FirstItemSelector))
                .First()
                .FindElement(By.CssSelector(AirportPageSelectors.FirstItemElementSelector));

            firstItem.Click();

            return this;
        }

        public RussianAirportsPage OpenAllRussianAirports()
        {
            //find link "Все 317 аэропортов России"
            IWebElement allRussianAirportLink = driver
                .FindElements(By.TagName(AirportPageSelectors.AllRussianAirportsSelector))
                .Where(el => el.Text == AirportPageSelectors.AllRussianAirportsText)
                .First();

            allRussianAirportLink.Click();

            return new RussianAirportsPage(driver);
        }
    }
}
