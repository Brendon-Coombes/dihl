using System;

namespace DIHL.Domain.Models
{
    public class GameGoalieStatistic : ISimpleModel
    {
        public GameGoalieStatistic(Guid id, Guid gameId, Guid playerId, Guid teamId, int shotsAgainst, int goalsAllowed, int saves, int result, DateTime createdOn)
        {
            Id = id;
            GameId = gameId;
            PlayerId = playerId;
            TeamId = teamId;
            ShotsAgainst = shotsAgainst;
            GoalsAllowed = goalsAllowed;
            Saves = saves;
            Result = result;
            CreatedOn = createdOn;
        }

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
        /// The result (Win, Loss, Draw, OTL, OTW, SOL, SOW)
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// The game goalie statistic created on date
        /// </summary>
        public DateTime CreatedOn { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
