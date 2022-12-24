﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistance.DataContext;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(MyAppDbContext))]
    [Migration("20221221150405_NullableStatus")]
    partial class NullableStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Report", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uuid");

                    b.Property<int>("ReportType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("PublicId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Entities.Models.SupportRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IssueDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssueSubject")
                        .HasColumnType("text");

                    b.Property<int>("IssueType")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("StatusDetails")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UrgencyLevel")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SupportRequests");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2022, 12, 21, 17, 4, 4, 932, DateTimeKind.Local).AddTicks(4163),
                            DueDate = new DateTime(2022, 12, 21, 17, 4, 4, 932, DateTimeKind.Local).AddTicks(4069),
                            IssueDescription = "Some Issue",
                            IssueSubject = "Some connection problems",
                            IssueType = 1,
                            Status = 2,
                            StatusDetails = "Test Data",
                            UpdatedAt = new DateTime(2022, 12, 21, 17, 4, 4, 932, DateTimeKind.Local).AddTicks(4170),
                            UrgencyLevel = 2,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("Entities.Models.SupportRequestMessages", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("SupportRequestMessages");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3f590fb0-ec75-413e-aa23-7c7a52a464c7",
                            CreatedAt = new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2554),
                            Email = "adamson@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Adam",
                            LastName = "Adamson",
                            LockoutEnabled = false,
                            Password = "AQAAAAIAAYagAAAAEHI6caOBCPWJPhgaM2zpE5cVDJthp1X/3WqaPoh1GK9Si8V28vzHS0TNXoJFssokPA==",
                            PhoneNumberConfirmed = false,
                            Role = 2,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2625)
                        },
                        new
                        {
                            Id = 2L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "da07b5f4-61fc-4e7f-9c6f-421cb827ac1e",
                            CreatedAt = new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2638),
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Bob",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            Password = "AQAAAAIAAYagAAAAEGt8Lp/fDOWRjfECUS2pQRojIKvpnRdC0eok47YSppUlHlRDDLmQMgMIYmE+xKHZrA==",
                            PhoneNumberConfirmed = false,
                            Role = 1,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2022, 12, 21, 17, 4, 4, 670, DateTimeKind.Local).AddTicks(2644)
                        });
                });

            modelBuilder.Entity("Entities.Models.SupportRequest", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.SupportRequestMessages", b =>
                {
                    b.HasOne("Entities.Models.SupportRequest", "SupportRequest")
                        .WithMany("Messages")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SupportRequest");
                });

            modelBuilder.Entity("Entities.Models.SupportRequest", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}