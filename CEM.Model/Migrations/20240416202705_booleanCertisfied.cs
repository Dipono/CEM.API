using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEM.Model.Migrations
{
    /// <inheritdoc />
    public partial class booleanCertisfied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Satisfied",
                table: "Complains",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Satisfied",
                table: "Complains");
        }
    }
}
