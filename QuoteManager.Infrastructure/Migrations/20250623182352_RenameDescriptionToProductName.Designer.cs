﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuoteManager.Infrastructure.Data;

#nullable disable

namespace QuoteManager.Infrastructure.Migrations
{
    [DbContext(typeof(QuoteDbContext))]
    [Migration("20250623182352_RenameDescriptionToProductName")]
    partial class RenameDescriptionToProductName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuoteManager.Core.Entities.Quote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Sample Quote for Customer",
                            UserId = new Guid("22222222-2222-2222-2222-222222222222")
                        });
                });

            modelBuilder.Entity("QuoteManager.Core.Entities.QuoteItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("QuoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ResellerPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("QuoteId");

                    b.ToTable("QuoteItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            BasePrice = 100.00m,
                            ProductCode = "P001",
                            ProductName = "Sample Product 1",
                            Quantity = 2,
                            QuoteId = new Guid("33333333-3333-3333-3333-333333333333"),
                            ResellerPrice = 95.00m
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            BasePrice = 150.00m,
                            ProductCode = "P002",
                            ProductName = "Sample Product 2",
                            Quantity = 1,
                            QuoteId = new Guid("33333333-3333-3333-3333-333333333333"),
                            ResellerPrice = 140.00m
                        });
                });

            modelBuilder.Entity("QuoteManager.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Email = "admin@example.com",
                            PasswordHash = "AdminPassword",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            Email = "customer@example.com",
                            PasswordHash = "CustomerPassword",
                            Role = "Customer"
                        });
                });

            modelBuilder.Entity("QuoteManager.Core.Entities.Quote", b =>
                {
                    b.HasOne("QuoteManager.Core.Entities.User", "User")
                        .WithMany("Quotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuoteManager.Core.Entities.QuoteItem", b =>
                {
                    b.HasOne("QuoteManager.Core.Entities.Quote", "Quote")
                        .WithMany("Items")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("QuoteManager.Core.Entities.Quote", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("QuoteManager.Core.Entities.User", b =>
                {
                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
