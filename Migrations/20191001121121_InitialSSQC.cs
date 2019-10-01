using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace qwtfarena.Migrations
{
    public partial class InitialSSQC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SSQCGameInfo",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServerName = table.Column<string>(maxLength: 500, nullable: false),
                    Map = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSQCGameInfo", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "SSQCGameState",
                columns: table => new
                {
                    GameStateID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameID = table.Column<int>(nullable: false),
                    GameTime = table.Column<float>(nullable: false),
                    EventType = table.Column<string>(maxLength: 500, nullable: false),
                    Initiator = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSQCGameState", x => x.GameStateID);
                    table.ForeignKey(
                        name: "FK_SSQCGameState_SSQCGameInfo_GameID",
                        column: x => x.GameID,
                        principalTable: "SSQCGameInfo",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SSQCGameState_GameID",
                table: "SSQCGameState",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SSQCGameState");

            migrationBuilder.DropTable(
                name: "SSQCGameInfo");
        }
    }
}
