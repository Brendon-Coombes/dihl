using DIHL.Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIHL.Data.Dataloader.Models;
using DIHL.DTOs;

namespace DIHL.Data.Dataloader.Facade
{
    public class ServiceFacade : IServiceFacade
    {
        private readonly IGameService _gameService;
        private readonly ITeamService _teamService;
        private readonly IGameGoalieStatisticService _gameGoalieStatisticService;
        private readonly IGameSkaterStatisticService _gameSkaterStatisticService;
        private readonly IGamePlayedService _gamePlayedService;
        private readonly IPlayerService _playerService;
        private readonly IPenaltyService _penaltyService;
        private readonly ISeasonService _seasonService;
        private readonly ILeagueService _leagueService;

        public ServiceFacade(IGameService gameService, ITeamService teamService, IGameGoalieStatisticService gameGoalieStatisticService, IGameSkaterStatisticService gameSkaterStatisticService, IGamePlayedService gamePlayedService, IPlayerService playerService, IPenaltyService penaltyService, ILeagueService leagueService, ISeasonService seasonService)
        {
            _gameService = gameService;
            _teamService = teamService;
            _gameGoalieStatisticService = gameGoalieStatisticService;
            _gameSkaterStatisticService = gameSkaterStatisticService;
            _gamePlayedService = gamePlayedService;
            _playerService = playerService;
            _penaltyService = penaltyService;
            _seasonService = seasonService;
            _leagueService = leagueService;
        }

        public async Task SaveGameInformation(GamePageInformation gameInfo)
        {
            var leagues = await _leagueService.List();

            var league = leagues.First(s => s.Name == "DIHL");

            var seasons = await _seasonService.List();
            var season = seasons.First(s => s.LeagueId == league.Id && s.Year == 2016);

            var teams = await _teamService.List();
            var homeTeam = teams.First(s => s.Name == gameInfo.HomeTeam && s.LeagueId == league.Id);
            var awayTeam = teams.First(s => s.Name == gameInfo.AwayTeam && s.LeagueId == league.Id);

            GameDTO gameDto = new GameDTO()
            {
                AwayTeamId = awayTeam.Id,
                HomeTeamId = homeTeam.Id,
                Date = gameInfo.Date,
                Time = gameInfo.Time,
                Location = gameInfo.Location,
                SeasonId = season.Id,
                CreatedOnUtc = DateTime.Now
            };

            var result = await _gameService.Upsert(gameDto);
        }
    }
}
