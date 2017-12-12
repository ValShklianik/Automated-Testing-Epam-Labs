using OpenQA.Selenium;
using System.Linq;
using Selenium.Constants;

namespace Selenium.Pages
{
    public class AviaRulesPage : Page
    {
        public static string URL { get; private set; } = "https://avia.tutu.ru/2read/avia_rules/avia_rules/" + SECTION;
        public static string SECTION { get; private set; } = "";

        public AviaRulesPage(IWebDriver driver) : base(driver)
        {
        }

        public AviaRulesPage AnswerSurvey(bool isArticleUseful)
        {
            IWebElement answer = isArticleUseful
                ? driver.FindElement(By.CssSelector(AviaRulesPageSelectors.AnswerPlusSelector))
                : driver.FindElement(By.CssSelector(AviaRulesPageSelectors.AnswerMinusSelector));

            answer.Click();

            return this;
        }

        public MainPage GoToBuyingAirTickets()
        {
            //find link "купить авиабилеты"
            IWebElement buyingTickets = driver
                .FindElements(By.CssSelector(AviaRulesPageSelectors.BuyingTicketsSelector))
                .Where(el => el.Text == AviaRulesPageSelectors.BuyingTicketsText)
                .First();

            buyingTickets.Click();
            
            return new MainPage(driver);
        }

        public AviaRulesPage ChooseSection(RulesEnum rule)
        {
            //find link among presented in RulesEnum
            IWebElement contacts = driver
                .FindElements(By.TagName(AviaRulesPageSelectors.ContactsSelector))
                .Where(el => el.Text == SectionName.Get(rule))
                .First();

            contacts.Click();

            SECTION = $"#{rule}";
            return this;
        }
    }
}
