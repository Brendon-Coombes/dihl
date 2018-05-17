using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Factory;
using DIHL.Application.Core.Interfaces;
using DIHL.Application.Core.Mappers;
using DIHL.Application.Core.Telemetry;
using DIHL.Application.Core.Utilities;
using DIHL.Domain.Models;
using Serilog;

namespace DIHL.Application.Core.Services
{
    /// <summary>
    /// Services in the core application are responsible for bringing multiple processes together.
    /// </summary>
    public class GamePlayedService : ServiceBase, IGamePlayedService
    {
        private readonly IGamePlayedRepository _gamePlayedRepository;
        private readonly GamePlayedFactory _gamePlayedFactory;
        private readonly GamePlayedDTOMapper _gamePlayedMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<GamePlayedService>();


        public GamePlayedService(IActionHandler handler, IGamePlayedRepository gamePlayedRepository, GamePlayedDTOMapper gamePlayedMapper, GamePlayedFactory gamePlayedFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _gamePlayedRepository = gamePlayedRepository;
            _gamePlayedFactory = gamePlayedFactory;
            _gamePlayedMapper = gamePlayedMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of gamePlayeds.
        /// </summary>
        /// <returns>List of gamePlayeds</returns>
        public async Task<IList<GamePlayedDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<GamePlayed> gamePlayeds = await _gamePlayedRepository.List();
                var gamePlayedList = gamePlayeds.Select(d => _gamePlayedMapper.ToDto(d)).ToList();

                return gamePlayedList;
            });

            return result;
        }

        public async Task<GamePlayedDTO> Get(Guid playerId, Guid gameId)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _gamePlayedRepository.Get(playerId, gameId);

                return _gamePlayedMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<GamePlayedDTO> Create(GamePlayedDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GamePlayed gamePlayed = _gamePlayedFactory.CreateDomainObject(dto);
                gamePlayed.Validate();

                gamePlayed = await _gamePlayedRepository.Create(gamePlayed);
                return _gamePlayedMapper.ToDto(gamePlayed);
            });

            return result;
        }

        public async Task<GamePlayedDTO> Update(GamePlayedDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GamePlayed gamePlayed = _gamePlayedFactory.CreateDomainObject(dto);
                gamePlayed.Validate();

                gamePlayed = await _gamePlayedRepository.Update(gamePlayed);
                return _gamePlayedMapper.ToDto(gamePlayed);
            });

            return result;
        }

        public async Task<GamePlayedDTO> Upsert(GamePlayedDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                GamePlayed gamePlayed = _gamePlayedFactory.CreateDomainObject(dto);
                gamePlayed.Validate();

                gamePlayed = await _gamePlayedRepository.Upsert(gamePlayed);
                return _gamePlayedMapper.ToDto(gamePlayed);
            });

            return result;
        }

        public async Task<bool> Delete(Guid playerId, Guid gameId)
        {
            return await this.Handler.Execute(_log, async () => await _gamePlayedRepository.Delete(playerId, gameId));
        }

        public async Task<IList<GamePlayedDTO>> GetGamesPlayedForPlayer(Guid playerId)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _gamePlayedRepository.GetGamesPlayedForPlayer(playerId);

                var gamePlayedList = repositoryResult.Select(d => _gamePlayedMapper.ToDto(d)).ToList();

                return gamePlayedList;
            });

            return result;
        }

        public async Task<IList<GamePlayedDTO>> GetGamesPlayedForGame(Guid gameId)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _gamePlayedRepository.GetGamesPlayedForGame(gameId);

                var gamePlayedList = repositoryResult.Select(d => _gamePlayedMapper.ToDto(d)).ToList();
                return gamePlayedList;
            });

            return result;
        }
    }
}
