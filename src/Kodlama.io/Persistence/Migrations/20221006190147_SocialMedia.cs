using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class SocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedia_Users_AppUserId",
                table: "SocialMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedia",
                table: "SocialMedia");

            migrationBuilder.RenameTable(
                name: "SocialMedia",
                newName: "SocialMedias");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMedia_AppUserId",
                table: "SocialMedias",
                newName: "IX_SocialMedias_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_Users_AppUserId",
                table: "SocialMedias",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Users_AppUserId",
                table: "SocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias");

            migrationBuilder.RenameTable(
                name: "SocialMedias",
                newName: "SocialMedia");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMedias_AppUserId",
                table: "SocialMedia",
                newName: "IX_SocialMedia_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedia",
                table: "SocialMedia",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_Users_AppUserId",
                table: "SocialMedia",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
