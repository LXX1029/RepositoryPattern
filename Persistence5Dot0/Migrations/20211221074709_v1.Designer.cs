﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence5Dot0;

namespace Persistence5Dot0.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20211221074709_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.HasKey("AccountId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("9f4c21a5-6ec7-48d1-8984-d16e2eef229f"),
                            AccountType = "网易",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(4630),
                            OwnerId = new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3")
                        },
                        new
                        {
                            AccountId = new Guid("6ac4858f-6864-421b-8f87-279b27c86a3c"),
                            AccountType = "腾讯",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(5455),
                            OwnerId = new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3")
                        },
                        new
                        {
                            AccountId = new Guid("b180dfee-1ec4-49cd-b693-01071f982f84"),
                            AccountType = "京东",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(5468),
                            OwnerId = new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5")
                        },
                        new
                        {
                            AccountId = new Guid("2a337bed-3d8c-4bdf-86c1-80816906c061"),
                            AccountType = "CSDN",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(5472),
                            OwnerId = new Guid("54aeb677-a1fc-479f-b095-98476a027e6d")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.HasOne("Domain.Entities.Owner", null)
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
