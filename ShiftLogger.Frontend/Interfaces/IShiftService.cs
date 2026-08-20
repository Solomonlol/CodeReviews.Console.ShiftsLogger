using ShiftLogger.Frontend.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IShiftService
    {
        Task<IEnumerable<ShiftDto>?> GetByEmployeeNumber(CancellationToken cancellationToken = default);
        Task<IEnumerable<ShiftDto>?> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<ShiftDto>?> GetAllCurrent(CancellationToken cancellationToken = default);
        Task<ShiftDto?> GetCurrent(CancellationToken cancellationToken = default);
        Task Start(CancellationToken cancellationToken = default);
        Task End(CancellationToken cancellationToken = default);
    }
}
