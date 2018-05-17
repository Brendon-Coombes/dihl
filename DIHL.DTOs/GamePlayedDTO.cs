using System;

namespace DIHL.Domain.Models
{
    public class GamePlayedDTO
    {
        /// <summary>
        /// The player id
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The game id
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The team id
        /// </summary>
        public Guid TeamId { get; set; }
        
        /// <summary>
        /// The game played created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
