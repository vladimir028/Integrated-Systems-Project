using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class relationChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfActivities",
                table: "PlannedRoutes");

            migrationBuilder.RenameColumn(
                name: "StartFrom",
                table: "PlannedRoutes",
                newName: "StartingTime");

            migrationBuilder.RenameColumn(
                name: "EndTo",
                table: "PlannedRoutes",
                newName: "EndingTime");

            migrationBuilder.AlterColumn<string>(
                name: "Activity",
                table: "PlannedRoutes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartingTime",
                table: "PlannedRoutes",
                newName: "StartFrom");

            migrationBuilder.RenameColumn(
                name: "EndingTime",
                table: "PlannedRoutes",
                newName: "EndTo");

            migrationBuilder.AlterColumn<int>(
                name: "Activity",
                table: "PlannedRoutes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfActivities",
                table: "PlannedRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
