using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

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
        public async Task Create(CancellationToken cancellationToken = default)
        {
            var firstName = await AnsiConsole.AskAsync<string>("[yellow]Enter first name:[/]");
            var lastName = await AnsiConsole.AskAsync<string>("[yellow]Enter last name:[/]");
            var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter personal employee number:[/]");
            
        }

        public Task Delete(int employeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task Get(int employeeNumber, CancellationToken cancellationToken = default)
        {
            await _httpClient.GetAsync($"api/employees/{employeeNumber}", cancellationToken);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var responce = await _httpClient.GetAsync($"api/employees", cancellationToken);
            if (responce.IsSuccessStatusCode)
                return await responce.Content.ReadFromJsonAsync<List<EmployeeDto>>();
            else return null;
        }

        public Task Update(int empoyeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
