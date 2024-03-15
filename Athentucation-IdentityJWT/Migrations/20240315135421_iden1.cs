using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athentucation_IdentityJWT.Migrations
{
    /// <inheritdoc />
    public partial class iden1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "careerlevel",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "job",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "loc",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceD",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceH",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ucando",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yearsofExperience",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "careerlevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "job",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "loc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "priceD",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "priceH",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ucando",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "yearsofExperience",
                table: "AspNetUsers");
        }
    }
}
