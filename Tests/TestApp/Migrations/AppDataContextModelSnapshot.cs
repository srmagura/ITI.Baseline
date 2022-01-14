﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApp.DataContext;

#nullable disable

namespace TestApp.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ITI.Baseline.Audit.AuditRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Aggregate")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Changes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("UserId")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("UserName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTimeOffset>("WhenUtc")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("Aggregate", "AggregateId");

                    b.HasIndex("Entity", "EntityId");

                    b.ToTable("AuditRecords");
                });

            modelBuilder.Entity("ITI.Baseline.RequestTracing.RequestTrace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("DateBeginUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateEndUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

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
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Service", "Direction");

                    b.ToTable("RequestTraces");
                });

            modelBuilder.Entity("ITI.DDD.Logging.LogEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hostname")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Level")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Process")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTimeOffset>("WhenUtc")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("WhenUtc");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreatedUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

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
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

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
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("LtcPharmacies");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreatedUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("Type");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbCustomerUser", b =>
                {
                    b.HasBaseType("TestApp.DataContext.DataModel.DbUser");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbOnCallUser", b =>
                {
                    b.HasBaseType("TestApp.DataContext.DataModel.DbUser");

                    b.Property<Guid>("OnCallProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbCustomer", b =>
                {
                    b.OwnsOne("ITI.Baseline.ValueObjects.PhoneNumber", "ContactPhone", b1 =>
                        {
                            b1.Property<Guid>("DbCustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)");

                            b1.HasKey("DbCustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("DbCustomerId");
                        });

                    b.OwnsOne("TestApp.Domain.ValueObjects.PersonName", "ContactName", b1 =>
                        {
                            b1.Property<Guid>("DbCustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("First")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("Last")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("Middle")
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.HasKey("DbCustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("DbCustomerId");
                        });

                    b.OwnsOne("TestApp.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("DbCustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("Line1")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("Line2")
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)");

                            b1.Property<string>("Zip")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)");

                            b1.HasKey("DbCustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("DbCustomerId");
                        });

                    b.Navigation("Address");

                    b.Navigation("ContactName");

                    b.Navigation("ContactPhone");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbFacility", b =>
                {
                    b.OwnsOne("TestApp.Domain.ValueObjects.FacilityContact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("DbFacilityId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("DbFacilityId");

                            b1.ToTable("Facilities");

                            b1.WithOwner()
                                .HasForeignKey("DbFacilityId");

                            b1.OwnsOne("ITI.Baseline.ValueObjects.EmailAddress", "Email", b2 =>
                                {
                                    b2.Property<Guid>("FacilityContactDbFacilityId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("nvarchar(256)");

                                    b2.HasKey("FacilityContactDbFacilityId");

                                    b2.ToTable("Facilities");

                                    b2.WithOwner()
                                        .HasForeignKey("FacilityContactDbFacilityId");
                                });

                            b1.OwnsOne("TestApp.Domain.ValueObjects.PersonName", "Name", b2 =>
                                {
                                    b2.Property<Guid>("FacilityContactDbFacilityId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("First")
                                        .IsRequired()
                                        .HasMaxLength(64)
                                        .HasColumnType("nvarchar(64)");

                                    b2.Property<string>("Last")
                                        .IsRequired()
                                        .HasMaxLength(64)
                                        .HasColumnType("nvarchar(64)");

                                    b2.Property<string>("Middle")
                                        .HasMaxLength(64)
                                        .HasColumnType("nvarchar(64)");

                                    b2.HasKey("FacilityContactDbFacilityId");

                                    b2.ToTable("Facilities");

                                    b2.WithOwner()
                                        .HasForeignKey("FacilityContactDbFacilityId");
                                });

                            b1.Navigation("Email");

                            b1.Navigation("Name");
                        });

                    b.Navigation("Contact")
                        .IsRequired();
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbLtcPharmacy", b =>
                {
                    b.HasOne("TestApp.DataContext.DataModel.DbCustomer", "Customer")
                        .WithMany("LtcPharmacies")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbUser", b =>
                {
                    b.OwnsOne("ITI.Baseline.ValueObjects.EmailAddress", "Email", b1 =>
                        {
                            b1.Property<Guid>("DbUserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("nvarchar(256)");

                            b1.HasKey("DbUserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("DbUserId");
                        });

                    b.Navigation("Email");
                });

            modelBuilder.Entity("TestApp.DataContext.DataModel.DbCustomer", b =>
                {
                    b.Navigation("LtcPharmacies");
                });
#pragma warning restore 612, 618
        }
    }
}
