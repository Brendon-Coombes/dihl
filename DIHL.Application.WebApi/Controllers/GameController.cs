using DIHL.Application.Core.Interfaces;
using DIHL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DIHL.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    [Authorize]
    public class GameController : BaseApiController
    {
        private readonly IGameService _gameService;
        private readonly ILogger _log = Log.ForContext<GameController>();

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Lists all the game records.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<GameDTO>), 200)]
        public async Task<IActionResult> List()
        {
            IActionResult result = await Execute(_log, async () => await _gameService.List());
            return result;
        }

        /// <summary>
        /// Gets the specified game.
        /// </summary>
        /// <param name="id">The game identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            IActionResult result = await Execute(_log, async () => await _gameService.Get(id));
            return result;
        }

        /// <summary>
        /// Upserts an game record.
        /// The game id is generated by the server.
        /// </summary>
        /// <param name="value">The entity data.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GameDTO), 200)]
        public async Task<IActionResult> Post([FromBody]GameDTO value)
        {
            IActionResult result = await Execute(_log, async () => await _gameService.Upsert(value));
            return result;
        }

        /// <summary>
        /// Puts the posted game data at the specific location.
        /// </summary>
        /// <param name="id">The Id to assign to the game.</param>
        /// <param name="value">The game data.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        public async Task<IActionResult> Put(Guid id, [FromBody]GameDTO value)
        {
            if (id != value.Id)
            {
                return this.BadRequest("Posted game Id does not match the request.");
            }
            IActionResult result = await Execute(_log, async () => await _gameService.Upsert(value));
            return result;
        }

        /// <summary>
        /// Deletes the specified game.
        /// </summary>
        /// <param name="id">The game identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            IActionResult result = await Execute(_log, async () => await _gameService.Delete(id));
            return result;
        }
    }
}
