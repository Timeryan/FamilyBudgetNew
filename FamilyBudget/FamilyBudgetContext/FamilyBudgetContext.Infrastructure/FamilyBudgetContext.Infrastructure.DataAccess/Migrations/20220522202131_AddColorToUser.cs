using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyBudgetContext.Infrastructure.DataAccess.Migrations
{
    public partial class AddColorToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserColor",
                table: "RoomToUserEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserColor",
                table: "RoomToUserEntity");
        }
    }
}
