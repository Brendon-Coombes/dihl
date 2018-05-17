using System;

namespace DIHL.Domain.Models
{
    public struct GamePlayed : ICompositeModel
    {
        public GamePlayed(Guid playerId, Guid gameId, Guid teamId, DateTime createdOn)
        {
            PlayerId = playerId;
            GameId = gameId;
            TeamId = teamId;
            CreatedOn = createdOn;
        }

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
        /// The game created on date
        /// </summary>
        public DateTime CreatedOn { get; set; }


        public bool Validate()
        {
            return true;
        }
    }
}
