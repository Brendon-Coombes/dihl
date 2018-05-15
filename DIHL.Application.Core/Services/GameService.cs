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
    public class GameService : ServiceBase, IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly GameFactory _gameFactory;
        private readonly GameDTOMapper _gameMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<GameService>();


        public GameService(IActionHandler handler, IGameRepository gameRepository, GameDTOMapper gameMapper, GameFactory gameFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _gameRepository = gameRepository;
            _gameFactory = gameFactory;
            _gameMapper = gameMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of games.
        /// </summary>
        /// <returns>List of games</returns>
        public async Task<IList<GameDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<Game> games = await _gameRepository.List();
                var gameList = games.Select(d => _gameMapper.ToDto(d)).ToList();

                return gameList;
            });

            return result;
        }

        public async Task<GameDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _gameRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("Game", id);
                }

                return _gameMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<GameDTO> Create(GameDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Game game = _gameFactory.CreateDomainObject(dto);
                game.Validate();

                game = await _gameRepository.Create(game);
                return _gameMapper.ToDto(game);
            });

            return result;
        }

        public async Task<GameDTO> Update(GameDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Game game = _gameFactory.CreateDomainObject(dto);
                game.Validate();

                game = await _gameRepository.Update(game);
                return _gameMapper.ToDto(game);
            });

            return result;
        }

        public async Task<GameDTO> Upsert(GameDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Game game = _gameFactory.CreateDomainObject(dto);
                game.Validate();

                game = await _gameRepository.Upsert(game);
                return _gameMapper.ToDto(game);
            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _gameRepository.Delete(id));
        }
    }
}
