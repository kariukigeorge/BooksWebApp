﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaterMS.Data;

namespace WaterMS.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WaterMS.Models.Books", b =>
                {
                    b.Property<string>("BooksID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("UsersID")
                        .HasColumnType("int");

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("date_deactivated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("deactivated_by")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("isbn_number")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("BooksID");

                    b.HasIndex("UsersID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("WaterMS.Models.Users", b =>
                {
                    b.Property<int>("UsersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("date_deleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("deleted_by")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsersID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WaterMS.Models.Books", b =>
                {
                    b.HasOne("WaterMS.Models.Users", "user")
                        .WithMany("Book")
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
