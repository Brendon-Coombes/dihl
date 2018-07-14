using System;
using System.Collections.Generic;
using System.Linq;
using DIHL.Data.Dataloader.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DIHL.Data.Dataloader.Page
{
    /// <summary>
    /// Responsible for carrying out functionality related to the ScheduleAndScoresPage
    /// </summary>
    public class ScheduleAndScoresPage
    {
        private readonly IWebDriver _webDriver;
        private const int AllMonthsOption = 0;
        private readonly Season _season;

        private const string _monthElementId = "maincontent_ddlMonth";


        /// <summary>
        /// Creates a new instance of <see cref="ScheduleAndScoresPage"/>
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="season"></param>
        public ScheduleAndScoresPage(IWebDriver webDriver, Season season)
        {
            _webDriver = webDriver;
            _season = season;
        }

        public void Navigate()
        {
            Console.WriteLine("Navigating to Schedules and Scores Page...");
            //Load the url and wait for it to load, ensure we are looking at the correct season
            _webDriver.Url = "https://www.mystatsonline.com/hockey/visitor/league/schedule_scores/schedule.aspx?IDLeague=7155";            
            var monthElement =_webDriver.WaitUntilElementClickable(By.Id(_monthElementId));
            monthElement = EnsureSeason(monthElement);

            SelectElement monthDropDown = new SelectElement(monthElement);

            //Change the select drop down to all time.
            monthDropDown.SelectByValue(AllMonthsOption.ToString());

            //Wait for the page to reload
            _webDriver.WaitUntilElementClickable(By.Id("maincontent_gvGameList"));
            Console.WriteLine("Schedules and Scores Page Loaded");
        }

        private IWebElement EnsureSeason(IWebElement currentMonthElement)
        {
            var seasonElement = _webDriver.WaitUntilElementClickable(By.Id("maintitle_ddlSeason"));
            SelectElement seasonDropdown = new SelectElement(seasonElement);

            var selectedOption = seasonDropdown.SelectedOption;
            if (selectedOption != null)
            {
                var value = selectedOption.GetAttribute("value");
                if (!string.IsNullOrEmpty(value))
                {
                    int parsedValue = int.Parse(value);
                    if (parsedValue != (int) _season)
                    {
                        seasonDropdown.SelectByValue(((int)_season).ToString());
                        return _webDriver.WaitUntilElementClickable(By.Id(_monthElementId));
                    }
                    return currentMonthElement;
                }

                throw new ArgumentException("No value could be found on the element");
            }

            //No Selected option could be found, so select the season we intend to use.
            seasonDropdown.SelectByValue(((int)_season).ToString());
            return _webDriver.WaitUntilElementClickable(By.Id(_monthElementId));
        }

        public IList<string> GetGameIds()
        {
            var linkAttributes = _webDriver.FindElements(By.CssSelector("#maincontent_gvGameList tbody tr td span a"));
            var linkContent = linkAttributes.Select(link => link.GetAttribute("href"));
            List<string> gameIds = new List<string>();
            foreach (var content in linkContent)
            {
                int from = content.IndexOf("(") + "(".Length;
                int to = content.LastIndexOf(")");

                string gameId = content.Substring(from, to - from);
                gameIds.Add(gameId);
            }

            return gameIds;
        }
    }
}    
