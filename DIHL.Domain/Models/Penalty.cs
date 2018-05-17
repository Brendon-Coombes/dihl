using System;
using DIHL.Domain.Enums;

namespace DIHL.Domain.Models
{
    public class Penalty : ISimpleModel
    {

        public Penalty(Guid id, Guid playerId, Guid teamId, Guid gameId, int period, TimeSpan time, int penaltyType, TimeSpan length, bool powerPlaySuccessful, DateTime createdOn)
        {
            Id = id;
            PlayerId = playerId;
            TeamId = teamId;
            GameId = gameId;
            Period = period;
            Time = time;
            PenaltyType = (PenaltyType) penaltyType;
            Length = length;
            PowerPlaySuccessful = powerPlaySuccessful;
            CreatedOn = createdOn;
        }

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
        public PenaltyType PenaltyType { get; set; }

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


        public bool Validate()
        {
            return true;
        }
    }
}
