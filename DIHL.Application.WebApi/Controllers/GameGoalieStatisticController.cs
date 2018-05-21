using DIHL.Application.Core.Interfaces;
using DIHL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIHL.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/GameGoalieStatistic")]
    public class GameGoalieStatisticController : BaseApiController
    {
        private readonly IGameGoalieStatisticService _gameGoalieStatisticService;
        private readonly ILogger _log = Log.ForContext<GameGoalieStatisticController>();

        public GameGoalieStatisticController(IGameGoalieStatisticService gameGoalieStatisticService)
        {
            _gameGoalieStatisticService = gameGoalieStatisticService;
        }

        /// <summary>
        /// Lists all the game records.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<GameGoalieStatisticDTO>), 200)]
        public async Task<IActionResult> List()
        {
            IActionResult result = await Execute(_log, async () => await _gameGoalieStatisticService.List());
            return result;
        }

        /// <summary>
        /// Gets the specified game.
        /// </summary>
        /// <param name="id">The game identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GameGoalieStatisticDTO), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            IActionResult result = await Execute(_log, async () => await _gameGoalieStatisticService.Get(id));
            return result;
        }

        /// <summary>
        /// Upserts an game goalie statistic record.
        /// The game id is generated by the server.
        /// </summary>
        /// <param name="value">The entity data.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GameGoalieStatisticDTO), 200)]
        public async Task<IActionResult> Post([FromBody]GameGoalieStatisticDTO value)
        {
            IActionResult result = await Execute(_log, async () => await _gameGoalieStatisticService.Upsert(value));
            return result;
        }

        /// <summary>
        /// Puts the posted game goalie statistic data at the specific location.
        /// </summary>
        /// <param name="id">The Id to assign to the game goalie statistic.</param>
        /// <param name="value">The game goalie statistic data.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GameGoalieStatisticDTO), 200)]
        public async Task<IActionResult> Put(Guid id, [FromBody]GameGoalieStatisticDTO value)
        {
            if (id != value.Id)
            {
                return this.BadRequest("Posted game goalie statistic Id does not match the request.");
            }
            IActionResult result = await Execute(_log, async () => await _gameGoalieStatisticService.Upsert(value));
            return result;
        }

        /// <summary>
        /// Deletes the specified game goalie statistic.
        /// </summary>
        /// <param name="id">The game identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            IActionResult result = await Execute(_log, async () => await _gameGoalieStatisticService.Delete(id));
            return result;
        }
    }
}