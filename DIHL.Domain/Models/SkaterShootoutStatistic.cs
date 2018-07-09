using System;

namespace DIHL.Domain.Models
{
    public class SkaterShootoutStatistic : ISimpleModel
    {
        public SkaterShootoutStatistic(Guid id, Guid gameShootoutStatisticId, Guid teamId, Guid? playerId, int shotNumber, bool successful, DateTime createdOn)
        {
            Id = id;
            GameShootoutStatisticId = gameShootoutStatisticId;
            TeamId = teamId;
            PlayerId = playerId;
            ShotNumber = shotNumber;
            Successful = successful;
            CreatedOn = createdOn;
        }

        /// <summary>
        /// The unique identifier for this game skater statistic
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
