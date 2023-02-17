using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangProwess.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamespaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetEntity_UserEntity_OwnerId",
                table: "SetEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TermEntity_WordEntity_DefinitionId",
                table: "TermEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_WordEntity_SetEntity_SetId",
                table: "WordEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordEntity",
                table: "WordEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TermEntity",
                table: "TermEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetEntity",
                table: "SetEntity");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "WordEntity");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TermEntity");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "TermEntity");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "TermEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TermEntity");

            migrationBuilder.DropColumn(
                name: "DefinitionLanguage",
                table: "SetEntity");

            migrationBuilder.RenameTable(
                name: "WordEntity",
                newName: "Words");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TermEntity",
                newName: "Terms");

            migrationBuilder.RenameTable(
                name: "SetEntity",
                newName: "Sets");

            migrationBuilder.RenameIndex(
                name: "IX_WordEntity_SetId",
                table: "Words",
                newName: "IX_Words_SetId");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntity_Username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntity_PublicId",
                table: "Users",
                newName: "IX_Users_PublicId");

            migrationBuilder.RenameIndex(
                name: "IX_TermEntity_DefinitionId",
                table: "Terms",
                newName: "IX_Terms_DefinitionId");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Sets",
                newName: "LastWordIndex");

            migrationBuilder.RenameColumn(
                name: "MaxLength",
                table: "Sets",
                newName: "AnswersLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_SetEntity_OwnerId",
                table: "Sets",
                newName: "IX_Sets_OwnerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Words",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Words",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sets",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sets",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terms",
                table: "Terms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sets",
                table: "Sets",
                column: "Id");

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
                name: "IX_Sets_Name",
                table: "Sets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sets_PublicId",
                table: "Sets",
                column: "PublicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Users_OwnerId",
                table: "Sets",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Terms_Words_DefinitionId",
                table: "Terms",
                column: "DefinitionId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Sets_SetId",
                table: "Words",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Users_OwnerId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_Terms_Words_DefinitionId",
                table: "Terms");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Sets_SetId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_Name",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_PublicId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terms",
                table: "Terms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sets",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_Name",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_PublicId",
                table: "Sets");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "WordEntity");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "Terms",
                newName: "TermEntity");

            migrationBuilder.RenameTable(
                name: "Sets",
                newName: "SetEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Words_SetId",
                table: "WordEntity",
                newName: "IX_WordEntity_SetId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "UserEntity",
                newName: "IX_UserEntity_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PublicId",
                table: "UserEntity",
                newName: "IX_UserEntity_PublicId");

            migrationBuilder.RenameIndex(
                name: "IX_Terms_DefinitionId",
                table: "TermEntity",
                newName: "IX_TermEntity_DefinitionId");

            migrationBuilder.RenameColumn(
                name: "LastWordIndex",
                table: "SetEntity",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "AnswersLanguage",
                table: "SetEntity",
                newName: "MaxLength");

            migrationBuilder.RenameIndex(
                name: "IX_Sets_OwnerId",
                table: "SetEntity",
                newName: "IX_SetEntity_OwnerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "WordEntity",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WordEntity",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "WordEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "UserEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TermEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "TermEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PublicId",
                table: "TermEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "TermEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SetEntity",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SetEntity",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "DefinitionLanguage",
                table: "SetEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordEntity",
                table: "WordEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TermEntity",
                table: "TermEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetEntity",
                table: "SetEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetEntity_UserEntity_OwnerId",
                table: "SetEntity",
                column: "OwnerId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TermEntity_WordEntity_DefinitionId",
                table: "TermEntity",
                column: "DefinitionId",
                principalTable: "WordEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordEntity_SetEntity_SetId",
                table: "WordEntity",
                column: "SetId",
                principalTable: "SetEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
