using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Constants
{
    public static class MainPageSelectors
    {
        public const string TicketsFromDateCSS = ".j-date_from";
        public const string TicketsToDateCSS = ".j-date_back";
        public const string TicketsCityFromCSS = ".j-city_from";
        public const string TicketsCityToCSS = ".j-city_to";
        public const string TicketsSubmitButton = ".j-submit_button";

        public const string LeaveOptionCSS = ".j-add_review_text";
        public const string LeaveCommentCSS = ".j-comment";
        public const string LeaveButtonCSS = ".j-button";
        public const string LeaveButtonElementCSS = ".name";
        public const string LeaveButtonText = "Отправить";

        public const string OrderingRulesTicketTag = "a";
        public const string OrderingRulesText = "Правила заказа авиабилетов";

        public const string AirportTag = "a";
        public const string AirportText = "Аэропорты";

    }
}
