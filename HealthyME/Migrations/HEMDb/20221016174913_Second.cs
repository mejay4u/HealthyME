using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyME.Migrations.HEMDb
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    MobileNo = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
