﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace RegistroPrestamosAp1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Ocupacion", b =>
                {
                    b.Property<int>("OcupacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Sueldo")
                        .HasColumnType("REAL");

                    b.HasKey("OcupacionID");

                    b.ToTable("Ocupacion");
                });

            modelBuilder.Entity("Persona", b =>
                {
                    b.Property<int>("PersonaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("OcupacionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonaID");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Prestamo", b =>
                {
                    b.Property<int>("PrestamoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("PersonaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly?>("Vence")
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoID");

                    b.HasIndex("PersonaID");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("Prestamo", b =>
                {
                    b.HasOne("Persona", null)
                        .WithMany("Prestamos")
                        .HasForeignKey("PersonaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Persona", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
