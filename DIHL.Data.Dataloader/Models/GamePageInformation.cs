using System;
using System.Collections.Generic;
using System.Text;

namespace DIHL.Data.Dataloader.Models
{
    public class GamePageInformation
    {
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string Location { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }
        
        public List<GamePagePoint> GameGoals { get; set; }

        public List<GamePagePenalty> GamePenalties { get; set; }

        public List<string> HomeRoster { get; set; }
        public List<string> AwayRoster { get; set; }

        public List<GamePageGoalieStats> HomeGoalieStats { get; set; }
        public List<GamePageGoalieStats> AwayGoalieStats { get; set; }
    }
}
