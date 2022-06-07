using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace broker.Data.Migrations
{
    public partial class AddOrderTypeIntoAlert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Alert",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Alert");
        }
    }
}
