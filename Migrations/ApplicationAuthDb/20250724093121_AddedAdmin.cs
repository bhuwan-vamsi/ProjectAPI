using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPractice.Migrations.ApplicationAuthDb
{
    /// <inheritdoc />
    public partial class AddedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e10adcf6-d187-45bb-b32b-a040a9023e7d", "e10adcf6-d187-45bb-b32b-a040a9023e7d", "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e10adcf6-d187-45bb-b32b-a040a9023e7d");
        }
    }
}
