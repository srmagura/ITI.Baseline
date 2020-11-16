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
    [Migration("20201116182234_Facilities")]
    partial class Facilities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ITI.Baseline.Audit.AuditRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aggregate")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Changes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset>("WhenUtc")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("AuditRecords");
                });

            modelBuilder.Entity("ITI.DDD.Logging.LogEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hostname")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Process")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Thread")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTimeOffset>("WhenUtc")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("WhenUtc");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("RequestTrace.DbRequestTrace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateBeginUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateEndUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Request")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Service", "Direction");

                    b.ToTable("RequestTraces");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreatedUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
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

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbFacility", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreatedUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbLtcPharmacy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreatedUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

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

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbFacility", b =>
                {
                    b.OwnsOne("TestApp.Domain.ValueObjects.FacilityContact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("DbFacilityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool?>("HasValue")
                                .HasColumnType("bit");

                            b1.HasKey("DbFacilityId");

                            b1.ToTable("Facilities");

                            b1.WithOwner()
                                .HasForeignKey("DbFacilityId");

                            b1.OwnsOne("ITI.Baseline.ValueObjects.EmailAddress", "Email", b2 =>
                                {
                                    b2.Property<Guid>("FacilityContactDbFacilityId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<bool?>("HasValue")
                                        .HasColumnType("bit");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(256)")
                                        .HasMaxLength(256);

                                    b2.HasKey("FacilityContactDbFacilityId");

                                    b2.ToTable("Facilities");

                                    b2.WithOwner()
                                        .HasForeignKey("FacilityContactDbFacilityId");
                                });

                            b1.OwnsOne("ITI.Baseline.ValueObjects.SimplePersonName", "Name", b2 =>
                                {
                                    b2.Property<Guid>("FacilityContactDbFacilityId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("First")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<bool?>("HasValue")
                                        .HasColumnType("bit");

                                    b2.Property<string>("Last")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("Middle")
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.Property<string>("Prefix")
                                        .HasColumnType("nvarchar(64)")
                                        .HasMaxLength(64);

                                    b2.HasKey("FacilityContactDbFacilityId");

                                    b2.ToTable("Facilities");

                                    b2.WithOwner()
                                        .HasForeignKey("FacilityContactDbFacilityId");
                                });
                        });
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbLtcPharmacy", b =>
                {
                    b.HasOne("TestApp.DataContext.DataModel.DbCustomer", "Customer")
                        .WithMany("LtcPharmacies")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
