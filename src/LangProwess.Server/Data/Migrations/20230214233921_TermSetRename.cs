using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangProwess.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class TermSetRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terms_Words_DefinitionId",
                table: "Terms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terms",
                table: "Terms");

            migrationBuilder.RenameTable(
                name: "Terms",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Terms_DefinitionId",
                table: "Answers",
                newName: "IX_Answers_DefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Words_DefinitionId",
                table: "Answers",
                column: "DefinitionId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Words_DefinitionId",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Terms");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_DefinitionId",
                table: "Terms",
                newName: "IX_Terms_DefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terms",
                table: "Terms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terms_Words_DefinitionId",
                table: "Terms",
                column: "DefinitionId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
