using Microsoft.EntityFrameworkCore.Migrations;

namespace StockJocky.Storing.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "PercentChange",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "PriceChange",
                table: "Stocks");

            migrationBuilder.AddColumn<decimal>(
                name: "Change",
                table: "Stocks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "ChangePercent",
                table: "Stocks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Stocks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LatestPrice",
                table: "Stocks",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Change",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ChangePercent",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "LatestPrice",
                table: "Stocks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentChange",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceChange",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
