using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Information",
                table: "Goods",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Goods",
                newName: "Information");
        }
    }
}
