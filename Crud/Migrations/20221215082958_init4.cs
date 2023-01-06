using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_States_StateId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CityId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StateId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StateId1",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId1",
                table: "Users",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId1",
                table: "Users",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId1",
                table: "Users",
                column: "StateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId1",
                table: "Users",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId1",
                table: "Users",
                column: "CountryId1",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_States_StateId1",
                table: "Users",
                column: "StateId1",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
