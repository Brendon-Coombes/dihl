using System;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents a player data set
    /// </summary>
    public class PlayerDTO
    {
        /// <summary>
        /// The unique identifier for this player data
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The player's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The player's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Date UTC date when this record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
