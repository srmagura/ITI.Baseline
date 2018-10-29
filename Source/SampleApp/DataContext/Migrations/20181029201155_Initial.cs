﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sequences");

            migrationBuilder.CreateSequence(
                name: "Default",
                schema: "sequences");

            migrationBuilder.CreateSequence(
                name: "OrderNumber",
                schema: "sequences",
                startValue: 10000L,
                incrementBy: 5);

            migrationBuilder.CreateTable(
                name: "AuditEntries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WhenUtc = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<string>(maxLength: 64, nullable: true),
                    UserName = table.Column<string>(maxLength: 64, nullable: true),
                    Aggregate = table.Column<string>(maxLength: 64, nullable: true),
                    AggregateId = table.Column<string>(maxLength: 64, nullable: true),
                    Entity = table.Column<string>(maxLength: 64, nullable: true),
                    EntityId = table.Column<string>(maxLength: 64, nullable: true),
                    Event = table.Column<string>(maxLength: 64, nullable: true),
                    Changes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailRecords",
                columns: table => new
                {
                    DateCreatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    SentUtc = table.Column<DateTimeOffset>(nullable: true),
                    ToAddress = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(maxLength: 512, nullable: true),
                    Body = table.Column<string>(nullable: true),
                    RetryCount = table.Column<int>(nullable: false),
                    NextRetryUtc = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    NotInEntity = table.Column<string>(maxLength: 64, nullable: true),
                    PersonName_Prefix = table.Column<string>(maxLength: 64, nullable: true),
                    PersonName_First = table.Column<string>(maxLength: 64, nullable: true),
                    PersonName_Middle = table.Column<string>(maxLength: 64, nullable: true),
                    PersonName_Last = table.Column<string>(maxLength: 64, nullable: true),
                    PhoneNumber_Value = table.Column<string>(maxLength: 16, nullable: true),
                    Address_Line1 = table.Column<string>(maxLength: 64, nullable: true),
                    Address_Line2 = table.Column<string>(maxLength: 64, nullable: true),
                    Address_City = table.Column<string>(maxLength: 64, nullable: true),
                    Address_State = table.Column<string>(maxLength: 16, nullable: true),
                    Address_Zip = table.Column<string>(maxLength: 16, nullable: true),
                    SomeInts = table.Column<string>(nullable: true),
                    SomeMoney = table.Column<decimal>(type: "Money", nullable: false),
                    SomeGuids = table.Column<string>(nullable: true),
                    SomeNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WhenUtc = table.Column<DateTimeOffset>(nullable: false),
                    Level = table.Column<string>(maxLength: 16, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    UserName = table.Column<string>(maxLength: 128, nullable: true),
                    Hostname = table.Column<string>(maxLength: 128, nullable: true),
                    Process = table.Column<string>(maxLength: 128, nullable: true),
                    Thread = table.Column<string>(maxLength: 128, nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsRecords",
                columns: table => new
                {
                    DateCreatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    SentUtc = table.Column<DateTimeOffset>(nullable: true),
                    ToAddress = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    RetryCount = table.Column<int>(nullable: false),
                    NextRetryUtc = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTracks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastAccessUtc = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    Service = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoiceRecords",
                columns: table => new
                {
                    DateCreatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    SentUtc = table.Column<DateTimeOffset>(nullable: true),
                    ToAddress = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    RetryCount = table.Column<int>(nullable: false),
                    NextRetryUtc = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    FooId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    NotInEntity = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bars_Foos_FooId",
                        column: x => x.FooId,
                        principalTable: "Foos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bars_FooId",
                table: "Bars",
                column: "FooId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEntries");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "EmailRecords");

            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.DropTable(
                name: "SmsRecords");

            migrationBuilder.DropTable(
                name: "UserTracks");

            migrationBuilder.DropTable(
                name: "VoiceRecords");

            migrationBuilder.DropTable(
                name: "Foos");

            migrationBuilder.DropSequence(
                name: "Default",
                schema: "sequences");

            migrationBuilder.DropSequence(
                name: "OrderNumber",
                schema: "sequences");
        }
    }
}
