using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace feliciano.PL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageNameToBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "blogs",
                newName: "ImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "blogs",
                newName: "Image");
        }
    }
}
