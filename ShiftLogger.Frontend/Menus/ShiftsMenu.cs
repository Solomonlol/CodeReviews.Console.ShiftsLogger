using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
using Spectre.Console;
using System;
using System.Collections;
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
            AddItem("View all", () => GetAll());
            AddItem("View all current", () => GetAllCurrent());
            AddItem("View current by employee", () => GetCurrent());
            AddItem("Start shift", () => Start());
            AddItem("End shift", () => End());
            AddExitItem("Back");
        }

        public async Task Start(CancellationToken ct = default)
        {
            await _shiftService.Start(ct);
        }

        public async Task End(CancellationToken ct = default)
        {
            await _shiftService.End(ct);
        }
        public async Task GetAll(CancellationToken ct = default)
        {
            var list = (await _shiftService.GetAll(ct))?.ToList();
            if (list?.Any() == true)
                await _viewService.View(list.ToList(), "All shifts", ct);
            else AnsiConsole.MarkupLine("[red]Not found any shifts.[/]");
        }

        public async Task GetAllCurrent(CancellationToken ct = default)
        {
            var list = (await _shiftService.GetAllCurrent(ct))?.ToList();
            if(list?.Any()==true)
                await _viewService.View(list.ToList(), "All current shifts", ct);
            else AnsiConsole.MarkupLine("[red]Not found any current shifts.[/]");
        }

        public async Task GetCurrent(CancellationToken ct = default)
        {
            var current = await _shiftService.GetCurrent(ct);
            if(current!=null)
            {
                var list = new List<ShiftDto>() { current };
                await _viewService.View(list, "Current shift by selected employee", ct);
            }
            else AnsiConsole.MarkupLine("[red]This employee is not currently on shift.[/]");
        }
    }
}
