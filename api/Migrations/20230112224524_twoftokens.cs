using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbasaurAPI.Migrations
{
    public partial class twoftokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "AccessTokens",
                newName: "TokenStr");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LogInInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TwoFToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenStr = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IssuedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUsedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoFToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TwoFToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TwoFToken_UserId",
                table: "TwoFToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwoFToken");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LogInInformations");

            migrationBuilder.RenameColumn(
                name: "TokenStr",
                table: "AccessTokens",
                newName: "Token");
        }
    }
}
