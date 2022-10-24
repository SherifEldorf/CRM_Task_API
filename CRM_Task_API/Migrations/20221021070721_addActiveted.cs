using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Task_API.Migrations
{
    public partial class addActiveted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activeted",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activeted",
                table: "Customers");
        }
    }
}
