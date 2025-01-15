using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class rolesonmodelcreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9493816a-8694-4b62-a009-946c82e6934a", "29b4593c-4fce-45bc-bea4-1871a7414176", "User", "USER" },
                    { "dafeb7af-d905-4782-9497-87bfa0355748", "74ac6a09-4b6b-4472-86c8-6f44f1c3967e", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9493816a-8694-4b62-a009-946c82e6934a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dafeb7af-d905-4782-9497-87bfa0355748");
        }
    }
}
