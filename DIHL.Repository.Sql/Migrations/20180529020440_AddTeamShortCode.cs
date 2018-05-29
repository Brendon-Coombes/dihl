using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DIHL.Repository.Sql.Migrations
{
    public partial class AddTeamShortCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tier",
                schema: "dbo",
                table: "GameGoalieStatistics");

            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                schema: "dbo",
                table: "Teams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortCode",
                schema: "dbo",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "Tier",
                schema: "dbo",
                table: "GameGoalieStatistics",
                nullable: false,
                defaultValue: 0);
        }
    }
}
