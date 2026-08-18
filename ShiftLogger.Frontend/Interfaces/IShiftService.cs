using ShiftLogger.Frontend.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IShiftService
    {
        Task<IEnumerable<ShiftDto>> GetByEmployeeNumber(int empoyeeNumber, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShiftDto>> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<ShiftDto>> GetAllCurrent(CancellationToken cancellationToken = default);
        Task GetCurrent(int empoyeeNumber, CancellationToken cancellationToken = default);
        Task Start(int employeeNumber, CancellationToken cancellationToken = default);
        Task End(int employeeNumber, CancellationToken cancellationToken = default);
    }
}
