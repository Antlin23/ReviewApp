using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class Booktoitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_BookEntity_BookId",
                table: "ReviewEntity");

            migrationBuilder.DropTable(
                name: "BookEntity");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "ReviewEntity",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_BookId",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_ItemId");

            migrationBuilder.CreateTable(
                name: "ItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEntity", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_ItemEntity_ItemId",
                table: "ReviewEntity",
                column: "ItemId",
                principalTable: "ItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_ItemEntity_ItemId",
                table: "ReviewEntity");

            migrationBuilder.DropTable(
                name: "ItemEntity");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ReviewEntity",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_ItemId",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_BookId");

            migrationBuilder.CreateTable(
                name: "BookEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntity", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_BookEntity_BookId",
                table: "ReviewEntity",
                column: "BookId",
                principalTable: "BookEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
