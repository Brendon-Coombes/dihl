using System;
using DIHL.Domain.Enums;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents an game data set
    /// </summary>
    public class GameSkaterStatisticDTO
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
        public ScoreType ScoreType { get; set; }

        /// <summary>
        /// The primary assist player id
        /// </summary>
        public Guid? PrimaryAssistPlayerId { get; set; }

        /// <summary>
        /// The secondary assist player id
        /// </summary>
        public Guid? SecondaryAssistPlayerId { get; set; }

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

    }
}
