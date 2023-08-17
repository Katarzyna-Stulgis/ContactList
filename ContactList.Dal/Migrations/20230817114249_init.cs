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
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categroies_CategoryId",
                        column: x => x.CategoryId,
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
                    ContactSubcategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_Contacts_Subcategories_ContactSubcategoryId",
                        column: x => x.ContactSubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id");
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
                    { new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"), "służbowy" },
                    { new Guid("354a9056-11d8-4af0-a53f-ca926ddb50c4"), "inny" },
                    { new Guid("bf40ad89-e377-4f85-b741-d972ba9bac1d"), "prywatny" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[] { new Guid("7d50c0d4-e000-414c-a598-21fdf64da5d0"), "user1@contactlistapp.com", "!@#Password123" });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "ContactCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("9008e373-b36c-4629-9c78-ec6603cf58e2"), new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"), new Guid("00000000-0000-0000-0000-000000000000"), "szef" },
                    { new Guid("d04e58e5-9371-440c-aa57-63001e72f390"), new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"), new Guid("00000000-0000-0000-0000-000000000000"), "klient" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "ContactCategoryId", "ContactSubcategoryId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("6d7175bb-1f73-4dc3-9f88-e6ba4af9cca3"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"), new Guid("d04e58e5-9371-440c-aa57-63001e72f390"), "adam.nowak@contactlistapp.com", "Adam", "Nowak", "987654321", new Guid("7d50c0d4-e000-414c-a598-21fdf64da5d0") },
                    { new Guid("fda3d2ef-1742-4c43-a45e-033b2e2a4404"), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"), new Guid("9008e373-b36c-4629-9c78-ec6603cf58e2"), "jan.kowalski@contactlistapp.com", "Jan", "Kowalski", "123456789", new Guid("7d50c0d4-e000-414c-a598-21fdf64da5d0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactCategoryId",
                table: "Contacts",
                column: "ContactCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactSubcategoryId",
                table: "Contacts",
                column: "ContactSubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");
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
