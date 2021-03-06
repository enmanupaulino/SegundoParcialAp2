﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SegundoParcial2.Data;

namespace SegundoParcial2.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("SegundoParcial2.Models.RegistroDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Problema")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegistroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Solucion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RegistroId");

                    b.ToTable("RegistroDetalle");
                });

            modelBuilder.Entity("SegundoParcial2.Models.Registros", b =>
                {
                    b.Property<int>("RegistroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Problema")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Solucion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RegistroId");

                    b.ToTable("registros");
                });

            modelBuilder.Entity("SegundoParcial2.Models.RegistroDetalle", b =>
                {
                    b.HasOne("SegundoParcial2.Models.Registros", null)
                        .WithMany("Detalle")
                        .HasForeignKey("RegistroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
