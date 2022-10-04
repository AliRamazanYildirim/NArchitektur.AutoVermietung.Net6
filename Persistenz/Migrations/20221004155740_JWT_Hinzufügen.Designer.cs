﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistenz.Kontexte;

#nullable disable

namespace Persistenz.Migrations
{
    [DbContext(typeof(BasisDbKontext))]
    [Migration("20221004155740_JWT_Hinzufügen")]
    partial class JWT_Hinzufügen
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Sicherheit.Einheiten.Benutzer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthentifizierungsArt")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NachName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswortHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswortSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("VorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benutzer");
                });

            modelBuilder.Entity("Core.Sicherheit.Einheiten.BenutzerOperationsAnspruch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BenutzerId")
                        .HasColumnType("int");

                    b.Property<int>("OperationsAnspruchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BenutzerId");

                    b.HasIndex("OperationsAnspruchId");

                    b.ToTable("BenutzerOperationsAnspruch");
                });

            modelBuilder.Entity("Core.Sicherheit.Einheiten.OperationsAnspruch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationsAnspruch");
                });

            modelBuilder.Entity("Core.Sicherheit.Einheiten.TokenAktualisieren", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Ablauf")
                        .HasColumnType("datetime2");

                    b.Property<int>("BenutzerId")
                        .HasColumnType("int");

                    b.Property<string>("ErsetztDurchToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Erstellt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErstelltVonIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrundWiderrufen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Widerrufen")
                        .HasColumnType("datetime2");

                    b.Property<string>("WiderrufenVonIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BenutzerId");

                    b.ToTable("TokenAktualisieren");
                });

            modelBuilder.Entity("Domain.Einheiten.Marke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Marken", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Porsche"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BMW"
                        });
                });

            modelBuilder.Entity("Domain.Einheiten.Modell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BildUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BildUrl");

                    b.Property<int>("MarkeId")
                        .HasColumnType("int")
                        .HasColumnName("MarkeId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<decimal>("TagesPreis")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TagesPreis");

                    b.HasKey("Id");

                    b.HasIndex("MarkeId");

                    b.ToTable("Modelle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BildUrl = "",
                            MarkeId = 1,
                            Name = "Panamera",
                            TagesPreis = 1000m
                        },
                        new
                        {
                            Id = 2,
                            BildUrl = "",
                            MarkeId = 2,
                            Name = "760 LI",
                            TagesPreis = 1100m
                        },
                        new
                        {
                            Id = 3,
                            BildUrl = "",
                            MarkeId = 1,
                            Name = "Cayenne",
                            TagesPreis = 1000m
                        });
                });

            modelBuilder.Entity("Core.Sicherheit.Einheiten.BenutzerOperationsAnspruch", b =>
                {
                    b.HasOne("Core.Sicherheit.Einheiten.Benutzer", "Benutzer")
                        .WithMany("BenutzerOperationsAnspruch")
                        .HasForeignKey("BenutzerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Sicherheit.Einheiten.OperationsAnspruch", "OperationsAnspruch")
                        .WithMany()
                        .HasForeignKey("OperationsAnspruchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benutzer");

                    b.Navigation("OperationsAnspruch");
                });

            modelBuilder.Entity("Core.Sicherheit.Einheiten.TokenAktualisieren", b =>
                {
                    b.HasOne("Core.Sicherheit.Einheiten.Benutzer", "Benutzer")
                        .WithMany("TokenAktualisieren")
                        .HasForeignKey("BenutzerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benutzer");
                });

            modelBuilder.Entity("Domain.Einheiten.Modell", b =>
                {
                    b.HasOne("Domain.Einheiten.Marke", "Marke")
                        .WithMany("Modelle")
                        .HasForeignKey("MarkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marke");
                });

            modelBuilder.Entity("Core.Sicherheit.Einheiten.Benutzer", b =>
                {
                    b.Navigation("BenutzerOperationsAnspruch");

                    b.Navigation("TokenAktualisieren");
                });

            modelBuilder.Entity("Domain.Einheiten.Marke", b =>
                {
                    b.Navigation("Modelle");
                });
#pragma warning restore 612, 618
        }
    }
}
