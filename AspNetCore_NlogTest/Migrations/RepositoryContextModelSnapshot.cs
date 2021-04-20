﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCore_NlogTest.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("666f89db-f6e6-42c5-ba84-f2e93a176544"),
                            AccountType = "网易",
                            DateCreated = new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(1979),
                            OwnerId = new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3")
                        },
                        new
                        {
                            AccountId = new Guid("6cb4b826-a441-450e-97fb-da3a66b9079d"),
                            AccountType = "腾讯",
                            DateCreated = new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(3385),
                            OwnerId = new Guid("be24d142-c750-4cee-90eb-2b99d942b33c")
                        },
                        new
                        {
                            AccountId = new Guid("626c5ff4-76b8-43a1-aa78-5f0b420097d2"),
                            AccountType = "京东",
                            DateCreated = new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(3428),
                            OwnerId = new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5")
                        },
                        new
                        {
                            AccountId = new Guid("53bd472c-69ae-453f-9b82-f3ff683c6391"),
                            AccountType = "CSDN",
                            DateCreated = new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(3432),
                            OwnerId = new Guid("54aeb677-a1fc-479f-b095-98476a027e6d")
                        });
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("OwnerId");

                    b.ToTable("Owner");

                    b.HasData(
                        new
                        {
                            OwnerId = new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3"),
                            Address = "河南",
                            DateOfBirth = new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Name1"
                        },
                        new
                        {
                            OwnerId = new Guid("be24d142-c750-4cee-90eb-2b99d942b33c"),
                            Address = "河北",
                            DateOfBirth = new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Name2"
                        },
                        new
                        {
                            OwnerId = new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5"),
                            Address = "湖南",
                            DateOfBirth = new DateTime(1992, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Name3"
                        },
                        new
                        {
                            OwnerId = new Guid("54aeb677-a1fc-479f-b095-98476a027e6d"),
                            Address = "湖北",
                            DateOfBirth = new DateTime(1991, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Name4"
                        });
                });

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.HasOne("Entities.Models.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}