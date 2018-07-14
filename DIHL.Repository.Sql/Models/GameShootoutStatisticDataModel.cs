using System;
using System.Collections.Generic;

namespace DIHL.Repository.Sql.Models
{
    public class GameShootoutStatisticDataModel : IDataModel
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

        public GameDataModel Game { get; set; }
        public List<SkaterShootoutStatisticDataModel> SkaterShootoutStatistics { get; set; }
        public List<GoalieShootoutStatisticDataModel> GoalieShootoutStatistics { get; set; }
    }
}
