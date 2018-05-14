using System.Security.Cryptography;
using DIHL.Domain.Aggregates;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Penalty Mapper is responsible for mapping the Penalty Data model to the Penalty Domain object and vice versa
    /// </summary>
    public class PenaltyMapper : IDomainDataMapper<Penalty, PenaltyDataModel>
    {
        public PenaltyDataModel ToDataModel(Penalty domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new PenaltyDataModel()
            {
                Id = domainModel.Id,
                PlayerId = domainModel.PlayerId,
                TeamId = domainModel.TeamId,
                GameId = domainModel.GameId,
                PenaltyType = (int)domainModel.PenaltyType,
                Period = domainModel.Period,
                Time = domainModel.Time,
                Length = domainModel.Length,
                PowerPlaySuccessful = domainModel.PowerPlaySuccessful,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public Penalty ToDomainModel(PenaltyDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new Penalty(
                dataModel.Id,
                dataModel.PlayerId,
                dataModel.TeamId,
                dataModel.GameId,
                dataModel.Period,
                dataModel.Time,
                dataModel.PenaltyType,
                dataModel.Length,
                dataModel.PowerPlaySuccessful,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(PenaltyDataModel dataModel, Penalty domainModel)
        {
            dataModel.PlayerId = domainModel.PlayerId;
            dataModel.TeamId = domainModel.TeamId;
            dataModel.GameId = domainModel.GameId;
            dataModel.Period = domainModel.Period;
            dataModel.Time = domainModel.Time;
            dataModel.PenaltyType = (int)domainModel.PenaltyType;
            dataModel.Length = domainModel.Length;
            dataModel.PowerPlaySuccessful = domainModel.PowerPlaySuccessful;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
