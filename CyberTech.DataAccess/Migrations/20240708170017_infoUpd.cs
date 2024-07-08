using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberTech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class infoUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MongoInfoPic",
                table: "InfoList");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "InfoList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "InfoList");

            migrationBuilder.AddColumn<int>(
                name: "MongoInfoPic",
                table: "InfoList",
                type: "int",
                nullable: true);
        }
    }
}
