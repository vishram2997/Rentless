﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rentless.Models;

namespace Rentless.Migrations
{
    [DbContext(typeof(RentlessDBContext))]
    [Migration("20200106034549_StateCity2")]
    partial class StateCity2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rentless.Models.City", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Code");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateCode");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Rentless.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Rentless.Models.Currency", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Code");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Rentless.Models.State", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Code");

                    b.HasIndex("CountryId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Rentless.Models.City", b =>
                {
                    b.HasOne("Rentless.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Rentless.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateCode");
                });

            modelBuilder.Entity("Rentless.Models.Country", b =>
                {
                    b.HasOne("Rentless.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyCode");
                });

            modelBuilder.Entity("Rentless.Models.State", b =>
                {
                    b.HasOne("Rentless.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
