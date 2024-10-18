using TrafficManagementApi;
using TrafficManagementApi.Services;
using TrafficManagementApi.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using TrafficManagementApi.Models;
using TrafficManagementApi.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurar o DbContext
builder.Services.AddDbContext<TrafficManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Injetar as dependências
builder.Services.AddScoped<ITrafficLightService, TrafficLightService>();
builder.Services.AddScoped<ITrafficLightRepository, TrafficLightRepository>();
builder.Services.AddScoped<IIncidentService, IncidentService>();
builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<IncidentDtoValidator>();
builder.Services.AddScoped<IEmergencyEndpointRepository, EmergencyEndpointRepository>();
builder.Services.AddHostedService<AccidentDetectionBackgroundService>();
builder.Services.AddScoped<IRouteOptimizationService, RouteOptimizationService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

