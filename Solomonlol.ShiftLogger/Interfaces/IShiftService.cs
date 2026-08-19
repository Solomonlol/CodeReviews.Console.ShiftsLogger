using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;

namespace ShiftLogger.Backend.Interfaces
{
    public interface IShiftService
    {
        //Task<Shift> GetById(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Shift>> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<Shift>> GetAllByEmployeeNumber(int empoyeeNumber, CancellationToken cancellationToken = default);
        //Task Delete(int id, CancellationToken cancellationToken = default);
        //Task Update(Shift item, CancellationToken cancellationToken = default);
        //Task Create(Shift item, CancellationToken cancellationToken = default);
        Task Start(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default);
        Task End(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default);
    }
}
