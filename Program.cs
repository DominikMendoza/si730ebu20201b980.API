using si730ebu20201b980.API.Learning.Domain.Repositories;
using si730ebu20201b980.API.Learning.Domain.Services;
using si730ebu20201b980.API.Learning.Persistence.Repositories;
using si730ebu20201b980.API.Learning.Services;
using si730ebu20201b980.API.Shared.Domain.Repositories;
using si730ebu20201b980.API.Shared.Persistence.Contexts;
using si730ebu20201b980.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add CORS

builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
    
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ACME si730ebu20201b980 API",
        Description = "ACME si730ebu20201b980 RESTful API",
        TermsOfService = new Uri("https://acme-learning.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "ACME.studio",
            Url = new Uri("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "ACME Learning Center Resources License",
            Url = new Uri("https://acme-learning.com/license")
        }
    });
    options.EnableAnnotations();
});

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

// Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Learning Injection Configuration

builder.Services.AddScoped<IGuardianRepository, GuardianRepository>();
builder.Services.AddScoped<IGuardianService, GuardianService>();
builder.Services.AddScoped<IUrgencyRepository, UrgencyRepository>();
builder.Services.AddScoped<IUrgencyService, UrgencyService>();


// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(si730ebu20201b980.API.Learning.Mapping.ModelToResourceProfile),
    typeof(si730ebu20201b980.API.Learning.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

// Configure CORS 

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
