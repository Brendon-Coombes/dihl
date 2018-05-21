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
    public class TeamService : ServiceBase, ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly TeamFactory _teamFactory;
        private readonly TeamDTOMapper _teamMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<TeamService>();


        public TeamService(IActionHandler handler, ITeamRepository teamRepository, TeamDTOMapper teamMapper, TeamFactory teamFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _teamRepository = teamRepository;
            _teamFactory = teamFactory;
            _teamMapper = teamMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of teams.
        /// </summary>
        /// <returns>List of teams</returns>
        public async Task<IList<TeamDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<Team> teams = await _teamRepository.List();
                var teamList = teams.Select(d => _teamMapper.ToDto(d)).ToList();

                return teamList;
            });

            return result;
        }

        public async Task<TeamDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _teamRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("Team", id);
                }

                return _teamMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<TeamDTO> Create(TeamDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Team team = _teamFactory.CreateDomainObject(dto);
                team.Validate();

                team = await _teamRepository.Create(team);
                return _teamMapper.ToDto(team);
            });

            return result;
        }

        public async Task<TeamDTO> Update(TeamDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Team team = _teamFactory.CreateDomainObject(dto);
                team.Validate();

                team = await _teamRepository.Update(team);
                return _teamMapper.ToDto(team);
            });

            return result;
        }

        public async Task<TeamDTO> Upsert(TeamDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Team team = _teamFactory.CreateDomainObject(dto);
                team.Validate();

                team = await _teamRepository.Upsert(team);
                return _teamMapper.ToDto(team);
            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _teamRepository.Delete(id));
        }
    }
}
