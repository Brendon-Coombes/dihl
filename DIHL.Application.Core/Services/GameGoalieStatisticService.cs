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
    public class GameGoalieStatisticService : ServiceBase, IGameGoalieStatisticService
    {
        private readonly IGameGoalieStatisticRepository _gameGoalieStatisticRepository;
        private readonly GameGoalieStatisticFactory _gameGoalieStatisticFactory;
        private readonly GameGoalieStatisticDTOMapper _gameGoalieStatisticMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<GameGoalieStatisticService>();


        public GameGoalieStatisticService(IActionHandler handler, IGameGoalieStatisticRepository gameGoalieStatisticRepository, GameGoalieStatisticDTOMapper gameGoalieStatisticMapper, GameGoalieStatisticFactory gameGoalieStatisticFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _gameGoalieStatisticRepository = gameGoalieStatisticRepository;
            _gameGoalieStatisticFactory = gameGoalieStatisticFactory;
            _gameGoalieStatisticMapper = gameGoalieStatisticMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of gameGoalieStatistics.
        /// </summary>
        /// <returns>List of gameGoalieStatistics</returns>
        public async Task<IList<GameGoalieStatisticDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<GameGoalieStatistic> gameGoalieStatistics = await _gameGoalieStatisticRepository.List();
                var gameGoalieStatisticList = gameGoalieStatistics.Select(d => _gameGoalieStatisticMapper.ToDto(d)).ToList();

                return gameGoalieStatisticList;
            });

            return result;
        }

        public async Task<GameGoalieStatisticDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _gameGoalieStatisticRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("GameGoalieStatistic", id);
                }

                return _gameGoalieStatisticMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<GameGoalieStatisticDTO> Create(GameGoalieStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameGoalieStatistic gameGoalieStatistic = _gameGoalieStatisticFactory.CreateDomainObject(dto);
                gameGoalieStatistic.Validate();

                gameGoalieStatistic = await _gameGoalieStatisticRepository.Create(gameGoalieStatistic);
                return _gameGoalieStatisticMapper.ToDto(gameGoalieStatistic);
            });

            return result;
        }

        public async Task<GameGoalieStatisticDTO> Update(GameGoalieStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameGoalieStatistic gameGoalieStatistic = _gameGoalieStatisticFactory.CreateDomainObject(dto);
                gameGoalieStatistic.Validate();

                gameGoalieStatistic = await _gameGoalieStatisticRepository.Update(gameGoalieStatistic);
                return _gameGoalieStatisticMapper.ToDto(gameGoalieStatistic);
            });

            return result;
        }

        public async Task<GameGoalieStatisticDTO> Upsert(GameGoalieStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameGoalieStatistic gameGoalieStatistic = _gameGoalieStatisticFactory.CreateDomainObject(dto);
                gameGoalieStatistic.Validate();

                gameGoalieStatistic = await _gameGoalieStatisticRepository.Upsert(gameGoalieStatistic);
                return _gameGoalieStatisticMapper.ToDto(gameGoalieStatistic);
            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _gameGoalieStatisticRepository.Delete(id));
        }
    }
}
