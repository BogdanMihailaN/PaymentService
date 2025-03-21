﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentService.Infrastructure;

#nullable disable

namespace PaymentService.Infrastructure.Migrations
{
    [DbContext(typeof(PaymentServiceDbContext))]
    [Migration("20250311140453_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaymentService.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("PaymentStatusId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100.00m,
                            Currency = "RON",
                            PaymentDate = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodId = 1,
                            PaymentStatusId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 200.00m,
                            Currency = "RON",
                            PaymentDate = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodId = 2,
                            PaymentStatusId = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("PaymentService.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Plată cu cardul de credit",
                            Name = "Credit Card"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Plată prin PayPal",
                            Name = "PayPal"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Plată prin transfer bancar",
                            Name = "Bank Transfer"
                        });
                });

            modelBuilder.Entity("PaymentService.Domain.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Completed"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Failed"
                        });
                });

            modelBuilder.Entity("PaymentService.Domain.Entities.Payment", b =>
                {
                    b.HasOne("PaymentService.Domain.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentService.Domain.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany()
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");

                    b.Navigation("PaymentStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
