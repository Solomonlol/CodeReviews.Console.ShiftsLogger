using ShiftLogger.Backend.Entities.Dto;

namespace ShiftLogger.Backend.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto?> GetByNumber(int employeeNumber, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default);
        Task<bool> Delete(int employeeNumber, CancellationToken cancellationToken = default);
        Task<bool> Update(int employeeNumber, EmployeeDto item, CancellationToken cancellationToken = default);
        Task<bool> Create(EmployeeDto item, CancellationToken cancellationToken = default);
    }
}
