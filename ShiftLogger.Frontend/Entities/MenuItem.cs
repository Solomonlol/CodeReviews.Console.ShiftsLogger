using ShiftLogger.Frontend.Interfaces;

namespace ShiftLogger.Frontend.Entities
{
    internal class MenuItem
    {
        public string Name { get; }
        public Func<Task?> Action { get; }
        public IMenu? SubMenu { get; }

        public MenuItem(string name, Func<Task> action) => (Name, Action) = (name, action);
        public MenuItem(string name, IMenu subMenu) => (Name, SubMenu) = (name, subMenu);
    }
}
