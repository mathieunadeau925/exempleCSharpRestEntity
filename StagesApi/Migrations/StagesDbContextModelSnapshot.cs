﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StagesApi;

namespace StagesApi.Migrations
{
    [DbContext(typeof(StagesDbContext))]
    partial class StagesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StagesApi.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ENTREPRISE");
                });

            modelBuilder.Entity("StagesApi.Programme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("PROGRAMME");
                });

            modelBuilder.Entity("StagesApi.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("date");

                    b.Property<int?>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Etat")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("NomPoste")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("ProgrammeId")
                        .HasColumnType("int");

                    b.Property<double?>("Salaire")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseId");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("STAGE");
                });

            modelBuilder.Entity("StagesApi.Stage", b =>
                {
                    b.HasOne("StagesApi.Entreprise", "Entreprise")
                        .WithMany("Stage")
                        .HasForeignKey("EntrepriseId")
                        .HasConstraintName("FK__STAGE__Entrepris__286302EC");

                    b.HasOne("StagesApi.Programme", "Programme")
                        .WithMany("Stage")
                        .HasForeignKey("ProgrammeId")
                        .HasConstraintName("FK__STAGE__Programme__29572725");
                });
#pragma warning restore 612, 618
        }
    }
}
