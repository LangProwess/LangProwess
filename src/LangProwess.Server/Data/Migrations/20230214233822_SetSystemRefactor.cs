using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangProwess.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetSystemRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Words",
                newName: "Progress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Progress",
                table: "Words",
                newName: "Value");
        }
    }
}
