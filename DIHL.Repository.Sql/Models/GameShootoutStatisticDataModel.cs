using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class GameShootoutStatisticDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for this game shootout statistic
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The game Id
        /// </summary>
        public Guid GameId { get; set; }       
    }
}
