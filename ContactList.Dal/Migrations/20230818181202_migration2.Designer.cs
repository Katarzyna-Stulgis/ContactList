﻿// <auto-generated />
using System;
using ContactList.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactList.Dal.Migrations
{
    [DbContext(typeof(ContactlistDbContext))]
    [Migration("20230818181202_migration2")]
    partial class migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactList.Domain.Models.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ContactCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subcategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactCategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("47740644-e8a6-4ca2-8eb2-0c752eb39bc8"),
                            BirthDate = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContactCategoryId = new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"),
                            Email = "jan.kowalski@contactlistapp.com",
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            PhoneNumber = "123456789",
                            Subcategory = "szef"
                        },
                        new
                        {
                            Id = new Guid("ff0fe9d5-3c6f-4b63-95be-8ac73a4b940f"),
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContactCategoryId = new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"),
                            Email = "adam.nowak@contactlistapp.com",
                            FirstName = "Adam",
                            LastName = "Nowak",
                            PhoneNumber = "987654321",
                            Subcategory = "klient"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.ContactCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categroies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"),
                            Name = "służbowy"
                        },
                        new
                        {
                            Id = new Guid("d6b26ff3-a0fc-4558-818e-b3fd2987bcea"),
                            Name = "prywatny"
                        },
                        new
                        {
                            Id = new Guid("f280441e-589c-4918-90ba-4cad76122ac5"),
                            Name = "inny"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.ContactSubcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactCategoryId");

                    b.ToTable("Subcategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("76ba6fd3-0b1a-4dc3-855e-81ab5905d140"),
                            ContactCategoryId = new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"),
                            Name = "szef"
                        },
                        new
                        {
                            Id = new Guid("368fa9f7-ae7a-4322-8c3f-64fdf2563b83"),
                            ContactCategoryId = new Guid("43c9ffea-48a2-4fbb-8eb0-672b74e30486"),
                            Name = "klient"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e9bed892-40b1-412a-894a-9e3796a282aa"),
                            Email = "user1@contactlistapp.com",
                            Password = "!@#Password123"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.Contact", b =>
                {
                    b.HasOne("ContactList.Domain.Models.Entities.ContactCategory", "Category")
                        .WithMany("Contacts")
                        .HasForeignKey("ContactCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.ContactSubcategory", b =>
                {
                    b.HasOne("ContactList.Domain.Models.Entities.ContactCategory", "ContactCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ContactCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactCategory");
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.ContactCategory", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Subcategories");
                });
#pragma warning restore 612, 618
        }
    }
}
