using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCodeFirst.Migrations
{
    public partial class AddClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartedDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(
                "INSERT INTO " +
                "Client(Name, Location, StartedDate, EndedDate) " +
                "VALUES" +
                "('Microsoft', 'USA', '2019-11-23', NULL), " +
                "('UkrEnergo', 'Ukraine', '2015-01-10', NULL), " +
                "('Xiaomi', 'China', '2015-01-10', NULL), " +
                "('Tuborg', 'Denmark', '2015-01-10', '2019-08-26'), " +
                "('Alpine', 'Japan', '2020-05-13', NULL)");

            migrationBuilder.Sql(
                "INSERT INTO " +
                "Project (Name, Budget, StartedDate, ClientId) " +
                "VALUES " +
                "('WebShop', 978783, '2019-11-23', (SELECT ClientId FROM Client WHERE Name = 'Microsoft')), " +
                "('Provider', 68524, '2015-01-10', (SELECT ClientId FROM Client WHERE Name = 'UkrEnergo')), " +
                "('EmailWorker', '356987', '2015-01-10', (SELECT ClientId FROM Client WHERE Name = 'Xiaomi')), " +
                "('BottleDesigner ', '345869', '2015-01-10', (SELECT ClientId FROM Client WHERE Name = 'Tuborg')), " +
                "('Player', 56489, '2020-05-13', (SELECT ClientId FROM Client WHERE Name = 'Alpine'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");

            migrationBuilder.Sql(
               "DELETE FROM Project");

            migrationBuilder.Sql("DBCC CHECKIDENT(Project, RESEED, 0)");
        }
    }
}
