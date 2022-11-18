﻿// <auto-generated />
using System;
using BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndAPI.Migrations
{
    [DbContext(typeof(NACNContext))]
    [Migration("20221116063954_NACN")]
    partial class NACN
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEndAPI.Models.Member", b =>
                {
                    b.Property<int>("IdMember")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMember"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ArtDiscipline")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Cellphone")
                        .HasColumnType("int");

                    b.Property<string>("Constituency")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Disability")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Employed")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("FinancialYear")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("IdMembertype")
                        .HasColumnType("int");

                    b.Property<string>("Idnumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IDNumber");

                    b.Property<string>("Learner")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("OrgasinationName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PaidMembership")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pensioner")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PhysicalAddress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PostalAddress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StageName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Telephone")
                        .HasColumnType("int");

                    b.Property<int?>("WorkNumber")
                        .HasColumnType("int");

                    b.Property<int?>("YearsInIndustry")
                        .HasColumnType("int");

                    b.HasKey("IdMember")
                        .HasName("PK__Member__570E7FF0CEB48EC9");

                    b.HasIndex("IdMembertype");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("BackEndAPI.Models.MemberType", b =>
                {
                    b.Property<int>("IdMembertype")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMembertype"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdMembertype")
                        .HasName("PK__MemberTy__945542D342B5ADED");

                    b.ToTable("MemberType", (string)null);
                });

            modelBuilder.Entity("BackEndAPI.Models.Member", b =>
                {
                    b.HasOne("BackEndAPI.Models.MemberType", "IdMembertypeNavigation")
                        .WithMany("Members")
                        .HasForeignKey("IdMembertype")
                        .HasConstraintName("FK__Member__IdMember__267ABA7A");

                    b.Navigation("IdMembertypeNavigation");
                });

            modelBuilder.Entity("BackEndAPI.Models.MemberType", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
