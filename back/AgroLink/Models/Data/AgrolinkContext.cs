using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgroLink.Models.Data;

public partial class AgrolinkContext : DbContext
{
    public AgrolinkContext()
    {
    }

    public AgrolinkContext(DbContextOptions<AgrolinkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TRole> TRoles { get; set; }

    public virtual DbSet<TSalarie> TSalaries { get; set; }

    public virtual DbSet<TService> TServices { get; set; }

    public virtual DbSet<TSite> TSites { get; set; }

    public virtual DbSet<TTypeSite> TTypeSites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AGROLINK;User ID=admin;Password=admin;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TRole>(entity =>
        {
            entity.ToTable("T_ROLES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nom)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("NOM");
        });

        modelBuilder.Entity<TSalarie>(entity =>
        {
            entity.ToTable("T_SALARIE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nom)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("NOM");
            entity.Property(e => e.Prenom)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("PRENOM");
            entity.Property(e => e.RefRole)
                .HasDefaultValueSql("((1))")
                .HasColumnName("REF_ROLE");
            entity.Property(e => e.RefService).HasColumnName("REF_SERVICE");
            entity.Property(e => e.RefSite).HasColumnName("REF_SITE");
            entity.Property(e => e.TelephoneFixe)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TELEPHONE_FIXE");
            entity.Property(e => e.TelephoneMobile)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TELEPHONE_MOBILE");

            entity.HasOne(d => d.RefRoleNavigation).WithMany(p => p.TSalaries)
                .HasForeignKey(d => d.RefRole)
                .HasConstraintName("FK_T_SALARIE_T_ROLES");

            entity.HasOne(d => d.RefServiceNavigation).WithMany(p => p.TSalaries)
                .HasForeignKey(d => d.RefService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_SALARIE_T_SERVICES");

            entity.HasOne(d => d.RefSiteNavigation).WithMany(p => p.TSalaries)
                .HasForeignKey(d => d.RefSite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_SALARIE_T_SITES");
        });

        modelBuilder.Entity<TService>(entity =>
        {
            entity.ToTable("T_SERVICES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nom)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("NOM");
        });

        modelBuilder.Entity<TSite>(entity =>
        {
            entity.ToTable("T_SITES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nom)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("NOM");
            entity.Property(e => e.RefType).HasColumnName("REF_TYPE");

            entity.HasOne(d => d.RefTypeNavigation).WithMany(p => p.TSites)
                .HasForeignKey(d => d.RefType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_SITES_T_TYPE_SITE");
        });

        modelBuilder.Entity<TTypeSite>(entity =>
        {
            entity.ToTable("T_TYPE_SITE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
