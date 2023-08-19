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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subcategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_ContactCategoryId",
                        column: x => x.ContactCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Subcategories_Categories_ContactCategoryId",
                        column: x => x.ContactCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("223f0f2d-0710-437b-99ee-1d58fed2dfbd"), "służbowy" },
                    { new Guid("ae9518e2-8ea0-4e19-b48e-74e24d82e2b3"), "prywatny" },
                    { new Guid("d6957802-d1fb-4b26-a803-9800ec4493db"), "inny" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[] { new Guid("8d5e017e-3d11-4da2-84d9-7a2ee1abdb97"), "user1@contactlistapp.com", "!@#Password123" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "ContactCategoryId", "Email", "FirstName", "LastName", "PhoneNumber", "Subcategory" },
                values: new object[,]
                {
                    { new Guid("1cb0018f-f366-4a74-ace7-f16e7677cedd"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("223f0f2d-0710-437b-99ee-1d58fed2dfbd"), "adam.nowak@contactlistapp.com", "Adam", "Nowak", "987654321", "klient" },
                    { new Guid("7886d127-16d5-4461-8f41-7df16ba13c9f"), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("223f0f2d-0710-437b-99ee-1d58fed2dfbd"), "jan.kowalski@contactlistapp.com", "Jan", "Kowalski", "123456789", "szef" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "ContactCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("52cde201-6173-4a63-8d21-bfe77e1b45fd"), new Guid("223f0f2d-0710-437b-99ee-1d58fed2dfbd"), "klient" },
                    { new Guid("8c1b9e51-f251-4c53-94a5-054603da3ff1"), new Guid("223f0f2d-0710-437b-99ee-1d58fed2dfbd"), "szef" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactCategoryId",
                table: "Contacts",
                column: "ContactCategoryId");

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
                name: "Categories");
        }
    }
}
