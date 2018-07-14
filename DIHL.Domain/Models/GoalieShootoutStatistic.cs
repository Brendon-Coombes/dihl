using System;

namespace DIHL.Domain.Models
{
    public class GoalieShootoutStatistic : ISimpleModel
    {
        public GoalieShootoutStatistic(Guid id, Guid gameShootoutStatisticId, Guid teamId, Guid? playerId, int shotsAgainst, int goalsAllowed, bool wonShootout, DateTime createdOn)
        {
            Id = id;
            GameShootoutStatisticId = gameShootoutStatisticId;
            TeamId = teamId;
            PlayerId = playerId;
            ShotsAgainst = shotsAgainst;
            GoalsAllowed = goalsAllowed;
            WonShootout = wonShootout;
            CreatedOn = createdOn;
        }

        /// <summary>
        /// The unique identifier for this goalie shootoutstatistic
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
        /// The goalie shootout statistic created on date
        /// </summary>
        public DateTime CreatedOn { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
