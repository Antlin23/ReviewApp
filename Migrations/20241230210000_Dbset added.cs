using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class Dbsetadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_AspNetUsers_UserId",
                table: "ReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_ItemEntity_ItemId",
                table: "ReviewEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewEntity",
                table: "ReviewEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemEntity",
                table: "ItemEntity");

            migrationBuilder.RenameTable(
                name: "ReviewEntity",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "ItemEntity",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_ItemId",
                table: "Reviews",
                newName: "IX_Reviews_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Items_ItemId",
                table: "Reviews",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Items_ItemId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "ReviewEntity");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "ItemEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ItemId",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewEntity",
                table: "ReviewEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemEntity",
                table: "ItemEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_AspNetUsers_UserId",
                table: "ReviewEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_ItemEntity_ItemId",
                table: "ReviewEntity",
                column: "ItemId",
                principalTable: "ItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
