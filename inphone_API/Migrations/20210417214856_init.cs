using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace inphone_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: false),
                    Logo1 = table.Column<string>(maxLength: 255, nullable: true),
                    Logo2 = table.Column<string>(maxLength: 255, nullable: true),
                    Logo3 = table.Column<string>(maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "TypeButton",
                columns: table => new
                {
                    IdTypeButton = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeButton", x => x.IdTypeButton);
                });

            migrationBuilder.CreateTable(
                name: "Button",
                columns: table => new
                {
                    IdButton = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(maxLength: 255, nullable: false),
                    Link = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Content = table.Column<string>(maxLength: 255, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Button", x => x.IdButton);
                    table.ForeignKey(
                        name: "FK_Button_Customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Button_TypeButton_Type",
                        column: x => x.Type,
                        principalTable: "TypeButton",
                        principalColumn: "IdTypeButton",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeButton",
                columns: new[] { "IdTypeButton", "Description", "Label" },
                values: new object[,]
                {
                    { 1, "(Should open the default text app of the user's phone) - and default use phone number in the setup", "Text" },
                    { 2, "(Should open default email function from users phone)", "Send email" },
                    { 3, "", "Call" },
                    { 4, "", "Video" },
                    { 5, "", "Web link" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Button_IdCustomer",
                table: "Button",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Button_Type",
                table: "Button",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Button");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "TypeButton");
        }
    }
}
