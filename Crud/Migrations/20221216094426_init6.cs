using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
