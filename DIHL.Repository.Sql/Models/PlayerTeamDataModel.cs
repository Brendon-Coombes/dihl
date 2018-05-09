using System;
using System.Collections.Generic;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class PlayerTeamDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the playerteam
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Id of the player of the playerteam
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The Id of the team of the playerteam
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// The Jersey number of the player on this team
        /// </summary>
        public int? JerseyNumber { get; set; }

        /// <summary>
        /// The playerteam created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// The player of the playerteam
        /// </summary>
        public PlayerDataModel Player { get; set; }

        /// <summary>
        /// The team of the player team
        /// </summary>
        public TeamDataModel Team { get; set; }
    }
}
