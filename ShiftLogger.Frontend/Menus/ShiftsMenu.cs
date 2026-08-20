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
    }
}
