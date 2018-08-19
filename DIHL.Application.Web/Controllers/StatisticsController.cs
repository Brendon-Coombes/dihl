using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DIHL.Application.Web.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<PlayerStatistic> PlayerStatistics(int minimumGamesPlayed)
        {
            //TODO: Add actual services, and figure out how to paginate it.
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new PlayerStatistic
            {
                Id = Guid.NewGuid().ToString(),
                Goals = rng.Next(0, 10),
                Assists = rng.Next(0, 10),
                Points = rng.Next(0, 20),
                GamesPlayed = rng.Next(10, 25),
                PointsPerGame = 1,
                PenaltyMinutes = 5
            });
        }

        public class PlayerStatistic
        {
            public string Id { get; set; }
            public int Goals { get; set; }
            public int Assists { get; set; }
            public int Points { get; set; }
            public int GamesPlayed { get; set; }
            public int PointsPerGame { get; set; }
            public int PenaltyMinutes { get; set; }
        }
    }
}
