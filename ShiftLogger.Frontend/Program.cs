using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShiftLogger.Frontend.Interfaces;
using ShiftLogger.Frontend.Menus;
using ShiftLogger.Frontend.Services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services)=>
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IShiftService, ShiftService>();
        services.AddScoped<IViewService, ViewService>();
        services.AddTransient<MainMenu>();
        services.AddTransient<ShiftsMenu>();
        services.AddTransient<EmployeeManagementMenu>();
        services.AddHttpClient("ApiClient",(sp, client)=>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            var baseUrl = config["ApiSettings:BaseUrl"] ?? "http://localhost:5013/";
            client.BaseAddress = new Uri(baseUrl);
        });
    })
    .Build();

using var scope = host.Services.CreateScope();

var mainMenu = scope.ServiceProvider.GetService<MainMenu>();

await mainMenu.RunAsync();