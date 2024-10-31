using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace feliciano.PL.Data.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "blogs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad028007-49f3-49f9-bce1-a93697dad9a2", null, "Admin", "ADMIN" },
                    { "c2286333-8cb3-4569-a831-c438a7c9d14d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "176738b0-2dde-4e20-b89e-55c67f7579fb", 0, null, "28364e10-ad91-439c-8779-e60e260412fe", "ali@gmail.com", true, null, false, null, null, "ALI", "AQAAAAIAAYagAAAAEBwT0sMisPm4DuUW2PdELghH3Wo/FLsEXNvo2TWPAHUJ+MJlVIbKPK+hBt9kMMnE4g==", null, false, "18ae2231-39c8-4412-b30d-1a569b0ee61d", false, "Ali" },
                    { "954e2531-de05-476c-b7da-6e147b8a180a", 0, null, "b6af0750-2d6c-4720-bc74-181ec0aefb75", "Ahmad@gmail.com", true, null, false, null, null, "AHMAD", "AQAAAAIAAYagAAAAEMh7Ijk5VgZ8lkoKDau85HuIL5xm45VP87kYDf3qG+a4fepF0bQAlvNRVigMOLA3BQ==", null, false, "46cdc1c8-43b2-484c-91c2-317252045d27", false, "Ahmad" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c2286333-8cb3-4569-a831-c438a7c9d14d", "176738b0-2dde-4e20-b89e-55c67f7579fb" },
                    { "ad028007-49f3-49f9-bce1-a93697dad9a2", "954e2531-de05-476c-b7da-6e147b8a180a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c2286333-8cb3-4569-a831-c438a7c9d14d", "176738b0-2dde-4e20-b89e-55c67f7579fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad028007-49f3-49f9-bce1-a93697dad9a2", "954e2531-de05-476c-b7da-6e147b8a180a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad028007-49f3-49f9-bce1-a93697dad9a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2286333-8cb3-4569-a831-c438a7c9d14d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "176738b0-2dde-4e20-b89e-55c67f7579fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "954e2531-de05-476c-b7da-6e147b8a180a");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "blogs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
