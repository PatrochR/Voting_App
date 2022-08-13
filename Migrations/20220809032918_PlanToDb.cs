using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voting_App.Migrations
{
    public partial class PlanToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayTime",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PlanId",
                table: "Votes",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Plans_PlanId",
                table: "Votes",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Plans_PlanId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Votes_PlanId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "DayTime",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Votes");
        }
    }
}
