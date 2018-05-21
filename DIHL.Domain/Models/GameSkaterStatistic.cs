using System;
using DIHL.Domain.Enums;

namespace DIHL.Domain.Models
{
    public class GameSkaterStatistic : ISimpleModel
    {
        public GameSkaterStatistic(Guid id, Guid gameId, Guid playerId, Guid teamId, int scoreType, Guid? primaryAssistPlayerId, Guid? secondaryAssistPlayerId, int period, TimeSpan time, DateTime createdOn)
        {
            Id = id;
            GameId = gameId;
            PlayerId = playerId;
            TeamId = teamId;
            ScoreType = (ScoreType)scoreType;
            PrimaryAssistPlayerId = primaryAssistPlayerId;
            SecondaryAssistPlayerId = secondaryAssistPlayerId;
            Period = period;
            Time = time;
            CreatedOn = createdOn;
        }

        /// <summary>
        /// The unique identifier for this game skater statistic
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The game Id
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The team Id
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// The player Id
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The score type (Even Strength, Power Play, Short Handed, Empty Net, Penalty Shot)
        /// </summary>
        public ScoreType ScoreType { get; set; }

        /// <summary>
        /// The primary assist player id
        /// </summary>
        public Guid? PrimaryAssistPlayerId { get; set; }

        /// <summary>
        /// The secondary assist player id
        /// </summary>
        public Guid? SecondaryAssistPlayerId { get; set; }

        /// <summary>
        /// The period this score happened in
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// The time of the game
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// The game goalie statistic created on date
        /// </summary>
        public DateTime CreatedOn { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
