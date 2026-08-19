using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IViewService
    {
        Task View<T>(List<T> tableData, string? tableName, CancellationToken cancellationToken = default) where T : class;
    }
}
