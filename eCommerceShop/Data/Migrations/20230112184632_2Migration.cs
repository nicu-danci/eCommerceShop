using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceShop.Data.Migrations
{
    public partial class _2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdctType",
                table: "ProductTypes",
                newName: "ProductType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "ProductTypes",
                newName: "ProdctType");
        }
    }
}
