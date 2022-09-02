using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voting_App.Migrations
{
    public partial class changename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VoteData",
                table: "Votes",
                newName: "VoteDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VoteDate",
                table: "Votes",
                newName: "VoteData");
        }
    }
}
