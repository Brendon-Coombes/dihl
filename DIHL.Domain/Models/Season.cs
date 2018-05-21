using System;

namespace DIHL.Domain.Models
{
    public class Season : ISimpleModel
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
