using si730ebu20201b980.API.Loyalty.Domain.Repositories;
using si730ebu20201b980.API.Loyalty.Domain.Services;
using si730ebu20201b980.API.Loyalty.Persistence.Repositories;
using si730ebu20201b980.API.Loyalty.Services;
using si730ebu20201b980.API.Shared.Domain.Repositories;
using si730ebu20201b980.API.Shared.Persistence.Contexts;
using si730ebu20201b980.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ACME si730ebu20201b980 API",
        Description = "ACME si730ebu20201b980 RESTful API",
        TermsOfService = new Uri("https://acme-Loyalty.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "ACME.studio",
            Url = new Uri("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "ACME Loyalty Center Resources License",
            Url = new Uri("https://acme-Loyalty.com/license")
        }
    });
    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<IRewardService, RewardService>();

builder.Services.AddAutoMapper(
    typeof(si730ebu20201b980.API.Loyalty.Mapping.ModelToResourceProfile),
    typeof(si730ebu20201b980.API.Loyalty.Mapping.ResourceToModelProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
