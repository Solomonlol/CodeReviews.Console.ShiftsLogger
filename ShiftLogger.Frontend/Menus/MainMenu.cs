using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Menus
{
    internal class MainMenu : UserInterface
    {
        private readonly EmployeeManagementMenu _employeeManagementMenu;
        private readonly ShiftsMenu _shiftsMenu;
        public MainMenu(EmployeeManagementMenu employeeManagementMenu,
            ShiftsMenu shiftsMenu) :base("Main menu") 
        {
            _shiftsMenu = shiftsMenu;
            _employeeManagementMenu = employeeManagementMenu;
            AddSubMenu("Empoyee management", _employeeManagementMenu);
            AddSubMenu("Shifts", _shiftsMenu);
            AddExitItem("Exit");
        }
    }
}
