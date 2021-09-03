using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Tag_TagId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_TagId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_TagId",
                table: "Product",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Tag_TagId",
                table: "Product",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
