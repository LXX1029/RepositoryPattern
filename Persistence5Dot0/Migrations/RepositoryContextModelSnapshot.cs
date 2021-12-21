﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence5Dot0;

namespace Persistence5Dot0.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("LastUpdatedTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.HasKey("AccountId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("6bb3c8c5-be24-4ceb-a864-0f53bd1048e4"),
                            AccountType = "网易",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(5973),
                            LastUpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3")
                        },
                        new
                        {
                            AccountId = new Guid("21a3abe5-1c6b-4d3d-aa12-15674b2a21b9"),
                            AccountType = "腾讯",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(6873),
                            LastUpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3")
                        },
                        new
                        {
                            AccountId = new Guid("4977fbec-11f1-4ddb-9bb7-2a2bf3c988b2"),
                            AccountType = "京东",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(6887),
                            LastUpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5")
                        },
                        new
                        {
                            AccountId = new Guid("d8ec6486-3dd6-4151-92fb-ed830b5575b2"),
                            AccountType = "CSDN",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(6918),
                            LastUpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
