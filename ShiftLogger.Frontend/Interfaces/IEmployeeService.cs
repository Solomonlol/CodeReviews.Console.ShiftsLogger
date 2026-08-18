using ShiftLogger.Frontend.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IEmployeeService
    {
        Task Create(CancellationToken cancellationToken = default);
        Task Get(int employeeNumber, CancellationToken cancellationToken = default);
        Task Update(int empoyeeNumber, CancellationToken cancellationToken = default);
        Task Delete(int employeeNumber, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default);
    }
}
