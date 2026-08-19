using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Menus
{
    internal class EmployeeManagementMenu : UserInterface
    {
        private readonly IEmployeeService _employeeService;
        private readonly IViewService _viewService;

        public EmployeeManagementMenu(IEmployeeService employeeService, IViewService viewService) : base("Empoyees management")
        {
            _employeeService = employeeService;
            _viewService = viewService;
            AddItem("View All", () => GetAll());
            AddItem("View one", () => Get());
            AddItem("Create", () => Create());
            AddItem("Update", () => Update());
            AddItem("Delete", () => Delete());
            AddExitItem("Back");
        }

        public async Task Create(CancellationToken ct = default)
        {
            await _employeeService.Create(ct);
        }

        public async Task GetAll(CancellationToken ct = default)
        {
            var responce = (await _employeeService.GetAll(ct))?.ToList();
            if (responce.Any())
                await _viewService.View(responce, "Employees", ct);
            else AnsiConsole.MarkupLine("[red]Not found any employees[/]");
        }
        
        public async Task Get(CancellationToken ct = default)
        {
            var response = await _employeeService.Get(ct);
            if(response!=null)
            {
                var list = new List<EmployeeDto>();
                list.Add(response);
                await _viewService.View(list, "Empoyee info", ct);
            }
        }

        public async Task Update(CancellationToken ct = default)
        {
            await _employeeService.Update(ct);
        }

        public async Task Delete(CancellationToken ct = default)
        {
            await _employeeService.Delete(ct);
        }

    }
}
