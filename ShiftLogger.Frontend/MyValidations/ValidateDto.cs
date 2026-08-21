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

            if (await Validate(employee))
            {
                return employee;
            }
            else return null;
        }
        public static async Task<bool> Validate(EmployeeDto dto)
        {
            var context = new ValidationContext(dto);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (!Validator.TryValidateObject(dto, context, results, true))
            {
                foreach (var error in results)
                {
                    AnsiConsole.MarkupLine($"[red]Error: {error.ErrorMessage}[/]");
                }
                AnsiConsole.MarkupLine("[red]Employee was not validated.[/]");
                return false;
            }
            else
            {
                AnsiConsole.MarkupLine("[green]Employee was validated succesfully.[/]");
                return true;
            }
        }
    }
}
