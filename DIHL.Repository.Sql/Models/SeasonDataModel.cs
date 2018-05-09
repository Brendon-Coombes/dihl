using System;
using System.Collections.Generic;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class SeasonDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the season
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The season name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The id of the league this season is for
        /// </summary>
        public Guid LeagueId { get; set; }

        /// <summary>
        /// The year this season occurred.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The season created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        public LeagueDataModel League { get; set; }

        public List<GameDataModel> Games { get; set; }
    }
}
