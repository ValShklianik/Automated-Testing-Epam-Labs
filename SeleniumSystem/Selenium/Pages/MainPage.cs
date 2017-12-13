using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using Selenium.Constants;
using Selenium.Logging;

namespace Selenium.Pages
{
    public class MainPage : Page
    {

        private readonly ILogger _logger = new NLogger();
        public static string URL { get; private set; } = "https://avia.tutu.ru/";

        [FindsBy(How = How.CssSelector, Using = MainPageSelectors.TicketsFromDateCSS)]
        public IWebElement fromDate;
        [FindsBy(How = How.CssSelector, Using = MainPageSelectors.TicketsToDateCSS)]
        public IWebElement toDate;
        [FindsBy(How = How.CssSelector, Using = MainPageSelectors.TicketsCityFromCSS)]
        public IWebElement cityFrom;
        [FindsBy(How = How.CssSelector, Using = MainPageSelectors.TicketsCityToCSS)]
        public IWebElement cityTo;
        [FindsBy(How = How.CssSelector, Using = MainPageSelectors.TicketsSubmitButton)]
        public IWebElement findTickects;

        [FindsBy(How = How.CssSelector, Using = MainPageSelectors.LeaveOptionCSS)]
        public IWebElement leaveOpinion;
        [FindsBy(How = How.CssSelector, Using = MainPageSelectors.LeaveCommentCSS)]
        public IWebElement comment;


        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public Page Open()
        {
            driver.Navigate().GoToUrl(URL);
            return this;
        }

        public FindAirTicketsPage FindAirTickets(string fromDateValue, string toDateValue, string cityFromValue, string cityToVlue)
        {
            fromDate.SendKeys(fromDateValue);

            toDate.SendKeys(toDateValue);

            cityFrom.SendKeys(cityFromValue);

            cityTo.SendKeys(cityToVlue);

            Thread.Sleep(1_000); //wait for 1 second
            findTickects.Click();

            return new FindAirTicketsPage(driver);
        }

        public Page LeaveOpinion(string message)
        {
            _logger.Debug(DateTime.Now, "leave option clicked");
            leaveOpinion.Click();

            comment.SendKeys(message);

            //find button "Отправить"
            IWebElement button = driver
                .FindElements(By.CssSelector(MainPageSelectors.LeaveButtonCSS))
                .Where(el => el.FindElement(By.CssSelector(MainPageSelectors.LeaveButtonElementCSS)).Text == MainPageSelectors.LeaveButtonText)
                .First();

            button.Click();

            return this;
        }

        public Page OrderingAirTicketsRules()
        {
            //find link "Правила заказа авиабилетов"
            IWebElement rules = driver
                .FindElements(By.CssSelector(MainPageSelectors.OrderingRulesTicketTag))
                .Where(el => el.Text == MainPageSelectors.OrderingRulesText)
                .First();

            rules.Click();
            _logger.Debug(DateTime.Now, "ordering air ticket rule clicked");

            return new AviaRulesPage(driver);
        }

        public Page OpenAirports()
        {
            //find link "Аэропорты"
            IWebElement rules = driver
                .FindElements(By.CssSelector(MainPageSelectors.AirportTag))
                .Where(el => el.Text == MainPageSelectors.AirportText)
                .First();

            rules.Click();
            _logger.Debug(DateTime.Now, "open airport clicked");

            return new AirportPage(driver);
        }
    }
}
