using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class GameSkaterStatisticDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for this game skater statistic
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The game Id
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The team Id
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// The player Id
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The score type (Even Strength, Power Play, Short Handed, Empty Net, Penalty Shot)
        /// </summary>
        public int ScoreType { get; set; }

        /// <summary>
        /// The primary assist player id
        /// </summary>
        public Guid? PrimaryAssistPlayerId { get; set; }

        /// <summary>
        /// The secondary assist player id
        /// </summary>
        public Guid? SecondaryAssistPlayerId { get; set;  }

        /// <summary>
        /// The period this score happened in
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// The time of the game
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// The game created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }       

        public GameDataModel Game { get; set; }
        public TeamDataModel Team { get; set; }

        [ForeignKey("PlayerId")]
        public PlayerDataModel Player { get; set; }
        [ForeignKey("PrimaryAssistPlayerId")]
        public PlayerDataModel PrimaryAssist { get; set; }
        [ForeignKey("SecondaryAssistPlayerId")]
        public PlayerDataModel SecondaryAssist { get; set; }
    }
}
