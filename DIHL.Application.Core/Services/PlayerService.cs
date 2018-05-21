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
    public class PlayerService : ServiceBase, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerDTOMapper _playerMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<PlayerService>();


        public PlayerService(IActionHandler handler, IPlayerRepository playerRepository, PlayerDTOMapper playerMapper, PlayerFactory playerFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _playerRepository = playerRepository;
            _playerFactory = playerFactory;
            _playerMapper = playerMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of players.
        /// </summary>
        /// <returns>List of players</returns>
        public async Task<IList<PlayerDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<Player> players = await _playerRepository.List();
                var playerList = players.Select(d => _playerMapper.ToDto(d)).ToList();

                return playerList;
            });

            return result;
        }

        public async Task<PlayerDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _playerRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("Player", id);
                }

                return _playerMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<PlayerDTO> Create(PlayerDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Player player = _playerFactory.CreateDomainObject(dto);
                player.Validate();

                player = await _playerRepository.Create(player);
                return _playerMapper.ToDto(player);
            });

            return result;
        }

        public async Task<PlayerDTO> Update(PlayerDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Player player = _playerFactory.CreateDomainObject(dto);
                player.Validate();

                player = await _playerRepository.Update(player);
                return _playerMapper.ToDto(player);
            });

            return result;
        }

        public async Task<PlayerDTO> Upsert(PlayerDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Player player = _playerFactory.CreateDomainObject(dto);
                player.Validate();

                player = await _playerRepository.Upsert(player);
                return _playerMapper.ToDto(player);
            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _playerRepository.Delete(id));
        }
    }
}
