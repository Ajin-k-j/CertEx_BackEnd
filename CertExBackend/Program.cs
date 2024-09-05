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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Serilog;
using Serilog.Events;
using CertExBackend.Repositories.Interfaces;
using CertExBackend.Services.Interfaces;
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
builder.Services.AddAutoMapper(typeof(UserActionFlow));




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
builder.Services.AddScoped<IUserActionFlowRepository, UserActionFlowRepository>();
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
builder.Services.AddScoped<ILDNominationService, LDNominationService>();
builder.Services.AddScoped<IEmployeeCertificationService, EmployeeCertificationService>();
builder.Services.AddScoped<IUserActionFlowService, UserActionFlowService>();


// Configure File Upload Settings
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 209715200; // 200 MB limit
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations(); // This enables using annotations
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapGet("/api/Nomination/{id:int}/IsDepartmentApproved", async (int id, ApiDbContext dbContext) =>
{
    var nomination = await dbContext.Nominations.FindAsync(id);
    if (nomination == null)
    {
        return Results.NotFound("Nomination not found");
    }

    return Results.Ok(nomination.IsDepartmentApproved);
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Get IsDepartmentApproved status", description: "Returns the IsDepartmentApproved status for a given nomination"))
.Produces<bool>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/Nomination/{id:int}/IsLndApproved", async (int id, ApiDbContext dbContext) =>
{
    var nomination = await dbContext.Nominations.FindAsync(id);
    if (nomination == null)
    {
        return Results.NotFound("Nomination not found");
    }

    return Results.Ok(nomination.IsLndApproved);
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Get IsLndApproved status", description: "Returns the IsLndApproved status for a given nomination"))
.Produces<bool>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/ExamDetail/{id:int}/SkillMatrixStatus", async (int id, ApiDbContext dbContext) =>
{
    var examDetail = await dbContext.ExamDetails.FindAsync(id);
    if (examDetail == null)
    {
        return Results.NotFound("ExamDetail not found");
    }

    return Results.Ok(examDetail.SkillMatrixStatus);
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Get SkillMatrixStatus", description: "Returns the SkillMatrixStatus for a given ExamDetail"))
.Produces<bool>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/ExamDetail/{id:int}/ReimbursementStatus", async (int id, ApiDbContext dbContext) =>
{
    var examDetail = await dbContext.ExamDetails.FindAsync(id);
    if (examDetail == null)
    {
        return Results.NotFound("ExamDetail not found");
    }

    return Results.Ok(examDetail.ReimbursementStatus);
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Get ReimbursementStatus", description: "Returns the ReimbursementStatus for a given ExamDetail"))
    .Produces<bool>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

// Minimal API endpoint
app.MapGet("/api/Nomination/{id:int}/Details", async (int id, ApiDbContext dbContext) =>
{
    var nomination = await dbContext.Nominations.FindAsync(id);
    if (nomination == null)
    {
        return Results.NotFound("Nomination not found");
    }

    var result = new
    {
        nomination.ManagerRecommendation,
        nomination.IsDepartmentApproved,
        nomination.IsLndApproved
    };

    return Results.Ok(result);
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get Nomination Details", description: "Returns ManagerRecommendation, IsDepartmentApproved, and IsLndApproved for a given Nomination"))
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);


app.MapGet("/api/ExamDetail/{nominationId:int}/Details", async (int nominationId, ApiDbContext dbContext) =>
{
    var examDetail = await dbContext.ExamDetails
        .Where(e => e.NominationId == nominationId)
        .Select(e => new
        {
            e.Id,
            e.NominationId,
            e.MyCertificationId,
            e.UploadCertificateStatus,
            e.SkillMatrixStatus,
            e.ReimbursementStatus,
            e.InvoiceNumber
        })
        .FirstOrDefaultAsync();

    if (examDetail == null)
    {
        return Results.NotFound("ExamDetail not found");
    }

    return Results.Ok(examDetail);
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get ExamDetail", description: "Fetches ExamDetail properties based on NominationId"))
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);



app.MapPost("/api/ExamDetail/{id:int}/SkillMatrixStatus", async (int id, [FromBody] string skillMatrixStatus, ApiDbContext dbContext) =>
{
    var examDetail = await dbContext.ExamDetails.FindAsync(id);
    if (examDetail == null)
    {
        return Results.NotFound("ExamDetail not found");
    }

    examDetail.SkillMatrixStatus = skillMatrixStatus;
    examDetail.UpdatedAt = DateTime.UtcNow;

    await dbContext.SaveChangesAsync();

    return Results.Ok("SkillMatrixStatus updated successfully");
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Post SkillMatrixStatus", description: "Updates the SkillMatrixStatus for a given ExamDetail"))
    .Produces<bool>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapPost("/api/ExamDetail/{id:int}/ReimbursementStatus", async (int id, [FromBody] string reimbursementStatus, ApiDbContext dbContext) =>
{
    var examDetail = await dbContext.ExamDetails.FindAsync(id);
    if (examDetail == null)
    {
        return Results.NotFound("ExamDetail not found");
    }

    examDetail.ReimbursementStatus = reimbursementStatus;
    examDetail.UpdatedAt = DateTime.UtcNow;

    await dbContext.SaveChangesAsync();

    return Results.Ok("ReimbursementStatus updated successfully");
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Post ReimbursementStatus", description: "Updates the ReimbursementStatus for a given ExamDetail"))
    .Produces<bool>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/Nomination/{id:int}/ExamDate", async (int id, ApiDbContext dbContext) =>
{
    var nomination = await dbContext.Nominations.FindAsync(id);
    if (nomination == null)
    {
        return Results.NotFound("Nomination not found");
    }

    return Results.Ok(nomination.ExamDate);
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Get ExamDate", description: "Returns the ExamDate for a given Nomination"))
    .Produces<DateTime?>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/Nomination/{id:int}/ExamStatus", async (int id, ApiDbContext dbContext) =>
{
    var nomination = await dbContext.Nominations.FindAsync(id);
    if (nomination == null)
    {
        return Results.NotFound("Nomination not found");
    }

    return Results.Ok(nomination.ExamStatus);
})
    .WithMetadata(new SwaggerOperationAttribute(summary: "Get ExamStatus", description: "Returns the ExamStatus for a given Nomination"))
    .Produces<string>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);


app.UseCors("AllowReactApp");

app.UseStaticFiles(); // Enable serving static files from wwwroot

app.UseAuthorization();

app.MapControllers();

app.Run();
