using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbasaurAPI.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Groups_GroupId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_GroupId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "GroupPerson",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPerson", x => new { x.GroupsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_GroupPerson_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPerson_Persons_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupPerson_MembersId",
                table: "GroupPerson",
                column: "MembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupPerson");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GroupId",
                table: "Persons",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Groups_GroupId",
                table: "Persons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
