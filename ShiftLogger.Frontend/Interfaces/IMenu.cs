namespace ShiftLogger.Frontend.Interfaces
{
    internal interface IMenu
    {
        Task RunAsync(CancellationToken cancellationToken = default);
    }
}
