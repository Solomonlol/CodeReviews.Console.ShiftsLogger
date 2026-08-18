using Microsoft.EntityFrameworkCore;
using ShiftLogger.Backend.Endpoints;
using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Interfaces;
using ShiftLogger.Backend.Mapping;
using ShiftLogger.Backend.Services;
using Solomonlol.ShiftLogger;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(connectionString));
builder.Services.AddOpenApi();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});




var app = builder.Build();


if(app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapEmployeeEndpoints();
app.MapShiftEndpoints();

await app.RunAsync();