using System;

namespace DIHL.Data.Dataloader.Models
{
    public class GamePagePoint
    {
        public int Period { get; set; }
        public TimeSpan? Time { get; set; }
        public string TeamShortCode { get; set; }
        public string PointScorers { get; set; }
        public string Details { get; set; }
    }
}