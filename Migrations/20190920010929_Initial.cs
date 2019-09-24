using Microsoft.EntityFrameworkCore.Migrations;

namespace qwtfarena.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscordVoiceChannels",
                columns: table => new
                {
                    DiscordVoiceChannelID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordVoiceChannels", x => x.DiscordVoiceChannelID);
                });

            migrationBuilder.CreateTable(
                name: "DiscordVoiceUsers",
                columns: table => new
                {
                    DiscordVoiceUserID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    DiscordVoiceChannelID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordVoiceUsers", x => x.DiscordVoiceUserID);
                    table.ForeignKey(
                        name: "FK_DiscordVoiceUsers_DiscordVoiceChannels_DiscordVoiceChannelID",
                        column: x => x.DiscordVoiceChannelID,
                        principalTable: "DiscordVoiceChannels",
                        principalColumn: "DiscordVoiceChannelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscordVoiceUsers_DiscordVoiceChannelID",
                table: "DiscordVoiceUsers",
                column: "DiscordVoiceChannelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscordVoiceUsers");

            migrationBuilder.DropTable(
                name: "DiscordVoiceChannels");
        }
    }
}
