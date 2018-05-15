using System;
using DIHL.Domain.Aggregates;
using DIHL.Domain.Enums;

namespace DIHL.Domain.Models
{
    public class Game : IModelRoot
    {
        public Game(Guid id, string location, DateTime date, TimeSpan time, Guid homeTeamId, Guid awayTeamId, Guid seasonId, DateTime createdOn)
        {
            Id = id;
            Location = location;
            Date = date;
            Time = time;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            SeasonId = seasonId;
            CreatedOn = createdOn;
        }

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
        public DateTime CreatedOn { get; set; }


        public bool Validate()
        {
            return true;
        }
    }
}
