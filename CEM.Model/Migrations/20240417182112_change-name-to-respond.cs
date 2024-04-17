using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEM.Model.Migrations
{
    /// <inheritdoc />
    public partial class changenametorespond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User_Complains",
                newName: "Respond");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Respond",
                table: "User_Complains",
                newName: "Name");
        }
    }
}
