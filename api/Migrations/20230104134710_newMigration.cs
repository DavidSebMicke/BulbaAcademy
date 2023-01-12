using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbasaurAPI.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "Chats",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Chats", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Documents",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Documents", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Roles",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Roles", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TOTPs",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TOTPs", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Persons",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PhoneNumber = table.Column<int>(type: "int", nullable: false),
        //            EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            RoleId = table.Column<int>(type: "int", nullable: false),
        //            DocumentId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Persons", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Persons_Documents_DocumentId",
        //                column: x => x.DocumentId,
        //                principalTable: "Documents",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_Persons_Roles_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "Roles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Caregivers",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Caregivers", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Caregivers_Persons_Id",
        //                column: x => x.Id,
        //                principalTable: "Persons",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Children",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Children", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Children_Persons_Id",
        //                column: x => x.Id,
        //                principalTable: "Persons",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Groups",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PersonId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Groups", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Groups_Persons_PersonId",
        //                column: x => x.PersonId,
        //                principalTable: "Persons",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Personells",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false),
        //            Employment = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            FullTimeEmployment = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Personells", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Personells_Persons_Id",
        //                column: x => x.Id,
        //                principalTable: "Persons",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //            Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PersonId = table.Column<int>(type: "int", nullable: false),
        //            ChatId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Users_Chats_ChatId",
        //                column: x => x.ChatId,
        //                principalTable: "Chats",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_Users_Persons_PersonId",
        //                column: x => x.PersonId,
        //                principalTable: "Persons",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CaregiverChildren",
        //        columns: table => new
        //        {
        //            CaregiverId = table.Column<int>(type: "int", nullable: false),
        //            ChildId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CaregiverChildren", x => new { x.CaregiverId, x.ChildId });
        //            table.ForeignKey(
        //                name: "FK_CaregiverChildren_Caregivers_CaregiverId",
        //                column: x => x.CaregiverId,
        //                principalTable: "Caregivers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_CaregiverChildren_Children_ChildId",
        //                column: x => x.ChildId,
        //                principalTable: "Children",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "GroupPersons",
        //        columns: table => new
        //        {
        //            GroupId = table.Column<int>(type: "int", nullable: false),
        //            PersonId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_GroupPersons", x => new { x.GroupId, x.PersonId });
        //            table.ForeignKey(
        //                name: "FK_GroupPersons_Groups_GroupId",
        //                column: x => x.GroupId,
        //                principalTable: "Groups",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_GroupPersons_Persons_PersonId",
        //                column: x => x.PersonId,
        //                principalTable: "Persons",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ChatItems",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            AuthorId = table.Column<int>(type: "int", nullable: false),
        //            Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            ChatId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ChatItems", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ChatItems_Chats_ChatId",
        //                column: x => x.ChatId,
        //                principalTable: "Chats",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ChatItems_Users_AuthorId",
        //                column: x => x.AuthorId,
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Loggings",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Loggings", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Loggings_Users_UserId",
        //                column: x => x.UserId,
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LogInInformations",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            LogInCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Date = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            LoggedInDevice = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LogInInformations", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_LogInInformations_Users_UserId",
        //                column: x => x.UserId,
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CaregiverChildren_ChildId",
        //        table: "CaregiverChildren",
        //        column: "ChildId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ChatItems_AuthorId",
        //        table: "ChatItems",
        //        column: "AuthorId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ChatItems_ChatId",
        //        table: "ChatItems",
        //        column: "ChatId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_GroupPersons_PersonId",
        //        table: "GroupPersons",
        //        column: "PersonId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Groups_PersonId",
        //        table: "Groups",
        //        column: "PersonId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Loggings_UserId",
        //        table: "Loggings",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LogInInformations_UserId",
        //        table: "LogInInformations",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Persons_DocumentId",
        //        table: "Persons",
        //        column: "DocumentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Persons_RoleId",
        //        table: "Persons",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_ChatId",
        //        table: "Users",
        //        column: "ChatId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_PersonId",
        //        table: "Users",
        //        column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaregiverChildren");

            migrationBuilder.DropTable(
                name: "ChatItems");

            migrationBuilder.DropTable(
                name: "GroupPersons");

            migrationBuilder.DropTable(
                name: "Loggings");

            migrationBuilder.DropTable(
                name: "LogInInformations");

            migrationBuilder.DropTable(
                name: "Personells");

            migrationBuilder.DropTable(
                name: "TOTPs");

            migrationBuilder.DropTable(
                name: "Caregivers");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
