using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Exceptions;
using DIHL.Application.Core.Factory;
using DIHL.Application.Core.Interfaces;
using DIHL.Application.Core.Mappers;
using DIHL.Application.Core.Telemetry;
using DIHL.Application.Core.Utilities;
using DIHL.Domain.Models;
using DIHL.DTOs;
using Serilog;

namespace DIHL.Application.Core.Services
{
    /// <summary>
    /// Services in the core application are responsible for bringing multiple processes together.
    /// </summary>
    public class GameShootoutStatisticService : ServiceBase, IGameShootoutStatisticService
    {
        private readonly IGameShootoutStatisticRepository _gameShootoutStatisticRepository;
        private readonly GameShootoutStatisticFactory _gameShootoutStatisticFactory;
        private readonly GameShootoutStatisticDTOMapper _gameShootoutStatisticMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<GameShootoutStatisticService>();


        public GameShootoutStatisticService(IActionHandler handler, IGameShootoutStatisticRepository gameShootoutStatisticRepository, GameShootoutStatisticDTOMapper gameShootoutStatisticMapper, GameShootoutStatisticFactory gameShootoutStatisticFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _gameShootoutStatisticRepository = gameShootoutStatisticRepository;
            _gameShootoutStatisticFactory = gameShootoutStatisticFactory;
            _gameShootoutStatisticMapper = gameShootoutStatisticMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of game shootout statistics.
        /// </summary>
        /// <returns>List of games</returns>
        public async Task<IList<GameShootoutStatisticDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<GameShootoutStatistic> games = await _gameShootoutStatisticRepository.List();
                var gameList = games.Select(d => _gameShootoutStatisticMapper.ToDto(d)).ToList();

                return gameList;
            });

            return result;
        }

        public async Task<GameShootoutStatisticDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _gameShootoutStatisticRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("GameShootoutStatistic", id);
                }

                return _gameShootoutStatisticMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<GameShootoutStatisticDTO> Create(GameShootoutStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameShootoutStatistic gameShootoutStatistic = _gameShootoutStatisticFactory.CreateDomainObject(dto);
                gameShootoutStatistic.Validate();

                gameShootoutStatistic = await _gameShootoutStatisticRepository.Create(gameShootoutStatistic);
                return _gameShootoutStatisticMapper.ToDto(gameShootoutStatistic);
            });

            return result;
        }

        public async Task<GameShootoutStatisticDTO> Update(GameShootoutStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameShootoutStatistic gameShootoutStatistic = _gameShootoutStatisticFactory.CreateDomainObject(dto);
                gameShootoutStatistic.Validate();

                gameShootoutStatistic = await _gameShootoutStatisticRepository.Update(gameShootoutStatistic);
                return _gameShootoutStatisticMapper.ToDto(gameShootoutStatistic);
            });

            return result;
        }

        public async Task<GameShootoutStatisticDTO> Upsert(GameShootoutStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameShootoutStatistic gameShootoutStatistic = _gameShootoutStatisticFactory.CreateDomainObject(dto);
                gameShootoutStatistic.Validate();

                gameShootoutStatistic = await _gameShootoutStatisticRepository.Upsert(gameShootoutStatistic);
                return _gameShootoutStatisticMapper.ToDto(gameShootoutStatistic);
            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _gameShootoutStatisticRepository.Delete(id));
        }
    }
}
