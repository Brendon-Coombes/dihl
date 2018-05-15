using System;
using DIHL.Domain.Enums;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents an game data set
    /// </summary>
    public class GameDTO
    {
        /// <summary>
        /// The unique identifier for the game
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The location of the game
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The date of the game
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The time of the game
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// The Id of the home team
        /// </summary>
        public Guid HomeTeamId { get; set; }

        /// <summary>
        /// The Id of the away team
        /// </summary>
        public Guid AwayTeamId { get; set; }

        /// <summary>
        /// Thie Id of the season this game is associated with
        /// </summary>
        public Guid SeasonId { get; set; }

        /// <summary>
        /// The game created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

    }
}
