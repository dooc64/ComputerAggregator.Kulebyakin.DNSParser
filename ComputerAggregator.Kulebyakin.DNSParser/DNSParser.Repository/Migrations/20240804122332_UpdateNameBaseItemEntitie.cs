using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNSParser.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameBaseItemEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUri",
                table: "BaseItem",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "BaseItem",
                newName: "ImageUri");
        }
    }
}
