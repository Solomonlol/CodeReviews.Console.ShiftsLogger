using ShiftLogger.Frontend.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Menus
{
    internal class ShiftsMenu : UserInterface
    {
        private readonly IShiftService _shiftService;
        private readonly IViewService _viewService;
        public ShiftsMenu(IShiftService shiftService, IViewService viewService) : base("Shifts menu")
        {
            _shiftService = shiftService;
            _viewService = viewService;
            AddItem("Start shift", () => Start());
            AddExitItem("Back");
        }

        public async Task Start(CancellationToken ct = default)
        {
            var employeeNumber = await AnsiConsole.AskAsync<int>("[yellow]Enter your personal employee number:[/]", ct);
            await _shiftService.Start(employeeNumber, ct);
        }
    }
}
