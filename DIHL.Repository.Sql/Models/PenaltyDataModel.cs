using System;
using System.Collections.Generic;
using System.Text;

namespace DIHL.Repository.Sql.Models
{
    public class PenaltyDataModel : IDataModel
    {
        /// <summary>
        /// The unique identifier for the penalty
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Id of the player who took the penalty
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The Id of the team that was penalised
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// The game that this penalty was taken in
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The period that the penalty was taken
        /// </summary>
        public int Period{ get; set; }

        /// <summary>
        /// The time that the penalty was taken
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// The type of penalty that was taken (Tripping, Hooking, Holding, Interferance, Roughing...)
        /// </summary>
        public int PenaltyType { get; set; }

        /// <summary>
        /// The length of the penalty
        /// </summary>
        public TimeSpan Length { get; set; }

        /// <summary>
        /// Whether or not the opposing powerplay was successful
        /// </summary>
        public bool PowerPlaySuccessful { get; set; }

        /// <summary>
        /// The playerteam created on date
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// The player that got the penalty
        /// </summary>
        public PlayerDataModel Player { get; set; }

        /// <summary>
        /// The team that got the penalty
        /// </summary>
        public TeamDataModel Team { get; set; }

        /// <summary>
        /// The game that this penalty was taken in
        /// </summary>
        public GameDataModel Game { get; set; }
    }
}
