using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveDeduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LeaveDeduction",
                table: "Attendances",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveDeduction",
                table: "Attendances");
        }
    }
}
