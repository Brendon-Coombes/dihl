using System;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents a team data set
    /// </summary>
    public class TeamDTO
    {
        /// <summary>
        /// The unique identifier for this team data
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The team name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The team's league Id
        /// </summary>
        public Guid LeagueId { get; set; }

        /// <summary>
        /// Date UTC date when this record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
