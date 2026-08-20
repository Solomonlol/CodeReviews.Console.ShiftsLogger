using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ShiftLogger.Frontend.Services
{
    internal class ShiftService : IShiftService
    {
        private readonly HttpClient _httpClient;
        public ShiftService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5013/");
        }
        public async Task Start(CancellationToken ct = default)
        {
            try
            {
                var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter personal employee number:[/]", ct);
                var responce = await _httpClient.GetAsync($"api/employees/{employeeNumber}", ct);
                if (responce.IsSuccessStatusCode)
                {
                    var dto = JsonSerializer.Serialize(new { EmployeeNumber = employeeNumber, StartTime = DateTime.UtcNow });
                    var content = new StringContent(dto, Encoding.UTF8, "application/json");
                    responce = await _httpClient.PostAsync($"api/shifts/{employeeNumber}", content, ct);
                    if (responce.IsSuccessStatusCode)
                    {
                        AnsiConsole.MarkupLine("[green]New shift started successfully.[/]");
                    }
                    else AnsiConsole.MarkupLine("[red]The employee already has a shift in progress.[/]");
                }
                else AnsiConsole.MarkupLine("[red]Employee not found.[/]");
            }
            catch (HttpRequestException)
            {
                AnsiConsole.MarkupLine("[red]No server responce.[/]");
            }
            catch (TaskCanceledException)
            {
                AnsiConsole.MarkupLine("[red]The request to the server timed out.[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }

        public async Task End(CancellationToken ct = default)
        {
            try
            {
                var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter personal employee number:[/]", ct);
                var responce = await _httpClient.GetAsync($"api/employees/{employeeNumber}", ct);
                if (responce.IsSuccessStatusCode)
                {
                    var dto = JsonSerializer.Serialize(new ShiftDto {   EndTime= DateTime.UtcNow });
                    var content = new StringContent(dto, Encoding.UTF8, "application/json");
                    responce = await _httpClient.PutAsync($"api/shifts/{employeeNumber}", content, ct);
                    if (responce.IsSuccessStatusCode)
                    {
                        AnsiConsole.MarkupLine("[green]Current shift ended successfully.[/]");
                    }
                    else AnsiConsole.MarkupLine("[red]The employee has no shifts in progress.[/]");
                }
                else AnsiConsole.MarkupLine("[red]Employee not found.[/]");
            }
            catch (HttpRequestException)
            {
                AnsiConsole.MarkupLine("[red]No server responce.[/]");
            }
            catch (TaskCanceledException)
            {
                AnsiConsole.MarkupLine("[red]The request to the server timed out.[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }

        public Task<IEnumerable<ShiftDto>> GetAll(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShiftDto>> GetAllCurrent(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShiftDto>> GetByEmployeeNumber(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task GetCurrent(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

    }
}
