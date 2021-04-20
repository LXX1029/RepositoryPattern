﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCore_NlogTest.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210416062021_AdditionalOwnerRowInserted")]
    partial class AdditionalOwnerRowInserted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            OwnerId = new Guid("54aeb677-a1fc-479f-b095-98476a027e6d"),
                            Address = "河南",
                            DateOfBirth = new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Name1"
                        },
                        new
                        {
                            OwnerId = new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3"),
                            Address = "河北",
                            DateOfBirth = new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Name2"
                        },
                        new
                        {
                            OwnerId = new Guid("be24d142-c750-4cee-90eb-2b99d942b33c"),
                            Address = "湖南",
                            DateOfBirth = new DateTime(1992, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Name3"
                        },
                        new
                        {
                            OwnerId = new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5"),
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