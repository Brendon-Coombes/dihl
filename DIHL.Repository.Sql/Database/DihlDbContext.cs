using DIHL.Repository.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace DIHL.Repository.Sql.Database
{
    /// <summary>
    /// The Entity Framework Core DIHL Database Content
    /// </summary>
    public class DihlDbContext : DbContext
    {
        /// <summary>
        /// A Db Set of Games in the database
        /// </summary>
        public DbSet<GameDataModel> Games { get; set; }
        public DbSet<GameGoalieStatisticDataModel> GoalieStatistics { get; set; }
        public DbSet<GamePlayedDataModel> GamesPlayed { get; set; }
        public DbSet<GameSkaterStatisticDataModel> SkaterStatistics { get; set; }
        public DbSet<LeagueDataModel> Leagues { get; set; }
        public DbSet<SeasonDataModel> Seasons { get; set; }
        public DbSet<PenaltyDataModel> Penalties { get; set; }
        public DbSet<PlayerDataModel> Players { get; set; }
        public DbSet<PlayerTeamDataModel> PlayerTeams { get; set; }
        public DbSet<TeamDataModel> Teams { get; set; }
        public DbSet<GameShootoutStatisticDataModel> GameShootoutStatistics { get; set; }
        public DbSet<SettingDataModel> Settings { get; set; }
        
        public DihlDbContext(DbContextOptions<DihlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<LeagueDataModel>()
                .ToTable("Leagues")
                .HasKey(i => i.Id);

            modelBuilder.Entity<SeasonDataModel>()
                .ToTable("Seasons")
                .HasKey(i => i.Id);

            modelBuilder.Entity<TeamDataModel>()
                .ToTable("Teams")
                .HasKey(i => i.Id);

            modelBuilder.Entity<PlayerDataModel>()
                .ToTable("Players")
                .HasKey(i => i.Id);

            modelBuilder.Entity<PlayerTeamDataModel>()
                .ToTable("PlayerTeams")
                .HasKey(i => i.Id);

            modelBuilder.Entity<GameDataModel>()
                .ToTable("Games")
                .HasKey(i => i.Id);

            modelBuilder.Entity<GameDataModel>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameDataModel>()
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GamePlayedDataModel>()
                .ToTable("GamesPlayed")
                .HasKey(i => new {i.PlayerId, i.GameId});

            modelBuilder.Entity<GamePlayedDataModel>()
                .HasOne(g => g.Team)
                .WithMany(t => t.GamesPlayed)
                .HasForeignKey(g => g.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PenaltyDataModel>()
                .ToTable("Penalties")
                .HasKey(i => i.Id);

            modelBuilder.Entity<PenaltyDataModel>()
                .HasOne(g => g.Team)
                .WithMany(t => t.Penalites)
                .HasForeignKey(g => g.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameGoalieStatisticDataModel>()
                .ToTable("GameGoalieStatistics")
                .HasKey(i => i.Id);

            modelBuilder.Entity<GameGoalieStatisticDataModel>()
                .HasOne(g => g.Team)
                .WithMany(t => t.GoalieStatistics)
                .HasForeignKey(g => g.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameSkaterStatisticDataModel>()
                .ToTable("GameSkaterStatistics")
                .HasKey(i => i.Id);

            modelBuilder.Entity<GameSkaterStatisticDataModel>()
                .HasOne(g => g.Team)
                .WithMany(t => t.SkaterStatistics)
                .HasForeignKey(g => g.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameShootoutStatisticDataModel>()
                .ToTable("GameShootoutStatistics")
                .HasKey(i => i.Id);

            modelBuilder.Entity<GameShootoutStatisticDataModel>()
                .HasOne(g => g.Game)
                .WithMany(t => t.ShootoutStatistics)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SkaterShootoutStatisticDataModel>()
                .ToTable("SkaterShootoutStatistics")
                .HasKey(i => i.Id);

            modelBuilder.Entity<SkaterShootoutStatisticDataModel>()
                .HasOne(g => g.ShootoutStatistic)
                .WithMany(t => t.SkaterShootoutStatistics)
                .HasForeignKey(g => g.GameShootoutStatisticId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GoalieShootoutStatisticDataModel>()
                .ToTable("GoalieShootoutStatistics")
                .HasKey(i => i.Id);

            modelBuilder.Entity<GoalieShootoutStatisticDataModel>()
                .HasOne(g => g.ShootoutStatistic)
                .WithMany(t => t.GoalieShootoutStatistics)
                .HasForeignKey(g => g.GameShootoutStatisticId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SettingDataModel>()
		        .ToTable("Settings")
		        .HasKey(i => new { i.Key, i.Conditional });

            base.OnModelCreating(modelBuilder);
        }
    }
}
