using Microsoft.EntityFrameworkCore.Migrations;

namespace inphone_API.Migrations
{
    public partial class addcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeButton",
                keyColumn: "IdTypeButton",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Button");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customer",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Button",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "TypeButton",
                columns: new[] { "IdTypeButton", "Description", "Label" },
                values: new object[] { 4, "", "Video" });
        }
    }
}
