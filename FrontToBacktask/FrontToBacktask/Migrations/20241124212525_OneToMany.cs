using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBacktask.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Works_ServiceId",
                table: "Works",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Services_ServiceId",
                table: "Works",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Services_ServiceId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_ServiceId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Works");
        }
    }
}
