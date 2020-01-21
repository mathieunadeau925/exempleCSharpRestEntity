using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StagesApi
{
    public partial class StagesDbContext : DbContext
    {
        public StagesDbContext()
        {
        }

        public StagesDbContext(DbContextOptions<StagesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entreprise> Entreprise { get; set; }
        public virtual DbSet<Programme> Programme { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StagesDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.ToTable("ENTREPRISE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Programme>(entity =>
            {
                entity.ToTable("PROGRAMME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("STAGE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.Property(e => e.Etat)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomPoste)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Entreprise)
                    .WithMany(p => p.Stage)
                    .HasForeignKey(d => d.EntrepriseId)
                    .HasConstraintName("FK__STAGE__Entrepris__286302EC");

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.Stage)
                    .HasForeignKey(d => d.ProgrammeId)
                    .HasConstraintName("FK__STAGE__Programme__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
