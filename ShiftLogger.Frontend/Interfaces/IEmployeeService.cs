using ShiftLogger.Frontend.Entities.Dto;

namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IEmployeeService
    {
        Task Create(CancellationToken cancellationToken = default);
        Task<EmployeeDto> Get(CancellationToken cancellationToken = default);
        Task Update(CancellationToken cancellationToken = default);
        Task Delete(CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeDto>?> GetAll(CancellationToken cancellationToken = default);
    }
}
