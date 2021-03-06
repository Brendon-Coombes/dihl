﻿using DIHL.Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Data.Dataloader.Models;
using DIHL.Domain.Enums;
using DIHL.Domain.Models;
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
            Console.WriteLine("Retrieving Leagues...");
            var leagues = await _leagueService.List();
            var league = leagues.First(s => s.Name == "DIHL");

            Console.WriteLine("Retrieving Seaons...");
            var seasons = await _seasonService.List();
            var season = seasons.First(s => s.LeagueId == league.Id && s.Year == 2018);

            Console.WriteLine("Retrieving Teams...");
            var teams = await _teamService.List();
            var homeTeam = teams.First(s => s.Name == gameInfo.HomeTeam && s.LeagueId == league.Id);
            var awayTeam = teams.First(s => s.Name == gameInfo.AwayTeam && s.LeagueId == league.Id);

            Console.WriteLine("Saving Game...");
            var game = await SaveGame(gameInfo, awayTeam, homeTeam, season);

            Console.WriteLine("Saving Games Played...");
            await SaveGamesPlayed(gameInfo.AwayRoster, awayTeam.Id, game.Id);
            await SaveGamesPlayed(gameInfo.HomeRoster, homeTeam.Id, game.Id);

            Console.WriteLine("Saving Penalties...");
            await SavePenalties(gameInfo.GamePenalties, teams, game.Id);

            Console.WriteLine("Saving Goals...");
            await SaveGoals(gameInfo.GameGoals, teams, game.Id);

            Console.WriteLine("Saving Goalie Statistics...");
            await SaveGoalieStatistics(gameInfo.HomeGoalieStats, game.Id, homeTeam.Id);
            await SaveGoalieStatistics(gameInfo.AwayGoalieStats, game.Id, awayTeam.Id);
        }

        private async Task<GameDTO> SaveGame(GamePageInformation gameInfo, TeamDTO awayTeam, TeamDTO homeTeam, SeasonDTO season)
        {
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

            return await _gameService.Upsert(gameDto);
        }

        private async Task SaveGamesPlayed(IList<string> players, Guid teamId, Guid gameId)
        {
            foreach (var player in players)
            {
                var playerDto = await GetOrCreatePlayer(player);
                await _gamePlayedService.Upsert(new GamePlayedDTO
                {
                    CreatedOnUtc = DateTime.Now,
                    GameId = gameId,
                    TeamId = teamId,
                    PlayerId = playerDto.Id
                });
            }
        }        

        private async Task SavePenalties(IList<GamePagePenalty> penalties, IList<TeamDTO> teams, Guid gameId)
        {
            foreach (var penalty in penalties)
            {
                PlayerDTO player = null;
                if (!string.IsNullOrEmpty(penalty.Player))
                {
                    player = await GetOrCreatePlayer(penalty.Player);
                }
                var team = teams.First(t => t.ShortCode.ToUpper() == penalty.TeamShortCode.ToUpper());

                string penaltyType = penalty.PenaltyType;

                if (!string.IsNullOrWhiteSpace(penalty.PenaltyType))
                {
                    int charLocation = penalty.PenaltyType.IndexOf("(", StringComparison.Ordinal);

                    if (charLocation > 0)
                    {
                        penaltyType = penalty.PenaltyType.Substring(0, charLocation).Trim();
                    }
                }

                await _penaltyService.Upsert(new PenaltyDTO
                {
                    GameId = gameId,
                    Length = penalty.Length,
                    Time = penalty.Time ?? TimeSpan.FromSeconds(0),
                    Period = penalty.Period,
                    PowerPlaySuccessful = false,
                    PlayerId = player?.Id,
                    TeamId = team.Id,
                    PenaltyType = GetPenaltyType(penaltyType),
                    CreatedOn = DateTime.Now
                });
            }            
        }

        private int GetPenaltyType(string penaltyType)
        {
            //TODO Change Penalty Type to int and do it on DTO too, create DB look up table of penalty types.
            Dictionary<string, int> penalties = new Dictionary<string, int>()
            {
                {"2nd fight same stoppage",70},
                {"2nd misconduct",71},
                {"3rd fight of the game",37},
                {"Aggressor",38},
                {"Attempt to injured",10},
                {"Bench",16},
                {"Boarding",17},
                {"Body checking",6},
                {"Butt ending",14},
                {"Charging",2},
                {"Check to the head",19},
                {"Clipping",44},
                {"Closing hand on the puck",72},
                {"Continuing altercation",73},
                {"Cross checking",18},
                {"Delay of game",21},
                {"Diving",47},
                {"Elbowing",5},
                {"Face-off violation",10},
                {"Fight after the end of the period",11},
                {"Fight after the original altercation",74},
                {"Fighting",1},
                {"Game ejection",22},
                {"Game misconduct",69},
                {"Goalie interference",23},
                {"Goalie leaving the crease",50},
                {"Gross misconduct",51},
                {"Harassment of official",52},
                {"Head butt",10},
                {"Head Contact",14},
                {"High sticking",8},
                {"Hitting from behind",24},
                {"Holding",4},
                {"Holding the stick",25},
                {"Hooking",7},
                {"Illegal equipment",56},
                {"Instigator",26},
                {"Interference",3},
                {"Interference from the bench",10},
                {"Kicking - match penalty",76},
                {"Kneeing",27},
                {"Leaving the penalty box",60},
                {"Leaving the players bench",61},
                {"Match penalty",62},
                {"Misconduct",28},
                {"Not leaving the area of a fight",11},
                {"Obstruction",13},
                {"enalty shot awarded",77},
                {"Playing with a broken stick",78},
                {"Roughing",29},
                {"Roughing after whistle",30},
                {"Slap shot",13},
                {"Slashing",31},
                {"Spearing",32},
                {"Stage Fight",11},
                {"Taking helmet off",10},
                {"Third man in a fight",66},
                {"Throwing stick",79},
                {"Too many men",33},
                {"Tripping",34},
                {"Unsportsmanlike conduct",35}
            };

            int type = 0;

            if (!string.IsNullOrWhiteSpace(penaltyType))
            {
                int charLocation = penaltyType.IndexOf("(", StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    string formattedType = penaltyType.Substring(0, charLocation).Trim();
                    type = penalties[formattedType];
                }
                else
                {
                    type = penalties[penaltyType];
                }
            }

            return type;
        }

        private async Task SaveGoals(IList<GamePagePoint> points, IList<TeamDTO> teams, Guid gameId)
        {
            foreach (var point in points)
            {
                var team = teams.First(t => t.ShortCode.ToUpper() == point.TeamShortCode.ToUpper());

                GameSkaterStatisticDTO statistic = new GameSkaterStatisticDTO
                {
                    GameId = gameId,
                    Period = point.Period,
                    ScoreType = ScoreType.EvenStrength,
                    TeamId = team.Id,
                    Time = point.Time ?? TimeSpan.FromSeconds(0),
                    CreatedOnUtc = DateTime.Now
                };

                await ParsePointPlayerString(point.PointScorers, statistic);

                await _gameSkaterStatisticService.Upsert(statistic);
            }
        }

        private async Task SaveGoalieStatistics(IList<GamePageGoalieStats> goalieStatistics, Guid gameId, Guid teamId)
        {
            foreach (var statistic in goalieStatistics)
            {
                var player = await GetOrCreatePlayer(statistic.GoalieName);

                GameGoalieStatisticDTO goalieStatistic = new GameGoalieStatisticDTO
                {
                    GameId = gameId,
                    GoalsAllowed = statistic.GoalsAgainst,
                    ShotsAgainst = statistic.ShotsAgainst,
                    Saves = statistic.Saves,
                    PlayerId = player.Id,
                    TeamId = teamId,
                    Result = GetGoalieResult(statistic),
                    CreatedOnUtc = DateTime.Now
                };

                await _gameGoalieStatisticService.Upsert(goalieStatistic);
            }
        }

        private async Task ParsePointPlayerString(string pointScorers, GameSkaterStatisticDTO statistic)
        {
            PlayerDTO primaryAssist = null;
            PlayerDTO secondaryAssist = null;

            var goalScorerAssistsSplit = pointScorers.Split("\r\n");
            var scorer = goalScorerAssistsSplit[0];

            var pointStart = scorer.IndexOf("(");
            var pointEnd = scorer.IndexOf(")");
            var charsToRemove = (pointEnd + 1) - pointStart;

            var goalScorer = await GetOrCreatePlayer(scorer.Remove(pointStart, charsToRemove).Trim());

            if (goalScorerAssistsSplit.Length > 1)
            {
                //Get assist players.
                var assists = goalScorerAssistsSplit[1].Replace("Asst :", string.Empty);

                //Check if there is a secondary assist
                if (assists.Contains("/"))
                {
                    var splitAssists = assists.Split("/");
                    primaryAssist = await GetOrCreatePlayer(splitAssists[0].Remove(splitAssists[0].IndexOf("("), 3).Trim());
                    secondaryAssist = await GetOrCreatePlayer(splitAssists[1].Remove(splitAssists[1].IndexOf("("), 3).Trim());
                }
                else
                {
                    primaryAssist = await GetOrCreatePlayer(assists.Remove(assists.IndexOf("("), 3).Trim());
                }
            }

            //Update the stats with the player information
            statistic.PlayerId = goalScorer.Id;
            statistic.PrimaryAssistPlayerId = primaryAssist?.Id;
            statistic.SecondaryAssistPlayerId = secondaryAssist?.Id;
        }

        private int GetGoalieResult(GamePageGoalieStats gamePageGoalieStat)
        {
            int result = 0;

            if (gamePageGoalieStat.Win == 1)
                result = 1;

            if (gamePageGoalieStat.Loss == 1)
                result = 2;

            if (gamePageGoalieStat.Tie == 1)
                result = 3;

            if (gamePageGoalieStat.SOW == 1)
                result = 4;

            if (gamePageGoalieStat.SOL == 1)
                result = 5;

            return result;
        }

        private async Task<PlayerDTO> GetOrCreatePlayer(string playerString)
        {
            var names = playerString.Split(",");

            string firstName = names[1].Trim();
            string lastName = names[0].Trim();

            var players = await _playerService.List();

            var existingPlayer = players.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (existingPlayer == null)
            {
                existingPlayer = new PlayerDTO
                {
                    FirstName = firstName,
                    LastName = lastName,
                    CreatedOn = DateTime.Now
                };

                existingPlayer = await _playerService.Upsert(existingPlayer);
            }

            return existingPlayer;
        }

    }
}
