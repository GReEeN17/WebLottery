using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLottery.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pocket_user_user_id",
                table: "pocket");

            migrationBuilder.DropForeignKey(
                name: "FK_pocket_ticket_pocket_PocketEntityId",
                table: "pocket_ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_prize_currency_CurrencyEntityId",
                table: "prize");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_draw_DrawEntityId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_wallet_currency_currency_CurrencyEntityId",
                table: "wallet_currency");

            migrationBuilder.DropForeignKey(
                name: "FK_wallet_currency_wallet_WalletEntityId",
                table: "wallet_currency");

            migrationBuilder.DropIndex(
                name: "IX_wallet_currency_CurrencyEntityId",
                table: "wallet_currency");

            migrationBuilder.DropIndex(
                name: "IX_wallet_currency_WalletEntityId",
                table: "wallet_currency");

            migrationBuilder.DropIndex(
                name: "IX_ticket_DrawEntityId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_prize_CurrencyEntityId",
                table: "prize");

            migrationBuilder.DropIndex(
                name: "IX_pocket_ticket_PocketEntityId",
                table: "pocket_ticket");

            migrationBuilder.DropIndex(
                name: "IX_pocket_user_id",
                table: "pocket");

            migrationBuilder.DropColumn(
                name: "CurrencyEntityId",
                table: "wallet_currency");

            migrationBuilder.DropColumn(
                name: "WalletEntityId",
                table: "wallet_currency");

            migrationBuilder.DropColumn(
                name: "DrawEntityId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "CurrencyEntityId",
                table: "prize");

            migrationBuilder.DropColumn(
                name: "PocketEntityId",
                table: "pocket_ticket");

            migrationBuilder.RenameColumn(
                name: "wallet_id",
                table: "wallet_currency",
                newName: "WalletId");

            migrationBuilder.RenameColumn(
                name: "column_id",
                table: "wallet_currency",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "wallet",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "draw_id",
                table: "ticket",
                newName: "DrawId");

            migrationBuilder.RenameColumn(
                name: "currency_id",
                table: "prize",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "ticket_id",
                table: "pocket_ticket",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "pocket_id",
                table: "pocket_ticket",
                newName: "PocketId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "pocket",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "prize_id",
                table: "draw",
                newName: "PrizeId");

            migrationBuilder.AddColumn<int>(
                name: "PocketId",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_wallet_currency_CurrencyId",
                table: "wallet_currency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_currency_WalletId",
                table: "wallet_currency",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_UserId",
                table: "wallet",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_DrawId",
                table: "ticket",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_prize_CurrencyId",
                table: "prize",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_pocket_ticket_PocketId",
                table: "pocket_ticket",
                column: "PocketId");

            migrationBuilder.CreateIndex(
                name: "IX_pocket_ticket_TicketId",
                table: "pocket_ticket",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pocket_UserId",
                table: "pocket",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_draw_PrizeId",
                table: "draw",
                column: "PrizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_draw_prize_PrizeId",
                table: "draw",
                column: "PrizeId",
                principalTable: "prize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pocket_user_UserId",
                table: "pocket",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pocket_ticket_pocket_PocketId",
                table: "pocket_ticket",
                column: "PocketId",
                principalTable: "pocket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pocket_ticket_ticket_TicketId",
                table: "pocket_ticket",
                column: "TicketId",
                principalTable: "ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prize_currency_CurrencyId",
                table: "prize",
                column: "CurrencyId",
                principalTable: "currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_draw_DrawId",
                table: "ticket",
                column: "DrawId",
                principalTable: "draw",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_user_UserId",
                table: "wallet",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_currency_currency_CurrencyId",
                table: "wallet_currency",
                column: "CurrencyId",
                principalTable: "currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_currency_wallet_WalletId",
                table: "wallet_currency",
                column: "WalletId",
                principalTable: "wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_draw_prize_PrizeId",
                table: "draw");

            migrationBuilder.DropForeignKey(
                name: "FK_pocket_user_UserId",
                table: "pocket");

            migrationBuilder.DropForeignKey(
                name: "FK_pocket_ticket_pocket_PocketId",
                table: "pocket_ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_pocket_ticket_ticket_TicketId",
                table: "pocket_ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_prize_currency_CurrencyId",
                table: "prize");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_draw_DrawId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_wallet_user_UserId",
                table: "wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_wallet_currency_currency_CurrencyId",
                table: "wallet_currency");

            migrationBuilder.DropForeignKey(
                name: "FK_wallet_currency_wallet_WalletId",
                table: "wallet_currency");

            migrationBuilder.DropIndex(
                name: "IX_wallet_currency_CurrencyId",
                table: "wallet_currency");

            migrationBuilder.DropIndex(
                name: "IX_wallet_currency_WalletId",
                table: "wallet_currency");

            migrationBuilder.DropIndex(
                name: "IX_wallet_UserId",
                table: "wallet");

            migrationBuilder.DropIndex(
                name: "IX_ticket_DrawId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_prize_CurrencyId",
                table: "prize");

            migrationBuilder.DropIndex(
                name: "IX_pocket_ticket_PocketId",
                table: "pocket_ticket");

            migrationBuilder.DropIndex(
                name: "IX_pocket_ticket_TicketId",
                table: "pocket_ticket");

            migrationBuilder.DropIndex(
                name: "IX_pocket_UserId",
                table: "pocket");

            migrationBuilder.DropIndex(
                name: "IX_draw_PrizeId",
                table: "draw");

            migrationBuilder.DropColumn(
                name: "PocketId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "wallet_currency",
                newName: "wallet_id");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "wallet_currency",
                newName: "column_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "wallet",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "DrawId",
                table: "ticket",
                newName: "draw_id");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "prize",
                newName: "currency_id");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "pocket_ticket",
                newName: "ticket_id");

            migrationBuilder.RenameColumn(
                name: "PocketId",
                table: "pocket_ticket",
                newName: "pocket_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "pocket",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "PrizeId",
                table: "draw",
                newName: "prize_id");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyEntityId",
                table: "wallet_currency",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalletEntityId",
                table: "wallet_currency",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrawEntityId",
                table: "ticket",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyEntityId",
                table: "prize",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PocketEntityId",
                table: "pocket_ticket",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_wallet_currency_CurrencyEntityId",
                table: "wallet_currency",
                column: "CurrencyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_currency_WalletEntityId",
                table: "wallet_currency",
                column: "WalletEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_DrawEntityId",
                table: "ticket",
                column: "DrawEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_prize_CurrencyEntityId",
                table: "prize",
                column: "CurrencyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_pocket_ticket_PocketEntityId",
                table: "pocket_ticket",
                column: "PocketEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_pocket_user_id",
                table: "pocket",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pocket_user_user_id",
                table: "pocket",
                column: "user_id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pocket_ticket_pocket_PocketEntityId",
                table: "pocket_ticket",
                column: "PocketEntityId",
                principalTable: "pocket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_prize_currency_CurrencyEntityId",
                table: "prize",
                column: "CurrencyEntityId",
                principalTable: "currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_draw_DrawEntityId",
                table: "ticket",
                column: "DrawEntityId",
                principalTable: "draw",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_currency_currency_CurrencyEntityId",
                table: "wallet_currency",
                column: "CurrencyEntityId",
                principalTable: "currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_currency_wallet_WalletEntityId",
                table: "wallet_currency",
                column: "WalletEntityId",
                principalTable: "wallet",
                principalColumn: "Id");
        }
    }
}
