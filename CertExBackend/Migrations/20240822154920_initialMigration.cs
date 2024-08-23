using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CertExBackend.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryTagName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProviderName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyCertifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Credentials = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCertifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    CertificationName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NominationStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Level = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    OfficialLink = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CostUsd = table.Column<decimal>(type: "numeric", nullable: false),
                    CostInr = table.Column<decimal>(type: "numeric", nullable: false),
                    NominationOpenDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NominationCloseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CertificationProviderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificationExams_CertificationProviders_CertificationProv~",
                        column: x => x.CertificationProviderId,
                        principalTable: "CertificationProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    AppRoleId = table.Column<int>(type: "integer", nullable: false),
                    AwsAccountActive = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SSOEmployeeId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ManagerId = table.Column<int>(type: "integer", nullable: true),
                    IsManager = table.Column<bool>(type: "boolean", nullable: false),
                    IsDepartmentHead = table.Column<bool>(type: "boolean", nullable: false),
                    Designation = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CertificationId = table.Column<int>(type: "integer", nullable: false),
                    CategoryTagId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificationTags_CategoryTags_CategoryTagId",
                        column: x => x.CategoryTagId,
                        principalTable: "CategoryTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationTags_CertificationExams_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "CertificationExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriticalCertifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CertificationId = table.Column<int>(type: "integer", nullable: false),
                    FinancialYearId = table.Column<int>(type: "integer", nullable: false),
                    RequiredCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriticalCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriticalCertifications_CertificationExams_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "CertificationExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriticalCertifications_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nominations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CertificationId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    PlannedExamMonth = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MotivationDescription = table.Column<string>(type: "text", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DepartmentApproval = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    LndApproval = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ExamStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NominationStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nominations_CertificationExams_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "CertificationExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nominations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AwsAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NominationId = table.Column<int>(type: "integer", nullable: false),
                    Credentials = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwsAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwsAdmins_Nominations_NominationId",
                        column: x => x.NominationId,
                        principalTable: "Nominations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NominationId = table.Column<int>(type: "integer", nullable: false),
                    MyCertificationId = table.Column<int>(type: "integer", nullable: false),
                    CostInrWithoutTax = table.Column<decimal>(type: "numeric", nullable: false),
                    CostInrWithTax = table.Column<decimal>(type: "numeric", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InvoiceUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    UploadCertificateStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SkillMatrixStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ReimbursementStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamDetails_MyCertifications_MyCertificationId",
                        column: x => x.MyCertificationId,
                        principalTable: "MyCertifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamDetails_Nominations_NominationId",
                        column: x => x.NominationId,
                        principalTable: "Nominations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwsAdmins_NominationId",
                table: "AwsAdmins",
                column: "NominationId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationExams_CertificationProviderId",
                table: "CertificationExams",
                column: "CertificationProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationTags_CategoryTagId",
                table: "CertificationTags",
                column: "CategoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationTags_CertificationId",
                table: "CertificationTags",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CriticalCertifications_CertificationId",
                table: "CriticalCertifications",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CriticalCertifications_FinancialYearId",
                table: "CriticalCertifications",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AppRoleId",
                table: "Employees",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SSOEmployeeId",
                table: "Employees",
                column: "SSOEmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamDetails_MyCertificationId",
                table: "ExamDetails",
                column: "MyCertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDetails_NominationId",
                table: "ExamDetails",
                column: "NominationId");

            migrationBuilder.CreateIndex(
                name: "IX_Nominations_CertificationId",
                table: "Nominations",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Nominations_EmployeeId",
                table: "Nominations",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwsAdmins");

            migrationBuilder.DropTable(
                name: "CertificationTags");

            migrationBuilder.DropTable(
                name: "CriticalCertifications");

            migrationBuilder.DropTable(
                name: "ExamDetails");

            migrationBuilder.DropTable(
                name: "CategoryTags");

            migrationBuilder.DropTable(
                name: "FinancialYears");

            migrationBuilder.DropTable(
                name: "MyCertifications");

            migrationBuilder.DropTable(
                name: "Nominations");

            migrationBuilder.DropTable(
                name: "CertificationExams");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "CertificationProviders");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
