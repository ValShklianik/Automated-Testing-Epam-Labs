using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class RussianAirportsPage : Page
    {
        public static string URL { get; } = "https://avia.tutu.ru/airports/rossiya/";

        public RussianAirportsPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
