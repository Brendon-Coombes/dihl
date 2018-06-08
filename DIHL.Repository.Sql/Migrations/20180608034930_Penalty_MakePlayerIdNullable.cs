using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DIHL.Repository.Sql.Migrations
{
    public partial class Penalty_MakePlayerIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_Players_PlayerId",
                schema: "dbo",
                table: "Penalties");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                schema: "dbo",
                table: "Penalties",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_Players_PlayerId",
                schema: "dbo",
                table: "Penalties",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_Players_PlayerId",
                schema: "dbo",
                table: "Penalties");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                schema: "dbo",
                table: "Penalties",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_Players_PlayerId",
                schema: "dbo",
                table: "Penalties",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
