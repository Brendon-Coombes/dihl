using System;
using System.Diagnostics;
using DIHL.Domain.Enums;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents a season data set
    /// </summary>
    public class SeasonDTO
    {
        /// <summary>
        /// The unique identifier for this season data
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The season name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The league id
        /// </summary>
        public Guid LeagueId{ get; set; }

        /// <summary>
        /// The season year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Date UTC date when this record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
