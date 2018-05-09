using System;
using DIHL.Domain.Enums;

namespace DIHL.Domain.Aggregates
{
    public class League : IAggregateRoot
    {

        public League(Guid id, string name, DateTime createdOn, int tier)
        {
            Id = id;
            Name = name;
            CreatedOn = createdOn;
            Tier = (Tier)tier;
        }

        /// <summary>
        /// The unique identifier for this League
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


        public bool Validate()
        {
            return true;
        }
    }
}
