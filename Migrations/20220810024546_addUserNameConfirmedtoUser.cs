using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voting_App.Migrations
{
    public partial class addUserNameConfirmedtoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNameConfirmed",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameConfirmed",
                table: "Users");
        }
    }
}
