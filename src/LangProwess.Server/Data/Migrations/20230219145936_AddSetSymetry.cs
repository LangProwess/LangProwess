using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangProwess.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSetSymetry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Words_DefinitionId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.RenameColumn(
                name: "NameLanguage",
                table: "Sets",
                newName: "QueriesLanguage");

            migrationBuilder.RenameColumn(
                name: "DefinitionId",
                table: "Answers",
                newName: "ParentTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_DefinitionId",
                table: "Answers",
                newName: "IX_Answers_ParentTermId");

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublicId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Definition = table.Column<string>(type: "TEXT", nullable: true),
                    Pronounciation = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Progress = table.Column<int>(type: "INTEGER", nullable: false),
                    SetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentTermId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queries_Terms_ParentTermId",
                        column: x => x.ParentTermId,
                        principalTable: "Terms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Queries_ParentTermId",
                table: "Queries",
                column: "ParentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_PublicId",
                table: "Terms",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terms_SetId",
                table: "Terms",
                column: "SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Terms_ParentTermId",
                table: "Answers",
                column: "ParentTermId",
                principalTable: "Terms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Terms_ParentTermId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.RenameColumn(
                name: "QueriesLanguage",
                table: "Sets",
                newName: "NameLanguage");

            migrationBuilder.RenameColumn(
                name: "ParentTermId",
                table: "Answers",
                newName: "DefinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_ParentTermId",
                table: "Answers",
                newName: "IX_Answers_DefinitionId");

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SetId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Definition = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Progress = table.Column<int>(type: "INTEGER", nullable: false),
                    Pronounciation = table.Column<string>(type: "TEXT", nullable: true),
                    PublicId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_Name",
                table: "Words",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Words_PublicId",
                table: "Words",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_SetId",
                table: "Words",
                column: "SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Words_DefinitionId",
                table: "Answers",
                column: "DefinitionId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
