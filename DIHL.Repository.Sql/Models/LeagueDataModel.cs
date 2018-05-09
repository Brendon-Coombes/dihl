using System;
using System.Collections.Generic;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class LeagueDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the league
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The league name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The league created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// The tier of this league
        /// </summary>
        public int Tier { get; set; }

        public List<TeamDataModel> Teams { get; set; }
    }
}
