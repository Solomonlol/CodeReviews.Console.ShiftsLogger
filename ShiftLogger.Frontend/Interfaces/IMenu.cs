using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IMenu
    {
        Task RunAsync(CancellationToken cancellationToken = default);
    }
}
