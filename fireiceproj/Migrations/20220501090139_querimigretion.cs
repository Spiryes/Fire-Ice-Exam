using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fireiceproj.Migrations
{
    public partial class querimigretion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    Idquer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameoftheproblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Txt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofvisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nameoftechnition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.Idquer);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Queries");
        }
    }
}
