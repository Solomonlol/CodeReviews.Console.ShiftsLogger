using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;
using ShiftLogger.Backend.Interfaces;

namespace ShiftLogger.Backend.Endpoints
{
    public static class ShiftEndpoints
    {
        public static void MapShiftEndpoints(this WebApplication app)
        {
            app.MapGet("/api/shifts", async (IShiftService db, CancellationToken ct) =>
            {
                return await db.GetAll(ct);
            });

            app.MapGet("/api/shifts/{employeeNumber}", async (int employeeNumber, IShiftService db, CancellationToken ct) =>
            {
                return await db.GetAllByEmployeeNumber(employeeNumber, ct);
                //return Results.Ok();
            });

            app.MapPost("/api/shifts/{employeeNumber}", async (int employeeNumber, ShiftDto dto, IShiftService db, CancellationToken ct) =>
            {
                return await db.Start(employeeNumber, dto, ct) ? Results.Created() : Results.Conflict(dto);
            });

            app.MapPut("/api/shifts/{employeeNumber}", async (int employeeNumber, ShiftDto dto, IShiftService db, CancellationToken ct) =>
            {
                return await db.End(employeeNumber, dto, ct) ? Results.Ok(dto) : Results.Conflict(dto);
            });
        }
    }
}
