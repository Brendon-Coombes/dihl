using System;
using System.Collections.Generic;

namespace DIHL.DTOs
{
    public class GameShootoutStatisticDTO
    {
        /// <summary>
        /// The unique identifier for this game shootout statistic
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The game Id
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The date and time this record was created
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// The goalie statistics related to this shootout
        /// </summary>
        public IList<GoalieShootoutStatisticDTO> GoalieStatistics { get; set; }

        /// <summary>
        /// The skater statistics related to this shootout
        /// </summary>
        public IList<SkaterShootoutStatisticDTO> SkaterStatistics { get; set; }
    }
}
