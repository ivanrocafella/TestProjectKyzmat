using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectKyzmat.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changedbalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 8m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 27.8m);
        }
    }
}
