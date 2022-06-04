using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FamilyBudgetContext.Infrastructure.DataAccess.Migrations
{
    public partial class UpdateRoomToUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomToUserEntity",
                table: "RoomToUserEntity");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RoomToUserEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomToUserEntity",
                table: "RoomToUserEntity",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomToUserEntity",
                table: "RoomToUserEntity");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RoomToUserEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomToUserEntity",
                table: "RoomToUserEntity",
                columns: new[] { "RoomId", "UserId" });
        }
    }
}
