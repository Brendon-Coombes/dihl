using System;

namespace DIHL.Domain.Models
{
    public class Player : ISimpleModel
    {

        public Player(Guid id, string firstName, string lastName, DateTime createdOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CreatedOn = createdOn;
        }

        /// <summary>
        /// The unique identifier for this player
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The first name name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name name
        /// </summary>
        public string LastName { get; set; }

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
