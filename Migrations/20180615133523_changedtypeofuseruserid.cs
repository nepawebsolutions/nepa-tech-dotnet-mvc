using Microsoft.EntityFrameworkCore.Migrations;

namespace NEPATechDotnetCoreMVC.Migrations
{
    public partial class changedtypeofuseruserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_MockUsers_UserId1",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserId1",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Skills",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Skills",
                newName: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserId1",
                table: "Skills",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_MockUsers_UserId1",
                table: "Skills",
                column: "UserId1",
                principalTable: "MockUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
