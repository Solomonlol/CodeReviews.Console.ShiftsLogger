using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
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
            AddItem("Create", () => Create());
            AddItem("View All", () => GetAll());
            AddExitItem("Back");
        }

        public async Task Create(CancellationToken ct = default)
        {
            await _employeeService.Create(ct);
        }

        public async Task GetAll(CancellationToken ct = default)
        {
            var responce = await _employeeService.GetAll(ct);
            var listDto = responce.ToList();
            await _viewService.View(listDto, "Employees", ct);
        }
        

    }
}
