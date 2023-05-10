using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SentenceBuilderAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Words_WordTypeId",
                table: "Words",
                column: "WordTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordType_WordTypeId",
                table: "Words",
                column: "WordTypeId",
                principalTable: "WordType",
                principalColumn: "WordTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordType_WordTypeId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_WordTypeId",
                table: "Words");
        }
    }
}
