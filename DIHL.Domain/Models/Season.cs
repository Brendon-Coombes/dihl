using System;
using DIHL.Domain.Enums;

namespace DIHL.Domain.Aggregates
{
    public class Season : IModelRoot
    {

        public Season(Guid id, string name, DateTime createdOn, int year, Guid leagueId)
        {
            Id = id;
            Name = name;
            CreatedOn = createdOn;
            Year = year;
            LeagueId = leagueId;
        }

        /// <summary>
        /// The unique identifier for this season
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The season name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The season year
        /// </summary>
        public int Year{ get; set; }

        /// <summary>
        /// The league id
        /// </summary>
        public Guid LeagueId { get; set; }

        /// <summary>
        /// Date UTC date when this record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
