﻿// <auto-generated />
using System;
using AirportServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirportServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240312194950_UsingNextLegAttempt2")]
    partial class UsingNextLegAttempt2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirportServer.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LegId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("LegId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirportServer.Models.Leg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CrossingTime")
                        .HasColumnType("int");

                    b.Property<int?>("LegId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LegId");

                    b.ToTable("Legs");
                });

            modelBuilder.Entity("AirportServer.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<DateTime>("In")
                        .HasColumnType("datetime2");

                    b.Property<int>("LegId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Out")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("LegId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("AirportServer.Models.NextLeg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LegId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LegId");

                    b.ToTable("NextLeg");
                });

            modelBuilder.Entity("AirportServer.Models.Flight", b =>
                {
                    b.HasOne("AirportServer.Models.Leg", "Leg")
                        .WithMany()
                        .HasForeignKey("LegId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leg");
                });

            modelBuilder.Entity("AirportServer.Models.Leg", b =>
                {
                    b.HasOne("AirportServer.Models.Leg", null)
                        .WithMany("NextLegs")
                        .HasForeignKey("LegId");
                });

            modelBuilder.Entity("AirportServer.Models.Log", b =>
                {
                    b.HasOne("AirportServer.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportServer.Models.Leg", "Leg")
                        .WithMany()
                        .HasForeignKey("LegId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Leg");
                });

            modelBuilder.Entity("AirportServer.Models.NextLeg", b =>
                {
                    b.HasOne("AirportServer.Models.Leg", "Leg")
                        .WithMany()
                        .HasForeignKey("LegId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leg");
                });

            modelBuilder.Entity("AirportServer.Models.Leg", b =>
                {
                    b.Navigation("NextLegs");
                });
#pragma warning restore 612, 618
        }
    }
}
