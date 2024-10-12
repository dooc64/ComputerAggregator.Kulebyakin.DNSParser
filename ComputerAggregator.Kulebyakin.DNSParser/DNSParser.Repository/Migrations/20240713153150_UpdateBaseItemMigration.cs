using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNSParser.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "BaseItem",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uri",
                table: "BaseItem");
        }
    }
}
