using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace subway_project.Server.Migrations
{
    /// <inheritdoc />
    public partial class ModelRevision_MovedOrderDatesFromQueueToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCollected",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "OrderCompleted",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "OrderInProgress",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "OrderReceived",
                table: "Queues");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCollected",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCompleted",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderInProgress",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderReceived",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCollected",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCompleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderInProgress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderReceived",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCollected",
                table: "Queues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCompleted",
                table: "Queues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderInProgress",
                table: "Queues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderReceived",
                table: "Queues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
