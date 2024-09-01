﻿// <auto-generated />
using System;
using CertExBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CertExBackend.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CertExBackend.Model.CategoryTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryTagName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CategoryTags");
                });

            modelBuilder.Entity("CertExBackend.Model.CertificationExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CertificationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("CostInr")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CostUsd")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("NominationCloseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("NominationOpenDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NominationStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("OfficialLink")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<int>("Views")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("CertificationExams");
                });

            modelBuilder.Entity("CertExBackend.Model.CertificationProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CertificationProviders");
                });

            modelBuilder.Entity("CertExBackend.Model.CertificationTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryTagId")
                        .HasColumnType("integer");

                    b.Property<int>("CertificationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryTagId");

                    b.HasIndex("CertificationId");

                    b.ToTable("CertificationTags");
                });

            modelBuilder.Entity("CertExBackend.Model.CriticalCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CertificationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("FinancialYearId")
                        .HasColumnType("integer");

                    b.Property<int>("RequiredCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CertificationId");

                    b.HasIndex("FinancialYearId");

                    b.ToTable("CriticalCertifications");
                });

            modelBuilder.Entity("CertExBackend.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentHeadId")
                        .HasColumnType("integer");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentHeadId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CertExBackend.Model.ExamDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CostInrWithTax")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CostInrWithoutTax")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("InvoiceNumber")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("InvoiceUrl")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("MyCertificationId")
                        .HasColumnType("integer");

                    b.Property<int>("NominationId")
                        .HasColumnType("integer");

                    b.Property<string>("ReimbursementStatus")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("SkillMatrixStatus")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("UploadCertificateStatus")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("MyCertificationId");

                    b.HasIndex("NominationId")
                        .IsUnique();

                    b.ToTable("ExamDetails");
                });

            modelBuilder.Entity("CertExBackend.Model.FinancialYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FinancialYears");
                });

            modelBuilder.Entity("CertExBackend.Model.MyCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Credentials")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.ToTable("MyCertifications");
                });

            modelBuilder.Entity("CertExBackend.Model.Nomination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CertificationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("DepartmentHeadRemarks")
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ExamDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ExamStatus")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<bool>("IsDepartmentApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLndApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("LndRemarks")
                        .HasColumnType("text");

                    b.Property<string>("ManagerRecommendation")
                        .HasColumnType("text");

                    b.Property<string>("ManagerRemarks")
                        .HasColumnType("text");

                    b.Property<string>("MotivationDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NominationStatus")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("PlannedExamMonth")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CertificationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Nominations");
                });

            modelBuilder.Entity("CertExBackend.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AWSAdminRemarks")
                        .HasColumnType("text");

                    b.Property<string>("AWSCredentials")
                        .HasColumnType("text");

                    b.Property<int>("AppRoleId")
                        .HasColumnType("integer");

                    b.Property<bool>("AwsAccountActive")
                        .HasColumnType("boolean");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Designation")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDepartmentHead")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsManager")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("integer");

                    b.Property<string>("SSOEmployeeId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("AppRoleId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ManagerId");

                    b.HasIndex("SSOEmployeeId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CertExBackend.Model.CertificationExam", b =>
                {
                    b.HasOne("CertExBackend.Model.CertificationProvider", "CertificationProvider")
                        .WithMany("CertificationExams")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CertificationProvider");
                });

            modelBuilder.Entity("CertExBackend.Model.CertificationTag", b =>
                {
                    b.HasOne("CertExBackend.Model.CategoryTag", "CategoryTag")
                        .WithMany("CertificationTags")
                        .HasForeignKey("CategoryTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CertExBackend.Model.CertificationExam", "CertificationExam")
                        .WithMany("CertificationTags")
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryTag");

                    b.Navigation("CertificationExam");
                });

            modelBuilder.Entity("CertExBackend.Model.CriticalCertification", b =>
                {
                    b.HasOne("CertExBackend.Model.CertificationExam", "CertificationExam")
                        .WithMany()
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CertExBackend.Model.FinancialYear", "FinancialYear")
                        .WithMany("CriticalCertifications")
                        .HasForeignKey("FinancialYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CertificationExam");

                    b.Navigation("FinancialYear");
                });

            modelBuilder.Entity("CertExBackend.Model.Department", b =>
                {
                    b.HasOne("Employee", "DepartmentHead")
                        .WithMany()
                        .HasForeignKey("DepartmentHeadId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DepartmentHead");
                });

            modelBuilder.Entity("CertExBackend.Model.ExamDetail", b =>
                {
                    b.HasOne("CertExBackend.Model.MyCertification", "MyCertification")
                        .WithMany("ExamDetails")
                        .HasForeignKey("MyCertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CertExBackend.Model.Nomination", "Nomination")
                        .WithOne("ExamDetail")
                        .HasForeignKey("CertExBackend.Model.ExamDetail", "NominationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyCertification");

                    b.Navigation("Nomination");
                });

            modelBuilder.Entity("CertExBackend.Model.Nomination", b =>
                {
                    b.HasOne("CertExBackend.Model.CertificationExam", "CertificationExam")
                        .WithMany()
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Employee", "Employee")
                        .WithMany("Nominations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CertificationExam");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.HasOne("CertExBackend.Model.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CertExBackend.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Employee", "Manager")
                        .WithMany("Subordinates")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");

                    b.Navigation("Manager");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CertExBackend.Model.CategoryTag", b =>
                {
                    b.Navigation("CertificationTags");
                });

            modelBuilder.Entity("CertExBackend.Model.CertificationExam", b =>
                {
                    b.Navigation("CertificationTags");
                });

            modelBuilder.Entity("CertExBackend.Model.CertificationProvider", b =>
                {
                    b.Navigation("CertificationExams");
                });

            modelBuilder.Entity("CertExBackend.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("CertExBackend.Model.FinancialYear", b =>
                {
                    b.Navigation("CriticalCertifications");
                });

            modelBuilder.Entity("CertExBackend.Model.MyCertification", b =>
                {
                    b.Navigation("ExamDetails");
                });

            modelBuilder.Entity("CertExBackend.Model.Nomination", b =>
                {
                    b.Navigation("ExamDetail");
                });

            modelBuilder.Entity("CertExBackend.Model.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Navigation("Nominations");

                    b.Navigation("Subordinates");
                });
#pragma warning restore 612, 618
        }
    }
}
