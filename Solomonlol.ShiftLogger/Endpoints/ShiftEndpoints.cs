using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;
using ShiftLogger.Backend.Interfaces;

namespace ShiftLogger.Backend.Endpoints
{
    public static class ShiftEndpoints
    {
        public static void MapShiftEndpoints(this WebApplication app)
        {

            //get all shifts
            app.MapGet("/api/shifts", async (IShiftService db, CancellationToken ct) =>
            {
                return await db.GetAll(ct);
            });

            //get all shifts by employee
            app.MapGet("/api/shifts/{employeeNumber}", async (int employeeNumber, IShiftService db, CancellationToken ct) =>
            {
                return await db.GetAllByEmployeeNumber(employeeNumber, ct);
            });

            //get current shift
            app.MapGet("/api/shifts/current/{employeeNumber}", async (int employeeNumber, IShiftService db, CancellationToken ct) =>
            {
                var result = await db.GetCurrent(employeeNumber, ct);
                return result is null ? Results.NotFound() : Results.Ok(result);
            });

            //start shift by employee
            app.MapPost("/api/shifts/{employeeNumber}", async (int employeeNumber, ShiftDto dto, IShiftService db, CancellationToken ct) =>
            {
                return await db.Start(employeeNumber, dto, ct) ? Results.Created() : Results.Conflict(dto);
            });

            //end current shift by employee
            app.MapPut("/api/shifts/{employeeNumber}", async (int employeeNumber, ShiftDto dto, IShiftService db, CancellationToken ct) =>
            {
                return await db.End(employeeNumber, dto, ct) ? Results.Ok(dto) : Results.Conflict(dto);
            });
        }
    }
}
