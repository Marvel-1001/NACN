using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEndAPI.Models
{
    public partial class NACNContext : DbContext
    {
        public NACNContext()
        {
        }

        public NACNContext(DbContextOptions<NACNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberType> MemberTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.IdMember)
                    .HasName("PK__Member__570E7FF0CEB48EC9");

                entity.ToTable("Member");

                entity.Property(e => e.ArtDiscipline)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Constituency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Disability)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Employed)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FinancialYear).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idnumber).HasColumnName("IDNumber");

                entity.Property(e => e.Learner)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrgasinationName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PaidMembership)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pensioner)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StageName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMembertypeNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.IdMembertype)
                    .HasConstraintName("FK__Member__IdMember__267ABA7A");
            });

            modelBuilder.Entity<MemberType>(entity =>
            {
                entity.HasKey(e => e.IdMembertype)
                    .HasName("PK__MemberTy__945542D342B5ADED");

                entity.ToTable("MemberType");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
