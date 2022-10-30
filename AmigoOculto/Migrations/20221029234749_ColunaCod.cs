using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmigoOculto.Migrations
{
    /// <inheritdoc />
    public partial class ColunaCod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "AspNetUsers");
        }
    }
}
