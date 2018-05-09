using System;
using System.Diagnostics;
using DIHL.Domain.Enums;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents an league data set
    /// </summary>
    public class LeagueDTO
    {
        /// <summary>
        /// The unique identifier for this league data
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The league name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The league tier
        /// </summary>
        public Tier Tier { get; set; }

        /// <summary>
        /// Date UTC date when this record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }

    }
}
