using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Game Mapper is responsible for mapping the Game Data model to the Game Domain object and vice versa
    /// </summary>
    public class GameMapper : IDomainDataMapper<Game, GameDataModel>
    {
        public GameDataModel ToDataModel(Game domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new GameDataModel()
            {
                Id = domainModel.Id,
                Location = domainModel.Location,
                Date = domainModel.Date,
                Time = domainModel.Time,
                HomeTeamId = domainModel.HomeTeamId,
                AwayTeamId = domainModel.AwayTeamId,
                SeasonId = domainModel.SeasonId,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public Game ToDomainModel(GameDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new Game(
                dataModel.Id,
                dataModel.Location,
                dataModel.Date,
                dataModel.Time,
                dataModel.HomeTeamId,
                dataModel.AwayTeamId,
                dataModel.SeasonId,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(GameDataModel dataModel, Game domainModel)
        {
            dataModel.Location = domainModel.Location;
            dataModel.Date = domainModel.Date;
            dataModel.Time = domainModel.Time;
            dataModel.HomeTeamId = domainModel.HomeTeamId;
            dataModel.AwayTeamId = domainModel.AwayTeamId;
            dataModel.SeasonId = domainModel.SeasonId;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
