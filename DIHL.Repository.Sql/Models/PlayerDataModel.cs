using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class PlayerDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the player
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The players first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The players last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The league created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        [InverseProperty("Player")]
        public List<GameSkaterStatisticDataModel> Goals { get; set; }
        [InverseProperty("PrimaryAssist")]
        public List<GameSkaterStatisticDataModel> PrimaryAssists { get; set; }
        [InverseProperty("SecondaryAssist")]
        public List<GameSkaterStatisticDataModel> SecondaryAssists { get; set; }
        public List<GameGoalieStatisticDataModel> GoalieStatistics { get; set; }
        public List<PenaltyDataModel> Penalites { get; set; }
        public List<GameDataModel> GamesPlayed { get; set; }
        public List<PlayerTeamDataModel> TeamsPlayedFor { get; set; }
    }
}
