using System;

namespace DIHL.Repository.Sql.Models
{
    public class SkaterShootoutStatisticDataModel : IDataModel
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
        /// The shot number for this team
        /// </summary>
        public int ShotNumber { get; set; }

        /// <summary>
        /// Whether or not the shot was successful
        /// </summary>
        public bool Successful { get; set; }
    }
}
