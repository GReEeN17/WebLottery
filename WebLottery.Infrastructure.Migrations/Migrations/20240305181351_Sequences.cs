using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLottery.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Sequences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterSequence(
                name: "wallet_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999L);

            migrationBuilder.AlterSequence(
                name: "wallet_currency_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999L);

            migrationBuilder.AlterSequence(
                name: "user_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999L);

            migrationBuilder.AlterSequence(
                name: "ticket_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 9999999L);

            migrationBuilder.AlterSequence(
                name: "prize_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999L);

            migrationBuilder.AlterSequence(
                name: "pocket_ticket_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999L);

            migrationBuilder.AlterSequence(
                name: "pocket_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 9999999L);

            migrationBuilder.AlterSequence(
                name: "draw_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999L);

            migrationBuilder.AlterSequence(
                name: "currency_sequence",
                minValue: 1L,
                maxValue: 999999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterSequence(
                name: "wallet_sequence",
                minValue: 1L,
                maxValue: 999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "wallet_currency_sequence",
                minValue: 1L,
                maxValue: 999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "user_sequence",
                minValue: 1L,
                maxValue: 999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "ticket_sequence",
                minValue: 1L,
                maxValue: 9999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "prize_sequence",
                minValue: 1L,
                maxValue: 999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "pocket_ticket_sequence",
                minValue: 1L,
                maxValue: 999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "pocket_sequence",
                minValue: 1L,
                maxValue: 9999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "draw_sequence",
                minValue: 1L,
                maxValue: 999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);

            migrationBuilder.AlterSequence(
                name: "currency_sequence",
                minValue: 1L,
                maxValue: 999999L,
                oldMinValue: 1L,
                oldMaxValue: 999999999L);
        }
    }
}
