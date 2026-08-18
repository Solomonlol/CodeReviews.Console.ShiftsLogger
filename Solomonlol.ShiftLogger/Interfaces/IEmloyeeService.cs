using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;

namespace ShiftLogger.Backend.Interfaces
{
    internal interface IEmloyeeService
    {
        Task<EmployeeDto> GetById(int id, CancellationToken cancellationToken = default);
        Task<EmployeeDto> GetByNumber(int employeeNumber, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancellationToken = default);
        Task Update(int employeeNumber, EmployeeDto item, CancellationToken cancellationToken = default);
        Task Create(EmployeeDto item, CancellationToken cancellationToken = default);
    }
}
