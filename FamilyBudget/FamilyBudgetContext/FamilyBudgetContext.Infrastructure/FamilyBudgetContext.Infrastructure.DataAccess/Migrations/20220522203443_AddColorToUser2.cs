using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyBudgetContext.Infrastructure.DataAccess.Migrations
{
    public partial class AddColorToUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserColor",
                table: "RoomToUserEntity",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserColor",
                table: "RoomToUserEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
