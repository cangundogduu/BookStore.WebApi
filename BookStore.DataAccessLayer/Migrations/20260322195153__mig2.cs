using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class _mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartegoryName",
                table: "Categories",
                newName: "CategoryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CartegoryName");
        }
    }
}
