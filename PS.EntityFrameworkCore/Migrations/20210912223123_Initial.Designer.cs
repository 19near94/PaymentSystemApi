﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.EntityFrameworkCore;

namespace PS.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AcctDbContext))]
    [Migration("20210912223123_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PS.Domain.Entities.AcctBalance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Balance")
                        .HasColumnName("balance")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PS.Domain.Entities.AcctTransaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .HasColumnName("account_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcctBalanceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcctBalanceId");

                    b.ToTable("AccountTransaction");
                });

            modelBuilder.Entity("PS.Domain.Entities.AcctTransaction", b =>
                {
                    b.HasOne("PS.Domain.Entities.AcctBalance", null)
                        .WithMany("AcctTransactions")
                        .HasForeignKey("AcctBalanceId");
                });
#pragma warning restore 612, 618
        }
    }
}
