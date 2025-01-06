using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class Amountoffollowsuserentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfFollowers",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfFollows",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfFollowers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AmountOfFollows",
                table: "AspNetUsers");
        }
    }
}
