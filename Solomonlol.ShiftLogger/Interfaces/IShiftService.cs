using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;

namespace ShiftLogger.Backend.Interfaces
{
    public interface IShiftService
    {
        Task<IEnumerable<FullDto>> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<FullDto>> GetAllByEmployeeNumber(int emlpoyeeNumber, CancellationToken cancellationToken = default);
        Task<ShiftDto?> GetCurrent(int employeeNumber, CancellationToken cancellationToken = default);
        Task<bool> Start(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default);
        Task<bool> End(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default);
    }
}
