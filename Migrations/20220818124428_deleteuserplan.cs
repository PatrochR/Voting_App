using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voting_App.Migrations
{
    public partial class deleteuserplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanToUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_UserId",
                table: "Plans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_UserId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_UserId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plans");

            migrationBuilder.CreateTable(
                name: "PlanToUsers",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanToUsers", x => new { x.PlanId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PlanToUsers_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanToUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanToUsers_UserId",
                table: "PlanToUsers",
                column: "UserId");
        }
    }
}
