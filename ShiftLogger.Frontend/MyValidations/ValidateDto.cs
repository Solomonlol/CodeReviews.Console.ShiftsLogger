using ShiftLogger.Frontend.Entities.Dto;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;

namespace ShiftLogger.Frontend.MyValidations
{
    internal static class ValidateDto
    {
        public static async Task<EmployeeDto?> CreateEmployee()
        {
                Console.Clear();
                
                var firstName = await AnsiConsole.AskAsync<string>("[yellow]Enter first name:[/]");
                var lastName = await AnsiConsole.AskAsync<string>("[yellow]Enter last name:[/]");
                var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter personal employee number:[/]");

                EmployeeDto employee = new EmployeeDto(firstName, lastName, employeeNumber);
                var context = new ValidationContext(employee);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

                if (!Validator.TryValidateObject(employee, context, results, true))
                {
                    foreach (var error in results)
                    {
                        AnsiConsole.MarkupLine($"[red]Error: {error.ErrorMessage}[/]");
                    }
                    AnsiConsole.MarkupLine("[red]Employee was not validated.[/]");
                    return null;
                }
                else {
                    AnsiConsole.MarkupLine("[green]Employee was validated succesfully.[/]");
                    return employee;
                }
        }
    }
}
