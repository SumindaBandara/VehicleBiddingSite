using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidNest.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Bids_BidId",
                table: "Feedbacks");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Items_ItemId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Feedbacks",
                newName: "BidId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_ItemId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Bids_BidId",
                table: "Feedbacks",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
