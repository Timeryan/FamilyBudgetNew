using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyBudgetContext.Infrastructure.DataAccess.Migrations
{
    public partial class UpdateRoomToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RoomToUserEntity_RoomId_UserId",
                table: "RoomToUserEntity",
                columns: new[] { "RoomId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomToUserEntity_RoomId_UserId",
                table: "RoomToUserEntity");
        }
    }
}
