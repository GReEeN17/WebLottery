using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLottery.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "currency_sequence",
                minValue: 1L,
                maxValue: 999999L);

            migrationBuilder.CreateSequence<int>(
                name: "draw_sequence",
                minValue: 1L,
                maxValue: 999999L);

            migrationBuilder.CreateSequence<int>(
                name: "pocket_sequence",
                minValue: 1L,
                maxValue: 9999999L);

            migrationBuilder.CreateSequence<int>(
                name: "pocket_ticket_sequence",
                minValue: 1L,
                maxValue: 999999L);

            migrationBuilder.CreateSequence<int>(
                name: "prize_sequence",
                minValue: 1L,
                maxValue: 999999L);

            migrationBuilder.CreateSequence<int>(
                name: "ticket_sequence",
                minValue: 1L,
                maxValue: 9999999L);

            migrationBuilder.CreateSequence<int>(
                name: "user_sequence",
                minValue: 1L,
                maxValue: 999999L);

            migrationBuilder.CreateSequence<int>(
                name: "wallet_currency_sequence",
                minValue: 1L,
                maxValue: 999999L);

            migrationBuilder.CreateSequence<int>(
                name: "wallet_sequence",
                minValue: 1L,
                maxValue: 999999L);

            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"currency_sequence\"')"),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    abbreviation = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "draw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"draw_sequence\"')"),
                    ticket_price = table.Column<int>(type: "integer", nullable: false),
                    cur_am_players = table.Column<int>(type: "integer", nullable: false),
                    max_am_players = table.Column<int>(type: "integer", nullable: false),
                    IsEnded = table.Column<bool>(type: "boolean", nullable: false),
                    prize_id = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_draw", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"user_sequence\"')"),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    UserRole = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"wallet_sequence\"')"),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"prize_sequence\"')"),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    currency_id = table.Column<int>(type: "integer", nullable: false),
                    CurrencyEntityId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prize_currency_CurrencyEntityId",
                        column: x => x.CurrencyEntityId,
                        principalTable: "currency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"ticket_sequence\"')"),
                    lucky_number = table.Column<int>(type: "integer", nullable: false),
                    draw_id = table.Column<int>(type: "integer", nullable: false),
                    PurchaseTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DrawEntityId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_draw_DrawEntityId",
                        column: x => x.DrawEntityId,
                        principalTable: "draw",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pocket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"pocket_sequence\"')"),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pocket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pocket_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallet_currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"wallet_currency_sequence\"')"),
                    wallet_id = table.Column<int>(type: "integer", nullable: false),
                    column_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    CurrencyEntityId = table.Column<int>(type: "integer", nullable: true),
                    WalletEntityId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet_currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wallet_currency_currency_CurrencyEntityId",
                        column: x => x.CurrencyEntityId,
                        principalTable: "currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wallet_currency_wallet_WalletEntityId",
                        column: x => x.WalletEntityId,
                        principalTable: "wallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pocket_ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"pocket_ticket_sequence\"')"),
                    pocket_id = table.Column<int>(type: "integer", nullable: false),
                    ticket_id = table.Column<int>(type: "integer", nullable: false),
                    PocketEntityId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<int>(type: "integer", nullable: false),
                    UserUpdated = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pocket_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pocket_ticket_pocket_PocketEntityId",
                        column: x => x.PocketEntityId,
                        principalTable: "pocket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pocket_user_id",
                table: "pocket",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pocket_ticket_PocketEntityId",
                table: "pocket_ticket",
                column: "PocketEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_prize_CurrencyEntityId",
                table: "prize",
                column: "CurrencyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_DrawEntityId",
                table: "ticket",
                column: "DrawEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_currency_CurrencyEntityId",
                table: "wallet_currency",
                column: "CurrencyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_currency_WalletEntityId",
                table: "wallet_currency",
                column: "WalletEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pocket_ticket");

            migrationBuilder.DropTable(
                name: "prize");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "wallet_currency");

            migrationBuilder.DropTable(
                name: "pocket");

            migrationBuilder.DropTable(
                name: "draw");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "wallet");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropSequence(
                name: "currency_sequence");

            migrationBuilder.DropSequence(
                name: "draw_sequence");

            migrationBuilder.DropSequence(
                name: "pocket_sequence");

            migrationBuilder.DropSequence(
                name: "pocket_ticket_sequence");

            migrationBuilder.DropSequence(
                name: "prize_sequence");

            migrationBuilder.DropSequence(
                name: "ticket_sequence");

            migrationBuilder.DropSequence(
                name: "user_sequence");

            migrationBuilder.DropSequence(
                name: "wallet_currency_sequence");

            migrationBuilder.DropSequence(
                name: "wallet_sequence");
        }
    }
}
