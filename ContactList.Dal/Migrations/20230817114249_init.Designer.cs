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
    [Migration("20230817114249_init")]
    partial class init
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

                    b.Property<Guid?>("ContactSubcategoryId")
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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContactCategoryId");

                    b.HasIndex("ContactSubcategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fda3d2ef-1742-4c43-a45e-033b2e2a4404"),
                            BirthDate = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContactCategoryId = new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"),
                            ContactSubcategoryId = new Guid("9008e373-b36c-4629-9c78-ec6603cf58e2"),
                            Email = "jan.kowalski@contactlistapp.com",
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            PhoneNumber = "123456789",
                            UserId = new Guid("7d50c0d4-e000-414c-a598-21fdf64da5d0")
                        },
                        new
                        {
                            Id = new Guid("6d7175bb-1f73-4dc3-9f88-e6ba4af9cca3"),
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContactCategoryId = new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"),
                            ContactSubcategoryId = new Guid("d04e58e5-9371-440c-aa57-63001e72f390"),
                            Email = "adam.nowak@contactlistapp.com",
                            FirstName = "Adam",
                            LastName = "Nowak",
                            PhoneNumber = "987654321",
                            UserId = new Guid("7d50c0d4-e000-414c-a598-21fdf64da5d0")
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
                            Id = new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"),
                            Name = "służbowy"
                        },
                        new
                        {
                            Id = new Guid("bf40ad89-e377-4f85-b741-d972ba9bac1d"),
                            Name = "prywatny"
                        },
                        new
                        {
                            Id = new Guid("354a9056-11d8-4af0-a53f-ca926ddb50c4"),
                            Name = "inny"
                        });
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.ContactSubcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9008e373-b36c-4629-9c78-ec6603cf58e2"),
                            CategoryId = new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"),
                            ContactCategoryId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "szef"
                        },
                        new
                        {
                            Id = new Guid("d04e58e5-9371-440c-aa57-63001e72f390"),
                            CategoryId = new Guid("261ccb76-11de-4f45-a03a-bc66caa1853c"),
                            ContactCategoryId = new Guid("00000000-0000-0000-0000-000000000000"),
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
                            UserId = new Guid("7d50c0d4-e000-414c-a598-21fdf64da5d0"),
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

                    b.HasOne("ContactList.Domain.Models.Entities.ContactSubcategory", "Subcategory")
                        .WithMany()
                        .HasForeignKey("ContactSubcategoryId");

                    b.HasOne("ContactList.Domain.Models.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Subcategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.ContactSubcategory", b =>
                {
                    b.HasOne("ContactList.Domain.Models.Entities.ContactCategory", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.ContactCategory", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("ContactList.Domain.Models.Entities.User", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
