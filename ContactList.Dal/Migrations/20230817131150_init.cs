using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactList.Dal.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categroies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categroies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categroies_ContactCategoryId",
                        column: x => x.ContactCategoryId,
                        principalTable: "Categroies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subcategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Categroies_ContactCategoryId",
                        column: x => x.ContactCategoryId,
                        principalTable: "Categroies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Contacts_ContactCategoryId",
                table: "Contacts",
                column: "ContactCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_ContactCategoryId",
                table: "Subcategories",
                column: "ContactCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categroies");
        }
    }
}
