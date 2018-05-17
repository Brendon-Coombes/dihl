using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Exceptions;
using DIHL.Application.Core.Interfaces;
using DIHL.Application.Core.Utilities;
using DIHL.DTOs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Application.Core.Telemetry;
using DIHL.Application.Core.Factory;
using DIHL.Application.Core.Mappers;
using DIHL.Domain.Models;

namespace DIHL.Application.Core.Services
{
    /// <summary>
    /// Services in the core application are responsible for bringing multiple processes together.
    /// </summary>
    public class LeagueService : ServiceBase, ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        private readonly LeagueFactory _leagueFactory;
        private readonly LeagueDTOMapper _leagueMapper;
        private readonly ITelemetryEventService _telemetry;

        private readonly ILogger _log = Log.ForContext<LeagueService>();

        public LeagueService(IActionHandler handler, ILeagueRepository leagueRepository, LeagueDTOMapper leagueMapper, LeagueFactory leagueFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _leagueRepository = leagueRepository;
            _leagueMapper = leagueMapper;
            _leagueFactory = leagueFactory;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of leagues.
        /// </summary>
        /// <returns>List of leagues</returns>
        public async Task<IList<LeagueDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                _telemetry.StartListLeaguesTimer();
                IList<League> leagues = await _leagueRepository.List();

                var leagueList = leagues.Select(d => _leagueMapper.ToDto(d)).ToList();
                _telemetry.CompleteListLeaguesTimer(leagueList.Count);

                return leagueList;
            });

            return result;
        }

        /// <summary>
        /// Gets a single record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching league</returns>
        public async Task<LeagueDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _leagueRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("League", id);
                }

                return _leagueMapper.ToDto(repositoryResult);
            });

            return result;
        }

        /// <summary>
        /// Creates the specified league.
        /// </summary>
        /// <param name="leagueDto">The entity.</param>
        /// <returns>The league that was created.</returns>
        public async Task<LeagueDTO> Create(LeagueDTO leagueDto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                League league = _leagueFactory.CreateDomainObject(leagueDto);
                league.Validate();

                league = await _leagueRepository.Create(league);
                return _leagueMapper.ToDto(league);
            });

            return result;
        }

        /// <summary>
        /// Updates the specified league.
        /// </summary>
        /// <param name="leagueDto">The value.</param>
        /// <returns>The league that was updated.</returns>
        public async Task<LeagueDTO> Update(LeagueDTO leagueDto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                League league = _leagueFactory.CreateDomainObject(leagueDto);
                league.Validate();

                league = await _leagueRepository.Update(league);
                return _leagueMapper.ToDto(league);
            });

            return result;
        }

        /// <summary>
        /// Upserts the specified league. If an ID value is not defined a create operation is performed, otherwise an Update is attempted.
        /// </summary>
        /// <param name="leagueDto">The entity.</param>
        /// <returns>The league that was created or updated.</returns>
        public async Task<LeagueDTO> Upsert(LeagueDTO leagueDto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                League league = _leagueFactory.CreateDomainObject(leagueDto);
                league.Validate();

                league = await _leagueRepository.Upsert(league);
                return _leagueMapper.ToDto(league);
            });

            return result;
        }

        /// <summary>
        /// Deletes the record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _leagueRepository.Delete(id));
        }
    }
}
