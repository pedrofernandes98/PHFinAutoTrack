using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHFinAutoTrack.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterImagemLenght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imagem",
                table: "lancamentos",
                type: "VARCHAR(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imagem",
                table: "lancamentos",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)");
        }
    }
}
