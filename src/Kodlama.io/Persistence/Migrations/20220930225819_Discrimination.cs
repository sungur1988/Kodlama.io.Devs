using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Discrimination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedia_AppUsers_AppUserId",
                table: "SocialMedia");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_Users_AppUserId",
                table: "SocialMedia",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedia_Users_AppUserId",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_AppUsers_AppUserId",
                table: "SocialMedia",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
