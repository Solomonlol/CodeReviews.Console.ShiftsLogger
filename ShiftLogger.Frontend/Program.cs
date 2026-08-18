using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShiftLogger.Frontend.Interfaces;
using ShiftLogger.Frontend.Services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services)=>
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IShiftService, ShiftService>();
    })
    .Build();