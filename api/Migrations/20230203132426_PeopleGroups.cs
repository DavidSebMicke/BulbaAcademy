using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbasaurAPI.Migrations
{
    public partial class PeopleGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_GroupId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Persons_PersonId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_PersonId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "GroupPerson",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPerson", x => new { x.GroupsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_GroupPerson_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPerson_Persons_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupPerson_PeopleId",
                table: "GroupPerson",
                column: "PeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupPerson");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupId",
                table: "Groups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PersonId",
                table: "Groups",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_GroupId",
                table: "Groups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Persons_PersonId",
                table: "Groups",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
