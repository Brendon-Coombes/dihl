using System;

namespace DIHL.Repository.Sql.Models
{
    public class GoalieShootoutStatisticDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for this skater shootout statistic
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The game shooutout statistic Id
        /// </summary>
        public Guid GameShootoutStatisticId { get; set; } 

        /// <summary>
        /// The team Id
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// The Player Id
        /// </summary>
        public Guid? PlayerId { get; set; }

        /// <summary>
        /// The number of shots the goalie took in the shootout
        /// </summary>
        public int ShotsAgainst { get; set; }

        /// <summary>
        /// The goals allowed by the goalie in the shootout
        /// </summary>
        public int GoalsAllowed { get; set; }

        /// <summary>
        /// Whether or not the goalie won the shootout
        /// </summary>
        public bool WonShootout { get; set; }

        /// <summary>
        /// The statistic created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        public TeamDataModel Team { get; set; }
        public GameShootoutStatisticDataModel ShootoutStatistic { get; set; }
        public PlayerDataModel Player { get; set; }
    }
}
