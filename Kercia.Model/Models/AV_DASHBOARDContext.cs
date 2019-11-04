using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kercia.Model.Models
{
    public partial class AV_DASHBOARDContext : DbContext
    {
        public AV_DASHBOARDContext()
        {
        }

        public AV_DASHBOARDContext(DbContextOptions<AV_DASHBOARDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evenement> Evenement { get; set; }
        public virtual DbSet<Personne> Personne { get; set; }
        public virtual DbSet<Planning> Planning { get; set; }
        public virtual DbSet<PlanningDate> PlanningDate { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<TypeEvenement> TypeEvenement { get; set; }
        public virtual DbSet<TypePlanningDate> TypePlanningDate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AV_DASHBOARD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Evenement>(entity =>
            {
                entity.ToTable("EVENEMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contenu).HasColumnName("CONTENU").HasMaxLength(255);

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EstLu).HasColumnName("EST_LU");

                entity.Property(e => e.EstTraite).HasColumnName("EST_TRAITE");

                entity.Property(e => e.PersonneId).HasColumnName("Personne_Id");

                entity.Property(e => e.Resume).HasColumnName("RESUME");

                entity.Property(e => e.SessionId).HasColumnName("Session_Id");

                entity.Property(e => e.TypeEvenementId).HasColumnName("TypeEvenement_Id");

                entity.HasOne(d => d.Personne)
                    .WithMany(p => p.Evenements)
                    .HasForeignKey(d => d.PersonneId)
                    .HasConstraintName("FK_dbo.EVENEMENT_dbo.PERSONNE_Personne_Id");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Evenement)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_dbo.EVENEMENT_dbo.SESSION_Session_Id");

                entity.HasOne(d => d.TypeEvenement)
                    .WithMany(p => p.Evenement)
                    .HasForeignKey(d => d.TypeEvenementId)
                    .HasConstraintName("FK_dbo.EVENEMENT_dbo.TYPE_EVENEMENT_TypeEvenement_Id");
            });

            modelBuilder.Entity<Personne>(entity =>
            {
                entity.ToTable("PERSONNE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasColumnName("EMAIL");

                entity.Property(e => e.Nom).HasColumnName("NOM");

                entity.Property(e => e.Prenom).HasColumnName("PRENOM");

                entity.Property(e => e.Telephone).HasColumnName("TELEPHONE");

                entity.Property(e => e.Type).HasColumnName("TYPE");
            });

            modelBuilder.Entity<Planning>(entity =>
            {
                entity.ToTable("PLANNING");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Libelle).HasColumnName("LIBELLE");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Planning)
                    .HasForeignKey<Planning>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PLANNING_dbo.SESSION_ID");
            });

            modelBuilder.Entity<PlanningDate>(entity =>
            {
                entity.ToTable("PLANNING_DATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlanningId).HasColumnName("Planning_Id");

                entity.Property(e => e.TypePlanningDateId).HasColumnName("TypePlanningDate_Id");

                entity.HasOne(d => d.Planning)
                    .WithMany(p => p.PlanningDate)
                    .HasForeignKey(d => d.PlanningId)
                    .HasConstraintName("FK_dbo.PLANNING_DATE_dbo.PLANNING_Planning_Id");

                entity.HasOne(d => d.TypePlanningDate)
                    .WithMany(p => p.PlanningDate)
                    .HasForeignKey(d => d.TypePlanningDateId)
                    .HasConstraintName("FK_dbo.PLANNING_DATE_dbo.TYPE_PLANNING_DATE_TypePlanningDate_Id");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("SESSION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionARealiser).HasColumnName("ACTION_A_REALISER");

                entity.Property(e => e.Etat).HasColumnName("ETAT");

                entity.Property(e => e.Libelle).HasColumnName("LIBELLE");

                entity.Property(e => e.Url).HasColumnName("URL");
            });

            modelBuilder.Entity<SessionPersonnes>(entity =>
            {
                entity.HasKey(e => new { e.SessionId, e.PersonneId })
                    .HasName("PK_dbo.SessionPersonnes");

                entity.Property(e => e.SessionId).HasColumnName("Session_Id");

                entity.Property(e => e.PersonneId).HasColumnName("Personne_Id");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionPersonnes)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_dbo.SessionPersonnes_dbo.SESSION_Session_Id");
            });

            modelBuilder.Entity<TypeEvenement>(entity =>
            {
                entity.ToTable("TYPE_EVENEMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EstAction).HasColumnName("EST_ACTION");

                entity.Property(e => e.Libelle).HasColumnName("LIBELLE");
            });

            modelBuilder.Entity<TypePlanningDate>(entity =>
            {
                entity.ToTable("TYPE_PLANNING_DATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Libelle).HasColumnName("LIBELLE");

                entity.Property(e => e.ValeurAjouteeParDefaut).HasColumnName("VALEUR_AJOUTEE_PAR_DEFAUT");
            });
        }
    }
}
