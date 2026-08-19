using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ShiftLogger.Frontend.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5013/");
        }
        public async Task Create(CancellationToken ct = default)
        {
            try
            {
                var employeeDto = new EmployeeDto();
                employeeDto.FirstName = await AnsiConsole.AskAsync<string>("[yellow]Enter first name:[/]");
                employeeDto.LastName = await AnsiConsole.AskAsync<string>("[yellow]Enter last name:[/]");
                employeeDto.EmployeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter personal employee number:[/]");

                var jsonDto = JsonSerializer.Serialize(employeeDto);
                var content = new StringContent(jsonDto, Encoding.UTF8, "application/json");
                var responce = await _httpClient.PostAsync($"api/employees", content);

                if (responce.IsSuccessStatusCode)
                {
                    AnsiConsole.MarkupLine($"[green]Employee was successfully created[/]");
                }
                else
                {
                    //var error = await responce.Content.ReadAsStringAsync();
                    AnsiConsole.MarkupLine($"[red]API Error: {(int)responce.StatusCode} - {responce.ReasonPhrase}[/]");
                    
                }
            }
            catch(HttpRequestException)
            {
                AnsiConsole.MarkupLine("[red]No server responce.[/]");
            }
            catch(TaskCanceledException)
            {
                AnsiConsole.MarkupLine("[red]The request to the server timed out.[/]");
            }
            catch(Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }

        public async Task Delete(CancellationToken ct = default)
        {
            try
            {
                var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter employee personal number:[/]");
                var answer = await AnsiConsole.ConfirmAsync("Are you sure? This action cannot be reversed!");
                if (answer)
                {
                    var response = await _httpClient.DeleteAsync($"api/employees/{employeeNumber}", ct);

                    if (response.IsSuccessStatusCode)
                    {
                        AnsiConsole.MarkupLine("[green]Employee was deleted successfully.[/]");
                    }
                }
                else return;
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

        public async Task<EmployeeDto?> Get(CancellationToken ct = default)
        {
            try
            {
                var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter personal employee number:[/]");
                var response = await _httpClient.GetAsync($"api/employees/{employeeNumber}", ct);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<EmployeeDto>(cancellationToken: ct);
                    return result;
                }
                else return null;
            }
            catch (HttpRequestException)
            {
                AnsiConsole.MarkupLine("[red]No server responce.[/]");
                return null;
            }
            catch (TaskCanceledException)
            {
                AnsiConsole.MarkupLine("[red]The request to the server timed out.[/]");
                return null;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
                return null;
            }
        }

        public async Task<IEnumerable<EmployeeDto>?> GetAll(CancellationToken ct = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/employees", ct);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<EmployeeDto>>(cancellationToken: ct);
                    return result;
                }
                else return Enumerable.Empty<EmployeeDto>();
            }
            catch (HttpRequestException)
            {
                AnsiConsole.MarkupLine("[red]No server responce.[/]");
                return Enumerable.Empty<EmployeeDto>();
            }
            catch (TaskCanceledException)
            {
                AnsiConsole.MarkupLine("[red]The request to the server timed out.[/]");
                return Enumerable.Empty<EmployeeDto>();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
                return Enumerable.Empty<EmployeeDto>();
            }
        }

        public async Task Update(CancellationToken ct = default)
        {
            try
            {
                var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter personal employee number:[/]");
                var response = await _httpClient.GetAsync($"api/employees/{employeeNumber}", ct);
                if (response.IsSuccessStatusCode)
                {
                    var employeeDto = await response.Content.ReadFromJsonAsync<EmployeeDto>();
                    var properties = employeeDto.GetType().GetProperties().Select(p => p.Name).ToArray();
                    var choises = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                        .Title("[yellow]Choose what info to update:[/]")
                        .AddChoices(properties)
                        );

                    foreach (var choise in choises)
                    {
                        switch (choise)
                        {
                            case "FirstName":
                                employeeDto.FirstName = await AnsiConsole.AskAsync<string>("[yellow]New first name:[/]");
                                break;
                            case "LastName":
                                employeeDto.LastName = await AnsiConsole.AskAsync<string>("[yellow]New last name:[/]");
                                break;
                            case "EmployeeNumber":
                                employeeDto.EmployeeNumber = await AnsiConsole.AskAsync<int>("[yellow]New last name:[/]");
                                break;
                        }
                    }

                    var jsonDto = JsonSerializer.Serialize(employeeDto);
                    var content = new StringContent(jsonDto, Encoding.UTF8, "application/json");
                    var responce = await _httpClient.PutAsync($"api/employees", content);

                    if (responce.IsSuccessStatusCode)
                        AnsiConsole.MarkupLine("[green]Updated successfully.[/]");
                    else
                    {
                        AnsiConsole.MarkupLine($"[red]API Error: {(int)responce.StatusCode} - {responce.ReasonPhrase}[/]");
                    }
                }
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
    }
}
