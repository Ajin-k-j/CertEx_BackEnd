using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
