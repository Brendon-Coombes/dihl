using System;

namespace DIHL.Repository.Sql.Models
{
    public class GameGoalieStatisticDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the league
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Id of the game
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The Id of the player
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The team the player played for
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// The total shots against the goalie in the game
        /// </summary>
        public int ShotsAgainst { get; set; }

        /// <summary>
        /// The total goals allowed by the goalie in the game
        /// </summary>
        public int GoalsAllowed { get; set; }

        /// <summary>
        /// The total saves made by the goalie in the game
        /// </summary>
        public int Saves { get; set; }

        /// <summary>
        /// The result (Did not start, Win, Loss, Draw, SOL, SOW)
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// The game goalie statistic created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// The game these statistics are for
        /// </summary>
        public GameDataModel Game { get; set; }

        /// <summary>
        /// The player these statistics are for
        /// </summary>
        public PlayerDataModel Player { get; set; }

        /// <summary>
        /// The team that these statistics are for
        /// </summary>
        public TeamDataModel Team { get; set; }
    }
}
