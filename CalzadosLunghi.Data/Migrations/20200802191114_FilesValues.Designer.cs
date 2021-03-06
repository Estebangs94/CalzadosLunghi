﻿// <auto-generated />
using System;
using CalzadosLunghi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalzadosLunghi.Data.Migrations
{
    [DbContext(typeof(CalzadosLunghiDbContext))]
    [Migration("20200802191114_FilesValues")]
    partial class FilesValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalzadosLunghi.Entities.Color", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MaterialId");

                    b.ToTable("Colores");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.FileValues", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FilesValues");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadDeMedida")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipoMaterialId");

                    b.ToTable("Materiales");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.ParteZapato", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<bool>("FormadoPorMultipleMateriales")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ParteZapatos");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.PrecioMaterial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVigencia")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MaterialId");

                    b.ToTable("PrecioMateriales");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.Temporada", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<int>("TemporadaActual")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Temporadas");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.TipoMaterial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipoMateriales");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.Zapato", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<int>("TemporadaId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TemporadaId");

                    b.ToTable("Zapatos");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.ZapatoMaterial", b =>
                {
                    b.Property<int>("ZapatoId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadZapatosPorUnidad")
                        .HasColumnType("int");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<int>("ParteZapatoId")
                        .HasColumnType("int");

                    b.HasKey("ZapatoId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ParteZapatoId");

                    b.ToTable("ZapatoMaterial");
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.Color", b =>
                {
                    b.HasOne("CalzadosLunghi.Entities.Material", "Material")
                        .WithMany("Colores")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.Material", b =>
                {
                    b.HasOne("CalzadosLunghi.Entities.TipoMaterial", "TipoMaterial")
                        .WithMany()
                        .HasForeignKey("TipoMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.PrecioMaterial", b =>
                {
                    b.HasOne("CalzadosLunghi.Entities.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.Zapato", b =>
                {
                    b.HasOne("CalzadosLunghi.Entities.Temporada", "Temporada")
                        .WithMany("Zapatos")
                        .HasForeignKey("TemporadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalzadosLunghi.Entities.ZapatoMaterial", b =>
                {
                    b.HasOne("CalzadosLunghi.Entities.Material", "Material")
                        .WithMany("ZapatoMateriales")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalzadosLunghi.Entities.ParteZapato", "ParteZapato")
                        .WithMany()
                        .HasForeignKey("ParteZapatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalzadosLunghi.Entities.Zapato", "Zapato")
                        .WithMany("ListaZapatoMateriales")
                        .HasForeignKey("ZapatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
