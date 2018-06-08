using System;
using DIHL.Domain.Enums;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents a penalty data set
    /// </summary>
    public class PenaltyDTO
    {
        /// <summary>
        /// The unique identifier for this team
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
        public int Period { get; set; }

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
        /// Date UTC date when this record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
