using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dormitory.Migrations
{
    public partial class AddRoomFromAnnouncment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decpription",
                table: "Announcemnts",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Announcemnts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Announcemnts_RoomId",
                table: "Announcemnts",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Announcments",
                table: "Announcemnts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Announcments",
                table: "Announcemnts");

            migrationBuilder.DropIndex(
                name: "IX_Announcemnts_RoomId",
                table: "Announcemnts");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Announcemnts");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Announcemnts",
                newName: "Decpription");
        }
    }
}
