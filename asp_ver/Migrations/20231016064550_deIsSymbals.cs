using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_ve.Migrations
{
    /// <inheritdoc />
    public partial class deIsSymbals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCymbals",
                table: "Entries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCymbals",
                table: "Entries",
                type: "INTEGER",
                nullable: true);
        }
    }
}
