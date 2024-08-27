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
/*using CertExBackend.Interface;*/

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddAutoMapper(typeof(AwsAdminProfile));
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
builder.Services.AddScoped<IAwsAdminRepository, AwsAdminRepository>();
builder.Services.AddScoped<IEmployeeCertificationRepository, EmployeeCertificationRepository>();
builder.Services.AddScoped<IDepartmentStatsRepository, DepartmentStatsRepository>();
builder.Services.AddScoped<IAwsStatsRepository, AwsStatsRepository>();
builder.Services.AddScoped<IDepartmentNominationRepository, DepartmentNominationRepository>();
builder.Services.AddScoped<IAwsNominationRepository, AwsNominationRepository>();


// Register Services with Dependency Injection
builder.Services.AddScoped<IAwsAdminService, AwsAdminService>();
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
builder.Services.AddScoped<IEmployeeCertificationService, EmployeeCertificationService>();
builder.Services.AddScoped<IDepartmentStatsService, DepartmentStatsService>();
builder.Services.AddScoped<IAwsStatsService, AwsStatsService>();
builder.Services.AddScoped<IDepartmentNominationService, DepartmentNominationService>();
builder.Services.AddScoped<IAwsNominationService, AwsNominationService>();




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
