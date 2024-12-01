using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidNest.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Items_ItemId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Feedbacks",
                newName: "BidId");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Feedbacks",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_ItemId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_BidId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateGiven",
                table: "Feedbacks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Bids_BidId",
                table: "Feedbacks",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Bids_BidId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "DateGiven",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Feedbacks",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "BidId",
                table: "Feedbacks",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_BidId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Items_ItemId",
                table: "Feedbacks",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
