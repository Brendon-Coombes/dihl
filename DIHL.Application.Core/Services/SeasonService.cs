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
    public class SeasonService : ServiceBase, ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly SeasonFactory _seasonFactory;
        private readonly SeasonDTOMapper _seasonMapper;
        private readonly ITelemetryEventService _telemetry;

        private readonly ILogger _log = Log.ForContext<LeagueService>();

        public SeasonService(IActionHandler handler, ISeasonRepository seasonRepository, SeasonDTOMapper seasonMapper, SeasonFactory seasonFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _seasonRepository = seasonRepository;
            _seasonMapper = seasonMapper;
            _seasonFactory = seasonFactory;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of seasons.
        /// </summary>
        /// <returns>List of seasons</returns>
        public async Task<IList<SeasonDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<Season> leagues = await _seasonRepository.List();
                var leagueList = leagues.Select(d => _seasonMapper.ToDto(d)).ToList();

                return leagueList;
            });

            return result;
        }

        /// <summary>
        /// Gets a single record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching season</returns>
        public async Task<SeasonDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _seasonRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("League", id);
                }

                return _seasonMapper.ToDto(repositoryResult);
            });

            return result;
        }

        /// <summary>
        /// Creates the specified season.
        /// </summary>
        /// <param name="seasonDto">The entity.</param>
        /// <returns>The season that was created.</returns>
        public async Task<SeasonDTO> Create(SeasonDTO seasonDto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Season season = _seasonFactory.CreateDomainObject(seasonDto);
                season.Validate();

                season = await _seasonRepository.Create(season);
                return _seasonMapper.ToDto(season);
            });

            return result;
        }

        /// <summary>
        /// Updates the specified season.
        /// </summary>
        /// <param name="seasonDto">The value.</param>
        /// <returns>The season that was updated.</returns>
        public async Task<SeasonDTO> Update(SeasonDTO seasonDto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Season season = _seasonFactory.CreateDomainObject(seasonDto);
                season.Validate();

                season = await _seasonRepository.Update(season);
                return _seasonMapper.ToDto(season);
            });

            return result;
        }

        /// <summary>
        /// Upserts the specified season. If an ID value is not defined a create operation is performed, otherwise an Update is attempted.
        /// </summary>
        /// <param name="seasonDto">The entity.</param>
        /// <returns>The season that was created or updated.</returns>
        public async Task<SeasonDTO> Upsert(SeasonDTO seasonDto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Season season = _seasonFactory.CreateDomainObject(seasonDto);
                season.Validate();

                season = await _seasonRepository.Upsert(season);
                return _seasonMapper.ToDto(season);
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
            return await this.Handler.Execute(_log, async () => await _seasonRepository.Delete(id));
        }
    }
}
