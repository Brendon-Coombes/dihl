﻿// <auto-generated />
using DIHL.Repository.Sql.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DIHL.Repository.Sql.Migrations
{
    [DbContext(typeof(DihlDbContext))]
    [Migration("20180529020440_AddTeamShortCode")]
    partial class AddTeamShortCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GameDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AwayTeamId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("HomeTeamId");

                    b.Property<string>("Location");

                    b.Property<Guid?>("PlayerDataModelId");

                    b.Property<Guid>("SeasonId");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("PlayerDataModelId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GameGoalieStatisticDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<Guid>("GameId");

                    b.Property<int>("GoalsAllowed");

                    b.Property<Guid>("PlayerId");

                    b.Property<int>("Result");

                    b.Property<int>("Saves");

                    b.Property<int>("ShotsAgainst");

                    b.Property<Guid>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("GameGoalieStatistics");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GamePlayedDataModel", b =>
                {
                    b.Property<Guid>("PlayerId");

                    b.Property<Guid>("GameId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<Guid>("TeamId");

                    b.HasKey("PlayerId", "GameId");

                    b.HasIndex("GameId");

                    b.HasIndex("TeamId");

                    b.ToTable("GamesPlayed");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GameSkaterStatisticDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<Guid>("GameId");

                    b.Property<int>("Period");

                    b.Property<Guid>("PlayerId");

                    b.Property<Guid?>("PrimaryAssistPlayerId");

                    b.Property<int>("ScoreType");

                    b.Property<Guid?>("SecondaryAssistPlayerId");

                    b.Property<Guid>("TeamId");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PrimaryAssistPlayerId");

                    b.HasIndex("SecondaryAssistPlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("GameSkaterStatistics");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.LeagueDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("Name");

                    b.Property<int>("Tier");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.PenaltyDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<Guid>("GameId");

                    b.Property<TimeSpan>("Length");

                    b.Property<int>("PenaltyType");

                    b.Property<int>("Period");

                    b.Property<Guid>("PlayerId");

                    b.Property<bool>("PowerPlaySuccessful");

                    b.Property<Guid>("TeamId");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Penalties");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.PlayerDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.PlayerTeamDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<int?>("JerseyNumber");

                    b.Property<Guid>("PlayerId");

                    b.Property<Guid>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerTeams");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.SeasonDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<Guid>("LeagueId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("TeamDataModelId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("TeamDataModelId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.SettingDataModel", b =>
                {
                    b.Property<string>("Key");

                    b.Property<string>("Conditional");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Key", "Conditional");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.TeamDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<Guid>("LeagueId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortCode");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GameDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel", "AwayTeam")
                        .WithMany("AwayGames")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel", "HomeTeam")
                        .WithMany("HomeGames")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("PlayerDataModelId");

                    b.HasOne("DIHL.Repository.Sql.Models.SeasonDataModel", "Season")
                        .WithMany("Games")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GameGoalieStatisticDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.GameDataModel", "Game")
                        .WithMany("GameGoalieStatistics")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel", "Player")
                        .WithMany("GoalieStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel", "Team")
                        .WithMany("GoalieStatistics")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GamePlayedDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.GameDataModel", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel", "Team")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.GameSkaterStatisticDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.GameDataModel", "Game")
                        .WithMany("GameSkaterStatistics")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel", "Player")
                        .WithMany("Goals")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel", "PrimaryAssist")
                        .WithMany("PrimaryAssists")
                        .HasForeignKey("PrimaryAssistPlayerId");

                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel", "SecondaryAssist")
                        .WithMany("SecondaryAssists")
                        .HasForeignKey("SecondaryAssistPlayerId");

                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel", "Team")
                        .WithMany("SkaterStatistics")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.PenaltyDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.GameDataModel", "Game")
                        .WithMany("Penalites")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel", "Player")
                        .WithMany("Penalites")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel", "Team")
                        .WithMany("Penalites")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.PlayerTeamDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.PlayerDataModel", "Player")
                        .WithMany("TeamsPlayedFor")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.SeasonDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.LeagueDataModel", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIHL.Repository.Sql.Models.TeamDataModel")
                        .WithMany("Seasons")
                        .HasForeignKey("TeamDataModelId");
                });

            modelBuilder.Entity("DIHL.Repository.Sql.Models.TeamDataModel", b =>
                {
                    b.HasOne("DIHL.Repository.Sql.Models.LeagueDataModel", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
