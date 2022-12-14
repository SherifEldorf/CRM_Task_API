using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Task_API.Migrations
{
    public partial class addOrdersDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNo = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    orderedQty = table.Column<int>(nullable: false),
                    TaxAmount = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersDetails");
        }
    }
}
