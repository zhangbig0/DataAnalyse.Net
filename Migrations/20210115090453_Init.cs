using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAnalyse.Net.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelecomRecord",
                columns: table => new
                {
                    CallerFlag = table.Column<int>(type: "int", nullable: false),
                    TimeSpan = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<int>(type: "int", nullable: false),
                    Phone1 = table.Column<string>(type: "longtext", nullable: true),
                    CallerSite1 = table.Column<string>(type: "longtext", nullable: true),
                    Offset1 = table.Column<string>(type: "longtext", nullable: true),
                    Phone2 = table.Column<string>(type: "longtext", nullable: true),
                    CallerSite2 = table.Column<string>(type: "longtext", nullable: true),
                    Offset2 = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelecomRecord");
        }
    }
}
