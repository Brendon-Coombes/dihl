using System;
using System.Collections.Generic;
using DIHL.Data.Dataloader.Infrastructure;
using DIHL.Data.Dataloader.Models;
using OpenQA.Selenium;

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
            _webDriver.Url = "https://www.mystatsonline.com/hockey/visitor/league/schedule_scores/game_score_hockey.aspx?IDLeague=7155&IDGame=" + _gameId;
            //Wait for the page to reload
            _webDriver.WaitUntilElementVisible(By.Id("divTitle"));
            Console.WriteLine("Loaded");
        }

        public GamePageInformation RetrieveGameDetails()
        {
            GamePageInformation gameInfo = new GamePageInformation();
            PopulateGameInformation(gameInfo);
            PopulateGameGoals(gameInfo);
            PopulateGamePenalties(gameInfo);
            PopulateRosters(gameInfo);
            PopulateGoalieStatistics(gameInfo);

            return gameInfo;
        }

        private void PopulateGameInformation(GamePageInformation gameInfo)
        {
            string headerSelector = "#form1 > div:nth-child(9) > div.mso-section-blue > table > tbody > tr > td:nth-child({0}) > h4";

            string timeString = _webDriver.FindElement(By.CssSelector(string.Format(headerSelector, "1"))).Text;
            string location = _webDriver.FindElement(By.CssSelector(string.Format(headerSelector, "2"))).Text;

            var gameDate = DateTime.ParseExact(timeString, "dddd MMMM d, yyyy - h:mm tt", null);
            gameInfo.Time = gameDate.TimeOfDay;
            gameInfo.Date = gameDate.Date;
            gameInfo.Location = location;

            gameInfo.AwayTeam = _webDriver.FindElement(By.CssSelector("#maincontent_divTeamAway > h4")).Text;
            gameInfo.HomeTeam = _webDriver.FindElement(By.CssSelector("#maincontent_divTeamHome > h4")).Text;

            string awayScore = _webDriver.FindElement(By.CssSelector("#form1 > div:nth-child(9) > div:nth-child(2) > div:nth-child(2) > div > div.col-xs-4.col-sm-5.nopadding.text-right > h2")).Text;
            string homeScore = _webDriver.FindElement(By.CssSelector("#form1 > div:nth-child(9) > div:nth-child(2) > div:nth-child(2) > div > div.col-xs-4.col-sm-5.nopadding.text-left > h2")).Text;

            gameInfo.AwayScore = int.Parse(awayScore);
            gameInfo.HomeScore = int.Parse(homeScore);
        }

        private void PopulateGameGoals(GamePageInformation gameInfo)
        {
            var tableRows =_webDriver.FindElements(By.CssSelector("#maincontent_gvBoxScoreGoals > tbody > tr"));
            int period = 0;

            gameInfo.GameGoals = new List<GamePagePoint>();

            foreach (var row in tableRows)
            {
                var columns = row.FindElements(By.CssSelector("td"));
                if (columns.Count == 1)
                {
                    if (!string.IsNullOrEmpty(columns[0].GetAttribute("style")))
                    {
                        period++;
                    }
                }
                else
                {
                    //Populate info
                    string time = columns[0].Text;
                    string teamShortCode = columns[1].Text;
                    string scorers = columns[2].Text;
                    string details = columns[3].Text.Replace("\r\n", ", ");

                    GamePagePoint point = new GamePagePoint
                    {
                        Period = period,
                        Time = string.IsNullOrEmpty(time) ? (TimeSpan?)null : TimeSpan.Parse(time),
                        TeamShortCode = teamShortCode,
                        PointScorers = scorers,
                        Details = details

                    };
                    gameInfo.GameGoals.Add(point);
                }
            }
        }

        private void PopulateGamePenalties(GamePageInformation gameInfo)
        {
            var tableRows = _webDriver.FindElements(By.CssSelector("#maincontent_gvBoxScorePim > tbody > tr"));
            int period = 0;

            gameInfo.GamePenalties = new List<GamePagePenalty>();

            foreach (var row in tableRows)
            {
                var columns = row.FindElements(By.CssSelector("td"));
                if (columns.Count == 1)
                {
                    if (!string.IsNullOrEmpty(columns[0].GetAttribute("style")))
                    {
                        period++;
                    }
                }
                else
                {
                    //Populate info
                    string time = columns[0].Text;
                    string teamShortCode = columns[1].Text;
                    string player = columns[2].Text;
                    string penaltyType = columns[3].Text;
                    string length = columns[4].Text;

                    GamePagePenalty penalty = new GamePagePenalty
                    {
                        Period = period,
                        Time = string.IsNullOrEmpty(time) ? (TimeSpan?)null : TimeSpan.Parse(time),
                        TeamShortCode = teamShortCode,
                        Player = player,
                        PenaltyType = penaltyType,
                        Length = TimeSpan.Parse(length)
                    };
                    gameInfo.GamePenalties.Add(penalty);
                }
            }
        }

        private void PopulateRosters(GamePageInformation gameInfo)
        {     
            var homePlayers = _webDriver.FindElements(By.CssSelector("#maincontent_gvSkatersHome_gvPlayers_wrapper > div:nth-child(2) > div > div > div.DTFC_LeftWrapper > div.DTFC_LeftBodyWrapper > div > table > tbody > tr"));
            gameInfo.HomeRoster = new List<string>();

            foreach (var player in homePlayers)
            {
                var columns = player.FindElements(By.CssSelector("td"));
                gameInfo.HomeRoster.Add(columns[0].Text);
            }

            var awayPlayers = _webDriver.FindElements(By.CssSelector("#maincontent_gvSkatersVisitor_gvPlayers_wrapper > div:nth-child(2) > div > div > div.DTFC_LeftWrapper > div.DTFC_LeftBodyWrapper > div > table > tbody > tr"));
            gameInfo.AwayRoster = new List<string>();

            foreach (var player in awayPlayers)
            {
                var columns = player.FindElements(By.CssSelector("td"));
                gameInfo.AwayRoster.Add(columns[0].Text);
            }
        }

        public void PopulateGoalieStatistics(GamePageInformation gameInfo)
        {
            var homeGoalies = _webDriver.FindElements(By.CssSelector("#maincontent_gvGoaliesHome_gvPlayers > tbody > tr"));
            gameInfo.HomeGoalieStats = new List<GamePageGoalieStats>();

            foreach (var player in homeGoalies)
            {
                var columns = player.FindElements(By.CssSelector("td"));
                GamePageGoalieStats goalieStats = new GamePageGoalieStats()
                {
                    GoalieName = columns[0].Text,
                    ShotsAgainst = int.Parse(columns[1].Text),
                    GoalsAgainst = int.Parse(columns[2].Text),
                    Saves = int.Parse(columns[3].Text)

                };
                gameInfo.HomeGoalieStats.Add(goalieStats);
                gameInfo.HomeRoster.Add(goalieStats.GoalieName);
            }

            var awayGoalies = _webDriver.FindElements(By.CssSelector("#maincontent_gvGoaliesVisitor_gvPlayers > tbody > tr"));
            gameInfo.AwayGoalieStats = new List<GamePageGoalieStats>();

            foreach (var player in awayGoalies)
            {
                var columns = player.FindElements(By.CssSelector("td"));
                GamePageGoalieStats goalieStats = new GamePageGoalieStats()
                {
                    GoalieName = columns[0].Text,
                    ShotsAgainst = int.Parse(columns[1].Text),
                    GoalsAgainst = int.Parse(columns[2].Text),
                    Saves = int.Parse(columns[3].Text)

                };
                gameInfo.AwayGoalieStats.Add(goalieStats);
                gameInfo.AwayRoster.Add(goalieStats.GoalieName);
            }
        }
    }
}    
