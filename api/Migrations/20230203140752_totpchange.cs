using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbasaurAPI.Migrations
{
    public partial class totpchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "TOTPs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Secret",
                table: "TOTPs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "TimeWindowUsed",
                table: "TOTPs",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "TOTPs");

            migrationBuilder.DropColumn(
                name: "Secret",
                table: "TOTPs");

            migrationBuilder.DropColumn(
                name: "TimeWindowUsed",
                table: "TOTPs");
        }
    }
}
