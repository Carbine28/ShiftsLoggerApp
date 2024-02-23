using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftsLoggerApp.Migrations
{
    /// <inheritdoc />
    public partial class modifiednameonworkertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Workers_WorkerId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_WorkerId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Shifts");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId1",
                table: "Shifts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_WorkerId1",
                table: "Shifts",
                column: "WorkerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Workers_WorkerId1",
                table: "Shifts",
                column: "WorkerId1",
                principalTable: "Workers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Workers_WorkerId1",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_WorkerId1",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "WorkerId1",
                table: "Shifts");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Shifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_WorkerId",
                table: "Shifts",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Workers_WorkerId",
                table: "Shifts",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
