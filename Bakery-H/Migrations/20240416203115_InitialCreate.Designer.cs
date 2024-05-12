﻿// <auto-generated />
using System;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bakery_H.Migrations
{
    [DbContext(typeof(BakeryDbContext))]
    [Migration("20240416203115_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bakery_Homework.Models.Angajati", b =>
                {
                    b.Property<int>("IdAngajat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAngajat"));

                    b.Property<int?>("ComandaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAngajarii")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FormulareAngajareId")
                        .HasColumnType("int");

                    b.Property<string>("Functie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocatieId")
                        .HasColumnType("int");

                    b.Property<string>("NumarTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAngajat");

                    b.HasIndex("FormulareAngajareId");

                    b.HasIndex("LocatieId");

                    b.ToTable("Angajati");
                });

            modelBuilder.Entity("Bakery_Homework.Models.Clienti", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("Bakery_Homework.Models.Comenzi", b =>
                {
                    b.Property<int>("IdComanda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComanda"));

                    b.Property<int>("AngajatId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataComanda")
                        .HasColumnType("datetime2");

                    b.Property<int>("MetodaPlataId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPlata")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdComanda");

                    b.HasIndex("AngajatId")
                        .IsUnique();

                    b.HasIndex("ClientId");

                    b.HasIndex("MetodaPlataId");

                    b.ToTable("Comenzi");
                });

            modelBuilder.Entity("Bakery_Homework.Models.FormulareAngajare", b =>
                {
                    b.Property<int>("IdFormular")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFormular"));

                    b.Property<int>("AngajatId")
                        .HasColumnType("int");

                    b.Property<string>("CV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNasterii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocatieId")
                        .HasColumnType("int");

                    b.Property<string>("NumarTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFormular");

                    b.HasIndex("AngajatId");

                    b.HasIndex("LocatieId");

                    b.ToTable("FormulareAngajare");
                });

            modelBuilder.Entity("Bakery_Homework.Models.Locatii", b =>
                {
                    b.Property<int>("IdLocatie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLocatie"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLocatie");

                    b.ToTable("Locatii");
                });

            modelBuilder.Entity("Bakery_Homework.Models.MetodePlata", b =>
                {
                    b.Property<int>("IdMetodaPlata")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMetodaPlata"));

                    b.Property<bool>("Card")
                        .HasColumnType("bit");

                    b.Property<bool>("Cash")
                        .HasColumnType("bit");

                    b.HasKey("IdMetodaPlata");

                    b.ToTable("MetodePlata");
                });

            modelBuilder.Entity("Bakery_Homework.Models.Produse", b =>
                {
                    b.Property<int>("IdProdus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProdus"));

                    b.Property<int>("Cantitate")
                        .HasColumnType("int");

                    b.Property<string>("Descriere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingrediente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProdus");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("Bakery_Homework.Models.Angajati", b =>
                {
                    b.HasOne("Bakery_Homework.Models.FormulareAngajare", "FormularAngajare")
                        .WithMany()
                        .HasForeignKey("FormulareAngajareId");

                    b.HasOne("Bakery_Homework.Models.Locatii", "Locatie")
                        .WithMany()
                        .HasForeignKey("LocatieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormularAngajare");

                    b.Navigation("Locatie");
                });

            modelBuilder.Entity("Bakery_Homework.Models.Comenzi", b =>
                {
                    b.HasOne("Bakery_Homework.Models.Angajati", "Angajat")
                        .WithOne("Comanda")
                        .HasForeignKey("Bakery_Homework.Models.Comenzi", "AngajatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bakery_Homework.Models.Clienti", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bakery_Homework.Models.MetodePlata", "MetodaPlata")
                        .WithMany()
                        .HasForeignKey("MetodaPlataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Angajat");

                    b.Navigation("Client");

                    b.Navigation("MetodaPlata");
                });

            modelBuilder.Entity("Bakery_Homework.Models.FormulareAngajare", b =>
                {
                    b.HasOne("Bakery_Homework.Models.Angajati", "Angajat")
                        .WithMany()
                        .HasForeignKey("AngajatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bakery_Homework.Models.Locatii", "Locatie")
                        .WithMany()
                        .HasForeignKey("LocatieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Angajat");

                    b.Navigation("Locatie");
                });

            modelBuilder.Entity("Bakery_Homework.Models.Angajati", b =>
                {
                    b.Navigation("Comanda");
                });
#pragma warning restore 612, 618
        }
    }
}
