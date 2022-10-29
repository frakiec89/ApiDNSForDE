using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDNSForDE.Migrations
{
    public partial class N1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LockDNs",
                columns: table => new
                {
                    LockDNSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeAut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockDNs", x => x.LockDNSId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LockDNs");
        }
    }
}
