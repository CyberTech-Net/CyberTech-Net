using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GameImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MongoGameTypePic",
                table: "GameTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Founded",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInfo",
                table: "InfoList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "GameTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "GameTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "GameTypes");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "GameTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Founded",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInfo",
                table: "InfoList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "MongoGameTypePic",
                table: "GameTypes",
                type: "int",
                nullable: true);
        }
    }
}
