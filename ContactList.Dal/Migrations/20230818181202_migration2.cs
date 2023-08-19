using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactList.Dal.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "Categroies",
                keyColumn: "Id",
                keyValue: new Guid("726bbd2b-a32c-43a3-bfbd-15a94eb21de3"));

            migrationBuilder.DeleteData(
                table: "Categroies",
                keyColumn: "Id",
                keyValue: new Guid("d7694440-7cb0-4b47-b653-77edb26f26b7"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("c7041a8b-6dfa-4b52-8afe-da1549a96b0d"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("fe3117ee-9f22-4bd3-9480-ab25c583aa42"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("1cdba565-646f-40d3-a66b-7502de2f2d09"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("d779bf0d-4579-4ed2-960b-6b17d215c3f8"));

            migrationBuilder.DeleteData(
                table: "Categroies",
                keyColumn: "Id",
                keyValue: new Guid("70a8f576-616e-44db-a4dc-b13134a8580b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("76dd46da-a95c-4c00-a151-960c6e1854cc"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.InsertData(
                table: "Categroies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"), "służbowy" },
                    { new Guid("d6b26ff3-a0fc-4558-818e-b3fd2987bcea"), "prywatny" },
                    { new Guid("f280441e-589c-4918-90ba-4cad76122ac5"), "inny" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[] { new Guid("e9bed892-40b1-412a-894a-9e3796a282aa"), "user1@contactlistapp.com", "!@#Password123" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "ContactCategoryId", "Email", "FirstName", "LastName", "PhoneNumber", "Subcategory" },
                values: new object[,]
                {
                    { new Guid("47740644-e8a6-4ca2-8eb2-0c752eb39bc8"), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"), "jan.kowalski@contactlistapp.com", "Jan", "Kowalski", "123456789", "szef" },
                    { new Guid("ff0fe9d5-3c6f-4b63-95be-8ac73a4b940f"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"), "adam.nowak@contactlistapp.com", "Adam", "Nowak", "987654321", "klient" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "ContactCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("368fa9f7-ae7a-4322-8c3f-64fdf2563b83"), new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"), "klient" },
                    { new Guid("76ba6fd3-0b1a-4dc3-855e-81ab5905d140"), new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"), "szef" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categroies",
                keyColumn: "Id",
                keyValue: new Guid("d6b26ff3-a0fc-4558-818e-b3fd2987bcea"));

            migrationBuilder.DeleteData(
                table: "Categroies",
                keyColumn: "Id",
                keyValue: new Guid("f280441e-589c-4918-90ba-4cad76122ac5"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("47740644-e8a6-4ca2-8eb2-0c752eb39bc8"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("ff0fe9d5-3c6f-4b63-95be-8ac73a4b940f"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("368fa9f7-ae7a-4322-8c3f-64fdf2563b83"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("76ba6fd3-0b1a-4dc3-855e-81ab5905d140"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e9bed892-40b1-412a-894a-9e3796a282aa"));

            migrationBuilder.DeleteData(
                table: "Categroies",
                keyColumn: "Id",
                keyValue: new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Categroies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("70a8f576-616e-44db-a4dc-b13134a8580b"), "służbowy" },
                    { new Guid("726bbd2b-a32c-43a3-bfbd-15a94eb21de3"), "prywatny" },
                    { new Guid("d7694440-7cb0-4b47-b653-77edb26f26b7"), "inny" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[] { new Guid("76dd46da-a95c-4c00-a151-960c6e1854cc"), "user1@contactlistapp.com", "!@#Password123" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "ContactCategoryId", "Email", "FirstName", "LastName", "PhoneNumber", "Subcategory", "UserId" },
                values: new object[,]
                {
                    { new Guid("c7041a8b-6dfa-4b52-8afe-da1549a96b0d"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70a8f576-616e-44db-a4dc-b13134a8580b"), "adam.nowak@contactlistapp.com", "Adam", "Nowak", "987654321", "klient", new Guid("76dd46da-a95c-4c00-a151-960c6e1854cc") },
                    { new Guid("fe3117ee-9f22-4bd3-9480-ab25c583aa42"), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70a8f576-616e-44db-a4dc-b13134a8580b"), "jan.kowalski@contactlistapp.com", "Jan", "Kowalski", "123456789", "szef", new Guid("76dd46da-a95c-4c00-a151-960c6e1854cc") }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "ContactCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("1cdba565-646f-40d3-a66b-7502de2f2d09"), new Guid("70a8f576-616e-44db-a4dc-b13134a8580b"), "szef" },
                    { new Guid("d779bf0d-4579-4ed2-960b-6b17d215c3f8"), new Guid("70a8f576-616e-44db-a4dc-b13134a8580b"), "klient" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
