﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApp.DataContext;

namespace TestApp.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20201104235038_CustomerCollections")]
    partial class CustomerCollections
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreatedUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("NotInEntity")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("SomeInts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SomeMoney")
                        .HasColumnType("Money");

                    b.Property<long>("SomeNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbLtcPharmacy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreatedUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DbCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("DbCustomerId");

                    b.ToTable("LtcPharmacies");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbCustomer", b =>
                {
                    b.OwnsOne("ITI.Baseline.ValueObjects.PhoneNumber", "ContactPhone", b1 =>
                        {
                            b1.Property<Guid>("DbCustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool?>("HasValue")
                                .HasColumnType("bit");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(16)")
                                .HasMaxLength(16);

                            b1.HasKey("DbCustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("DbCustomerId");
                        });

                    b.OwnsOne("ITI.Baseline.ValueObjects.SimplePersonName", "ContactName", b1 =>
                        {
                            b1.Property<Guid>("DbCustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("First")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<bool?>("HasValue")
                                .HasColumnType("bit");

                            b1.Property<string>("Last")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Middle")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Prefix")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.HasKey("DbCustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("DbCustomerId");
                        });

                    b.OwnsOne("TestApp.Domain.ValueObjects.SimpleAddress", "Address", b1 =>
                        {
                            b1.Property<Guid>("DbCustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<bool?>("HasValue")
                                .HasColumnType("bit");

                            b1.Property<string>("Line1")
                                .IsRequired()
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(64)")
                                .HasMaxLength(64);

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(16)")
                                .HasMaxLength(16);

                            b1.Property<string>("Zip")
                                .IsRequired()
                                .HasColumnType("nvarchar(16)")
                                .HasMaxLength(16);

                            b1.HasKey("DbCustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("DbCustomerId");
                        });
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbLtcPharmacy", b =>
                {
                    b.HasOne("TestApp.DataContext.DataModel.DbCustomer", null)
                        .WithMany("LtcPharmacies")
                        .HasForeignKey("DbCustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
