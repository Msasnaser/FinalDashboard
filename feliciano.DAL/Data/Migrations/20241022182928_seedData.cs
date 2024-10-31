using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace feliciano.PL.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "891a0d82-a48f-4be3-b30e-82e720a4ab9c", null, "Admin", "ADMIN" },
                    { "f83b728e-dde1-484c-816a-8c4a8e913b7a", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "800a75af-e696-4192-881e-9dabf206c322", 0, null, "9fce61a2-0e98-4f8b-b03e-ac008e1dd990", "Ali@gmail.com", true, null, false, null, null, "ALI", "AQAAAAIAAYagAAAAEBTEgZ/hypCWRgWK90VC/xw3cv+FQidypw2hA/Tj0qi+fs6Ls9i7YNlEQSvkmLpBGQ==", null, false, "c6f1ed7b-32ad-403e-a6a9-0cf198af40b7", false, "Ali@gmail.com" },
                    { "e751b05a-339c-4bcc-b401-5a5c260bd095", 0, null, "67943e47-411e-4021-8901-b55a95b1fd88", "Ahmad@gmail.com", true, null, false, null, null, "AHMAD", "AQAAAAIAAYagAAAAEKQepqLa+s8k5f6uWObGr+o/7z3XyMG1asmvuFKOq1di+nA+5eOH2Jvkq09SajQB6g==", null, false, "390e14a2-34dc-4918-88f2-41dbc59de2a9", false, "Ahmad@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f83b728e-dde1-484c-816a-8c4a8e913b7a", "800a75af-e696-4192-881e-9dabf206c322" },
                    { "891a0d82-a48f-4be3-b30e-82e720a4ab9c", "e751b05a-339c-4bcc-b401-5a5c260bd095" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f83b728e-dde1-484c-816a-8c4a8e913b7a", "800a75af-e696-4192-881e-9dabf206c322" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "891a0d82-a48f-4be3-b30e-82e720a4ab9c", "e751b05a-339c-4bcc-b401-5a5c260bd095" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "891a0d82-a48f-4be3-b30e-82e720a4ab9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f83b728e-dde1-484c-816a-8c4a8e913b7a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "800a75af-e696-4192-881e-9dabf206c322");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e751b05a-339c-4bcc-b401-5a5c260bd095");

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
    }
}
