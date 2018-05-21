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
    public class GameSkaterStatisticService : ServiceBase, IGameSkaterStatisticService
    {
        private readonly IGameSkaterStatisticRepository _gameSkaterStatisticRepository;
        private readonly GameSkaterStatisticFactory _gameSkaterStatisticFactory;
        private readonly GameSkaterStatisticDTOMapper _gameSkaterStatisticMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<GameSkaterStatisticService>();


        public GameSkaterStatisticService(IActionHandler handler, IGameSkaterStatisticRepository gameSkaterStatisticRepository, GameSkaterStatisticDTOMapper gameSkaterStatisticMapper, GameSkaterStatisticFactory gameSkaterStatisticFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _gameSkaterStatisticRepository = gameSkaterStatisticRepository;
            _gameSkaterStatisticFactory = gameSkaterStatisticFactory;
            _gameSkaterStatisticMapper = gameSkaterStatisticMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of gameSkaterStatistics.
        /// </summary>
        /// <returns>List of gameSkaterStatistics</returns>
        public async Task<IList<GameSkaterStatisticDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<GameSkaterStatistic> gameSkaterStatistics = await _gameSkaterStatisticRepository.List();
                var gameSkaterStatisticList = gameSkaterStatistics.Select(d => _gameSkaterStatisticMapper.ToDto(d)).ToList();

                return gameSkaterStatisticList;
            });

            return result;
        }

        public async Task<GameSkaterStatisticDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _gameSkaterStatisticRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("GameSkaterStatistic", id);
                }

                return _gameSkaterStatisticMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<GameSkaterStatisticDTO> Create(GameSkaterStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameSkaterStatistic gameSkaterStatistic = _gameSkaterStatisticFactory.CreateDomainObject(dto);
                gameSkaterStatistic.Validate();

                gameSkaterStatistic = await _gameSkaterStatisticRepository.Create(gameSkaterStatistic);
                return _gameSkaterStatisticMapper.ToDto(gameSkaterStatistic);
            });

            return result;
        }

        public async Task<GameSkaterStatisticDTO> Update(GameSkaterStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameSkaterStatistic gameSkaterStatistic = _gameSkaterStatisticFactory.CreateDomainObject(dto);
                gameSkaterStatistic.Validate();

                gameSkaterStatistic = await _gameSkaterStatisticRepository.Update(gameSkaterStatistic);
                return _gameSkaterStatisticMapper.ToDto(gameSkaterStatistic);
            });

            return result;
        }

        public async Task<GameSkaterStatisticDTO> Upsert(GameSkaterStatisticDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GameSkaterStatistic gameSkaterStatistic = _gameSkaterStatisticFactory.CreateDomainObject(dto);
                gameSkaterStatistic.Validate();

                gameSkaterStatistic = await _gameSkaterStatisticRepository.Upsert(gameSkaterStatistic);
                return _gameSkaterStatisticMapper.ToDto(gameSkaterStatistic);
            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _gameSkaterStatisticRepository.Delete(id));
        }
    }
}
