using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DIHL.Repository.Sql.Migrations
{
    public partial class GamePlayers_RemoveManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerDataModelId",
                schema: "dbo",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PlayerDataModelId",
                schema: "dbo",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerDataModelId",
                schema: "dbo",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlayerDataModelId",
                schema: "dbo",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerDataModelId",
                schema: "dbo",
                table: "Games",
                column: "PlayerDataModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerDataModelId",
                schema: "dbo",
                table: "Games",
                column: "PlayerDataModelId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
