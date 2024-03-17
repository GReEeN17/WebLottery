using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLottery.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DeletedUserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "wallet_currency");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "wallet_currency");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "wallet");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "wallet");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "prize");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "prize");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "pocket_ticket");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "pocket_ticket");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "pocket");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "pocket");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "draw");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "draw");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "currency");

            migrationBuilder.DropColumn(
                name: "UserUpdated",
                table: "currency");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "wallet_currency",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "wallet_currency",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "wallet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "wallet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "prize",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "prize",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "pocket_ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "pocket_ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "pocket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "pocket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "draw",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "draw",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "currency",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdated",
                table: "currency",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
