using System;
using DIHL.Domain.Aggregates;

namespace DIHL.Domain.Models
{
    public class Team : IModelRoot
    {

        public Team(Guid id, string name, Guid leagueId, DateTime createdOn)
        {
            Id = id;
            Name = name;
            LeagueId = leagueId;
            CreatedOn = createdOn;
        }

        /// <summary>
        /// The unique identifier for this team
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The team name
        /// </summary>
        public string Name { get; set; }

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
