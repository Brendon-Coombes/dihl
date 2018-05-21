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
    public class PenaltyService : ServiceBase, IPenaltyService
    {
        private readonly IPenaltyRepository _penaltyRepository;
        private readonly PenaltyFactory _penaltyFactory;
        private readonly PenaltyDTOMapper _penaltyMapper;
        private readonly ITelemetryEventService _telemetry; //TODO Telemetry

        private readonly ILogger _log = Log.ForContext<PenaltyService>();


        public PenaltyService(IActionHandler handler, IPenaltyRepository penaltyRepository, PenaltyDTOMapper penaltyMapper, PenaltyFactory penaltyFactory, ITelemetryEventService telemetry)
            : base(handler)
        {
            _penaltyRepository = penaltyRepository;
            _penaltyFactory = penaltyFactory;
            _penaltyMapper = penaltyMapper;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Gets a list of penalties.
        /// </summary>
        /// <returns>List of penalties</returns>
        public async Task<IList<PenaltyDTO>> List()
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                IList<Penalty> penalties = await _penaltyRepository.List();
                var penaltyList = penalties.Select(d => _penaltyMapper.ToDto(d)).ToList();

                return penaltyList;
            });

            return result;
        }

        public async Task<PenaltyDTO> Get(Guid id)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                var repositoryResult = await _penaltyRepository.Get(id);
                if (repositoryResult == null)
                {
                    throw new RecordNotFoundException("Penalty", id);
                }

                return _penaltyMapper.ToDto(repositoryResult);
            });

            return result;
        }

        public async Task<PenaltyDTO> Create(PenaltyDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Penalty penalty = _penaltyFactory.CreateDomainObject(dto);
                penalty.Validate();

                penalty = await _penaltyRepository.Create(penalty);
                return _penaltyMapper.ToDto(penalty);
            });

            return result;
        }

        public async Task<PenaltyDTO> Update(PenaltyDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Penalty penalty = _penaltyFactory.CreateDomainObject(dto);
                penalty.Validate();

                penalty = await _penaltyRepository.Update(penalty);
                return _penaltyMapper.ToDto(penalty);
            });

            return result;
        }

        public async Task<PenaltyDTO> Upsert(PenaltyDTO dto)
        {
            var result = await this.Handler.Execute(_log, async () =>
            {
                Penalty penalty = _penaltyFactory.CreateDomainObject(dto);
                penalty.Validate();

                penalty = await _penaltyRepository.Upsert(penalty);
                return _penaltyMapper.ToDto(penalty);
            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(_log, async () => await _penaltyRepository.Delete(id));
        }
    }
}
