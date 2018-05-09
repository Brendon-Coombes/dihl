using System;
using System.Collections.Generic;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class GamePlayedDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the player
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The unique identifier for the team
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// The unique identifier for the game
        /// </summary>
        public Guid GameId { get; set; }
      
        /// <summary>
        /// The gameplayed created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
        
        /// <summary>
        /// The player
        /// </summary>
        public PlayerDataModel Player { get; set; }

        /// <summary>
        /// The team
        /// </summary>
        public TeamDataModel Team { get; set; }

        /// <summary>
        /// The game
        /// </summary>
        public GameDataModel Game { get; set; }
    }
}
