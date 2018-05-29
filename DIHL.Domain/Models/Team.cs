using System;

namespace DIHL.Domain.Models
{
    public class Team : ISimpleModel
    {

        public Team(Guid id, string name, string shortCode, Guid leagueId, DateTime createdOn)
        {
            Id = id;
            Name = name;
            ShortCode = shortCode;
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
        /// The team short code
        /// </summary>
        public string ShortCode { get; set; }

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
