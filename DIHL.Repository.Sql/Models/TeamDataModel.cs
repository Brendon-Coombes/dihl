using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class TeamDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the team
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The team name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Id of the League this team belongs to
        /// </summary>
        public Guid LeagueId { get; set; }

        /// <summary>
        /// The team created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// The League this team belongs to
        /// </summary>
        public LeagueDataModel League { get; set; }

        public List<PlayerTeamDataModel> Players { get; set; }
        public List<PenaltyDataModel> Penalites { get; set; }
        public List<GameDataModel> HomeGames { get; set; }
        public List<GameDataModel> AwayGames { get; set; }
        public List<GameSkaterStatisticDataModel> SkaterStatistics { get; set; }
        public List<GameGoalieStatisticDataModel> GoalieStatistics { get; set; }
        public List<GamePlayedDataModel> GamesPlayed { get; set; }
        public List<SeasonDataModel> Seasons { get; set; }

    }
}
