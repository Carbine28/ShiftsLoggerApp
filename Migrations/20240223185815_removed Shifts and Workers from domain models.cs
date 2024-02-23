using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftsLoggerApp.Migrations
{
    /// <inheritdoc />
    public partial class removedShiftsandWorkersfromdomainmodels : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Shifts",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Shifts");

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
