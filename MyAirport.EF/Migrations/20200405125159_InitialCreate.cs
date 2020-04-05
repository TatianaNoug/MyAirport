using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LLTM.MyAirport.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    VolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cie = table.Column<string>(type: "char(10)", nullable: true),
                    Lig = table.Column<string>(type: "char(5)", nullable: true),
                    Dhc = table.Column<DateTime>(nullable: false),
                    Pkg = table.Column<string>(type: "char(3)", nullable: true),
                    Imm = table.Column<string>(type: "char(6)", nullable: true),
                    Pax = table.Column<short>(nullable: true),
                    Des = table.Column<string>(type: "char(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.VolID);
                });

            migrationBuilder.CreateTable(
                name: "Bagages",
                columns: table => new
                {
                    BagageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolID = table.Column<int>(nullable: true),
                    CodeIata = table.Column<string>(type: "char(12)", nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Classe = table.Column<string>(type: "char(1)", nullable: true),
                    Prioritaire = table.Column<bool>(nullable: true),
                    Sta = table.Column<string>(type: "char(1)", nullable: true),
                    Ssur = table.Column<string>(type: "char(3)", nullable: true),
                    Destination = table.Column<string>(type: "varchar(3)", nullable: true),
                    Escale = table.Column<string>(type: "char(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bagages", x => x.BagageID);
                    table.ForeignKey(
                        name: "FK_Bagages_Vols_VolID",
                        column: x => x.VolID,
                        principalTable: "Vols",
                        principalColumn: "VolID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bagages_VolID",
                table: "Bagages",
                column: "VolID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bagages");

            migrationBuilder.DropTable(
                name: "Vols");
        }
    }
}
