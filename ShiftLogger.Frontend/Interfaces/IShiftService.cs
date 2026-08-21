using ShiftLogger.Frontend.Entities.Dto;

namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IShiftService
    {
        Task<IEnumerable<FullDto>?> GetAllByEmployeeNumber(CancellationToken cancellationToken = default);
        Task<IEnumerable<FullDto>?> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<FullDto>?> GetAllCurrent(CancellationToken cancellationToken = default);
        Task<ShiftDto?> GetCurrent(CancellationToken cancellationToken = default);
        Task Start(CancellationToken cancellationToken = default);
        Task End(CancellationToken cancellationToken = default);
    }
}
