using Microsoft.EntityFrameworkCore.Migrations;

namespace QandA.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usrname",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Usrname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
