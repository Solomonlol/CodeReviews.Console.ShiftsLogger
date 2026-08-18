using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftLogger.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUsersToEmpoyee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Shifts");

            migrationBuilder.RenameColumn(
                name: "UserIdentificationNumber",
                table: "Users",
                newName: "EmployeeNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserIdentificationNumber",
                table: "Users",
                newName: "IX_Users_EmployeeNumber");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnded",
                table: "Shifts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnded",
                table: "Shifts");

            migrationBuilder.RenameColumn(
                name: "EmployeeNumber",
                table: "Users",
                newName: "UserIdentificationNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EmployeeNumber",
                table: "Users",
                newName: "IX_Users_UserIdentificationNumber");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Shifts",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
