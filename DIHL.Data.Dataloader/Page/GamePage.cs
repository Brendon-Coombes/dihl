using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DIHL.Data.Dataloader.Infrastructure;
using DIHL.Data.Dataloader.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DIHL.Data.Dataloader.Page
{
    /// <summary>
    /// Responsible for carrying out functionality related to the ScheduleAndScoresPage
    /// </summary>
    public class GamePage
    {
        private readonly IWebDriver _webDriver;
        private readonly string _gameId;

        /// <summary>
        /// Creates a new instance of <see cref="GamePage"/>
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="gameId"></param>
        public GamePage(IWebDriver webDriver, string gameId)
        {
            _webDriver = webDriver;
            _gameId = gameId;
        }

        public void Navigate()
        {
            //Load the url and wait for it to load, ensure we are looking at the correct season
            _webDriver.Url = "https://www.mystatsonline.com/hockey/visitor/league/schedule_scores/schedule.aspx?IDLeague=7155&IDGame=" + _gameId;            
            //Wait for the page to reload
            _webDriver.WaitUntilElementVisible(By.Id("divTitle"));
            Console.WriteLine("Loaded");
        }

        public void SaveGameDetails()
        {
            //Save game
            //Check teams
            //Save scores
            //Save goalie stats
            //Save games played
        }
    }
}    
