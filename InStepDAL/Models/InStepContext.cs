using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InStepDAL.Models;

public partial class InStepContext : DbContext
{
    public InStepContext()
    {
    }

    public InStepContext(DbContextOptions<InStepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CandidateDetail> CandidateDetails { get; set; }

    public virtual DbSet<CandidatePreference> CandidatePreferences { get; set; }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<InternDetail> InternDetails { get; set; }

    public virtual DbSet<MentorDetail> MentorDetails { get; set; }

    public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UH5VOPT;Database=InStep;user id=sa;password=Teju@04;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateDetail>(entity =>
        {
            entity.HasKey(e => e.CandidateId).HasName("PK__Candidat__DF539B9CD742293E");

            entity.HasIndex(e => e.EmailId, "UQ__Candidat__7ED91ACEF83FB079").IsUnique();

            entity.Property(e => e.AvailableStart).HasColumnType("date");
            entity.Property(e => e.Cgpa).HasColumnType("decimal(6, 3)");
            entity.Property(e => e.Course)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Degree)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Resume).HasColumnName("resume");
            entity.Property(e => e.Skills)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UniversityName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CandidatePreference>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Candidate).WithMany()
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidate__Candi__4D94879B");

            entity.HasOne(d => d.ProjectCodeNavigation).WithMany()
                .HasForeignKey(d => d.ProjectCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidate__Proje__4E88ABD4");
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.ClaimId).HasName("PK__Claims__EF2E139B0A65C170");

            entity.Property(e => e.ClaimName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ClaimType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Intern).WithMany(p => p.Claims)
                .HasForeignKey(d => d.InternId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Claims__InternId__59FA5E80");
        });

        modelBuilder.Entity<InternDetail>(entity =>
        {
            entity.HasKey(e => e.InternId).HasName("PK__InternDe__6910EDE256DC1BF4");

            entity.HasIndex(e => e.EmailId, "UQ__InternDe__7ED91ACED66424C2").IsUnique();

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Mentor).WithMany(p => p.InternDetails)
                .HasForeignKey(d => d.MentorId)
                .HasConstraintName("FK__InternDet__Mento__5629CD9C");

            entity.HasOne(d => d.ProjectCodeNavigation).WithMany(p => p.InternDetails)
                .HasForeignKey(d => d.ProjectCode)
                .HasConstraintName("FK__InternDet__Proje__571DF1D5");
        });

        modelBuilder.Entity<MentorDetail>(entity =>
        {
            entity.HasKey(e => e.MentorId).HasName("PK__MentorDe__053B7E98EA1BF843");

            entity.HasIndex(e => e.EmailId, "UQ__MentorDe__7ED91ACE4EE076B1").IsUnique();

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.ProjectCodeNavigation).WithMany(p => p.MentorDetails)
                .HasForeignKey(d => d.ProjectCode)
                .HasConstraintName("FK__MentorDet__Proje__52593CB8");
        });

        modelBuilder.Entity<ProjectDetail>(entity =>
        {
            entity.HasKey(e => e.ProjectCode).HasName("PK__ProjectD__2F3A4949E7B57F45");

            entity.Property(e => e.Details)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TechnologyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
