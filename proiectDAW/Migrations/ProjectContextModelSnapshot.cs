﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proiectDAW.Data;

namespace proiectDAW.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("proiectDAW.Models.Many_To_Many.Reactie_Reteta", b =>
                {
                    b.Property<Guid>("RetetaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UtilizatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reactie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RetetaId", "UtilizatorId");

                    b.HasIndex("UtilizatorId");

                    b.ToTable("Reactii_Retete");
                });

            modelBuilder.Entity("proiectDAW.Models.Many_To_Many.Reteta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BucatarieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cale_Poza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ColectieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Ingrediente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructiuni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Participa_Concurs")
                        .HasColumnType("bit");

                    b.Property<string>("Titlu_Reteta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BucatarieId");

                    b.HasIndex("ColectieId");

                    b.ToTable("Retete");
                });

            modelBuilder.Entity("proiectDAW.Models.One_To_Many.Bucatarie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriere_Bucatarie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume_Bucatarie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regiune_Glob")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bucatarii");
                });

            modelBuilder.Entity("proiectDAW.Models.One_To_Many.Colectie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cale_Poza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriere_Colectie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Publica")
                        .HasColumnType("bit");

                    b.Property<string>("Titlu_Colectie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UtilizatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UtilizatorId");

                    b.ToTable("Colectii");
                });

            modelBuilder.Entity("proiectDAW.Models.One_To_Many.Concurs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BucatarieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data_Inceput")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Sfarsit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Nume_Castigator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puncte_Oferite")
                        .HasColumnType("int");

                    b.Property<string>("Stadiu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titlu_Concurs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BucatarieId");

                    b.ToTable("Concursuri");
                });

            modelBuilder.Entity("proiectDAW.Models.One_To_One.Date_Personale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tara_Origine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Date_Personale");
                });

            modelBuilder.Entity("proiectDAW.Models.Utilizator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Date_PersonaleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nume_Utilizator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume_Utilizator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Puncte")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Date_PersonaleId")
                        .IsUnique();

                    b.ToTable("Utilizatori");
                });

            modelBuilder.Entity("proiectDAW.Models.Many_To_Many.Reactie_Reteta", b =>
                {
                    b.HasOne("proiectDAW.Models.Many_To_Many.Reteta", "Reteta")
                        .WithMany("Reactii_Retete")
                        .HasForeignKey("RetetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proiectDAW.Models.Utilizator", "Utilizator")
                        .WithMany("Reactii_Retete")
                        .HasForeignKey("UtilizatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proiectDAW.Models.Many_To_Many.Reteta", b =>
                {
                    b.HasOne("proiectDAW.Models.One_To_Many.Bucatarie", "Bucatarie")
                        .WithMany("Retete")
                        .HasForeignKey("BucatarieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proiectDAW.Models.One_To_Many.Colectie", "Colectie")
                        .WithMany("Retete")
                        .HasForeignKey("ColectieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proiectDAW.Models.One_To_Many.Colectie", b =>
                {
                    b.HasOne("proiectDAW.Models.Utilizator", "Utilizator")
                        .WithMany("Colectii")
                        .HasForeignKey("UtilizatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proiectDAW.Models.One_To_Many.Concurs", b =>
                {
                    b.HasOne("proiectDAW.Models.One_To_Many.Bucatarie", "Bucatarie")
                        .WithMany("Concursuri")
                        .HasForeignKey("BucatarieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proiectDAW.Models.Utilizator", b =>
                {
                    b.HasOne("proiectDAW.Models.One_To_One.Date_Personale", "Date_Personale")
                        .WithOne("Utilizator")
                        .HasForeignKey("proiectDAW.Models.Utilizator", "Date_PersonaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
