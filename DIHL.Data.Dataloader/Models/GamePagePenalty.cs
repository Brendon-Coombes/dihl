using System;

namespace DIHL.Data.Dataloader.Models
{
    public class GamePagePenalty
    {
        public int Period { get; set; }
        public TimeSpan? Time { get; set; }
        public string TeamShortCode { get; set; }
        public string Player { get; set; }
        public string PenaltyType { get; set; }
        public TimeSpan Length { get; set; }
    }
}