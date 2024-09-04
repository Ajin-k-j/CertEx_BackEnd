using CertExBackend.Data;
using CertExBackend.Mappings;
using CertExBackend.Repository;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using CertExBackend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CertExBackend.Repositories;
using CertExBackend.Mapping;
using CertExBackend.DTOs;
using CertExBackend.Model;
using Serilog;
using Serilog.Events;
using CertExBackend.Services.Interfaces;
using CertExBackend.Repositories.Interfaces;
/*using CertExBackend.Interface;*/

var builder = WebApplication.CreateBuilder(args);


// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Log to file with daily rolling
    .CreateLogger();


builder.Host.UseSerilog(); // Use Serilog for logging
// Add services to the container.
builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173") //React app URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Configure DbContext with PostgreSQL
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper with Dependency Injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register AutoMapper with Dependency Injection
builder.Services.AddAutoMapper(typeof(CategoryTagProfile));
builder.Services.AddAutoMapper(typeof(CertificationExamProfile));
builder.Services.AddAutoMapper(typeof(CertificationProviderProfile));
builder.Services.AddAutoMapper(typeof(CertificationTagProfile));
builder.Services.AddAutoMapper(typeof(CriticalCertificationProfile));
builder.Services.AddAutoMapper(typeof(DepartmentProfile));
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddAutoMapper(typeof(ExamDetailProfile));
builder.Services.AddAutoMapper(typeof(FinancialYearProfile));
builder.Services.AddAutoMapper(typeof(MyCertificationProfile));
builder.Services.AddAutoMapper(typeof(NominationProfile));
builder.Services.AddAutoMapper(typeof(PendingNominationProfile));
builder.Services.AddAutoMapper(typeof(RoleProfile));
builder.Services.AddAutoMapper(typeof(EmployeeCertificationProfile));
builder.Services.AddAutoMapper(typeof(DepartmentStatsProfile));
builder.Services.AddAutoMapper(typeof(AwsStatsProfile));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(AwsNominationProfile).Assembly);



// Register repository services
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICertificationProviderRepository, CertificationProviderRepository>();
builder.Services.AddScoped<ICategoryTagRepository, CategoryTagRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ICertificationExamRepository, CertificationExamRepository>();
builder.Services.AddScoped<ICertificationTagRepository, CertificationTagRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<INominationRepository, NominationRepository>();
builder.Services.AddScoped<IExamDetailRepository, ExamDetailRepository>();
builder.Services.AddScoped<IMyCertificationRepository, MyCertificationRepository>();
builder.Services.AddScoped<IFinancialYearRepository, FinancialYearRepository>();
builder.Services.AddScoped<ICriticalCertificationRepository, CriticalCertificationRepository>();
builder.Services.AddScoped<IEmployeeCertificationRepository, EmployeeCertificationRepository>();
builder.Services.AddScoped<IDepartmentStatsRepository, DepartmentStatsRepository>();
builder.Services.AddScoped<IAwsStatsRepository, AwsStatsRepository>();
builder.Services.AddScoped<IDepartmentNominationRepository, DepartmentNominationRepository>();
builder.Services.AddScoped<IAwsNominationRepository, AwsNominationRepository>();
builder.Services.AddScoped<ILndBarGraphRepository, LndBarGraphRepository>();
builder.Services.AddScoped<IDuBarGraphRepository, DuBarGraphRepository>();
builder.Services.AddScoped<IAwsBarGraphRepository, AwsBarGraphRepository>();
builder.Services.AddScoped<IUserPendingActionRepository, UserPendingActionRepository>();
builder.Services.AddScoped<ILDNominationRepository, LDNominationRepository>();




builder.Services.AddScoped<IEmailService, EmailService>();


// Register Services with Dependency Injection
builder.Services.AddScoped<ICategoryTagService, CategoryTagService>();
builder.Services.AddScoped<ICertificationExamService, CertificationExamService>();
builder.Services.AddScoped<ICertificationProviderService, CertificationProviderService>();
builder.Services.AddScoped<ICertificationTagService, CertificationTagService>();
builder.Services.AddScoped<ICriticalCertificationService, CriticalCertificationService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IExamDetailService, ExamDetailService>();
builder.Services.AddScoped<IFinancialYearService, FinancialYearService>();
builder.Services.AddScoped<IMyCertificationService, MyCertificationService>();
builder.Services.AddScoped<INominationService, NominationService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ILndBarGraphService, LndBarGraphService>();
builder.Services.AddScoped<IDuBarGraphService, DuBarGraphService>();
builder.Services.AddScoped<IAwsBarGraphService, AwsBarGraphService>();
builder.Services.AddScoped<IUserPendingActionService, UserPendingActionService>();
builder.Services.AddScoped<IAwsStatsService, AwsStatsService>();
builder.Services.AddScoped<IDepartmentStatsService, DepartmentStatsService>();
builder.Services.AddScoped<IDepartmentNominationService, DepartmentNominationService>();
builder.Services.AddScoped<IAwsNominationService, AwsNominationService>();
builder.Services.AddScoped<IEmployeeCertificationService, EmployeeCertificationService>();
builder.Services.AddScoped<ILDNominationService, LDNominationService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();