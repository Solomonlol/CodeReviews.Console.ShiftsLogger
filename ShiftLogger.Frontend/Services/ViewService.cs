using ShiftLogger.Frontend.Interfaces;
using Spectre.Console;
using System.Reflection;

namespace ShiftLogger.Frontend.Services
{
    internal class ViewService : IViewService
    {
        public async Task View<T>(List<T> tableData, string? tableName, CancellationToken cancellationToken = default) where T : class
        {
            AnsiConsole.Clear();
            if (tableName == null)
                tableName = "";

            var table = new Table();

            if(!string.IsNullOrEmpty(tableName))
            {
                table.Title(tableName);
            }

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach(var prop in properties)
            {
                table.AddColumn(prop.Name);
            }

            foreach (var item in tableData)
            {
                var values = properties.Select(p => p.GetValue(item)?.ToString() ?? string.Empty).ToArray();

                table.AddRow(values);
            }

            AnsiConsole.Write(table);
        }
    }
}
