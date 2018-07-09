using System;
using System.Collections.Generic;

namespace DIHL.Domain.Models
{
    public class GameShootoutStatistic : ISimpleModel
    {
        public GameShootoutStatistic(Guid id, Guid gameId, DateTime createdOn)
        {
            Id = id;
            GameId = gameId;
            CreatedOn = createdOn;
        }

        public GameShootoutStatistic(Guid id, Guid gameId, DateTime createdOn, IList<SkaterShootoutStatistic> skaterShootoutStatistics, IList<GoalieShootoutStatistic> goalieShootoutStatistics)
            : this(id, gameId, createdOn)
        {
            SkaterShootoutStatistics = skaterShootoutStatistics;
            GoalieShootoutStatistics = goalieShootoutStatistics;
        }

        /// <summary>
        /// The unique identifier for this game shootout statistic
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The game Id
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The game shootout statistic created on date
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// A list of all the skater statistics for this shootout
        /// </summary>
        public IList<SkaterShootoutStatistic> SkaterShootoutStatistics { get; set; }

        /// <summary>
        /// A list of all the goalie statistics for this shootout
        /// </summary>
        public IList<GoalieShootoutStatistic> GoalieShootoutStatistics { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
