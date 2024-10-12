using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNSParser.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseItemEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "BaseItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "BaseItem",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "BaseItem");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "BaseItem");
        }
    }
}
