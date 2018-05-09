using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class GameDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the game
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The location of the game
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The date of the game
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The time of the game
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// The Id of the home team
        /// </summary>
        public Guid HomeTeamId { get; set; }

        /// <summary>
        /// The Id of the away team
        /// </summary>
        public Guid AwayTeamId { get; set; }
        
        /// <summary>
        /// Thie Id of the season this game is associated with
        /// </summary>
        public Guid SeasonId { get; set; }

        /// <summary>
        /// The game created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// The player of the playerteam
        /// </summary>
        [ForeignKey("HomeTeamId")]
        public TeamDataModel HomeTeam { get; set; }

        /// <summary>
        /// The team of the player team
        /// </summary>
        [ForeignKey("AwayTeamId")]
        public TeamDataModel AwayTeam { get; set; }

        /// <summary>
        /// The season this game is associated with
        /// </summary>
        public SeasonDataModel Season { get; set; }

        public List<GameSkaterStatisticDataModel> GameSkaterStatistics { get; set; }
        public List<GameGoalieStatisticDataModel> GameGoalieStatistics { get; set; }
        public List<PenaltyDataModel> Penalites { get; set; }
        public List<GamePlayedDataModel> Players { get; set; }
    }
}
