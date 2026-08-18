using AutoMapper;
using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;
using ShiftLogger.Backend.Interfaces;


namespace ShiftLogger.Backend.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void MapEmployeeEndpoints(this WebApplication app)
        {
            app.MapGet("/api/employees", async (IEmployeeService db, CancellationToken ct) =>
            {
                return await db.GetAll(ct);
            });

            app.MapGet("/api/employees/{employeeNumber}", async (int employeeNumber, IEmployeeService db, CancellationToken ct) =>
            {
                return await db.GetByNumber(employeeNumber, ct)
                    is EmployeeDto employee ? Results.Ok(employee) : Results.NotFound();
            });

            app.MapPost("/api/employees", async(EmployeeDto employee, IEmployeeService db, CancellationToken ct) =>
            {
                await db.Create(employee, ct);
                return Results.Created();
            });

            app.MapDelete("/api/employees/{employeeNumber}", async (int employeeNumber, IEmployeeService db, CancellationToken ct) =>
            {
                await db.Delete(employeeNumber, ct);
                return Results.NoContent();
            });

            app.MapPut("/api/employees/{id}", async (int id, EmployeeDto dto, IEmployeeService db, CancellationToken ct) =>
            {
                var employee = await db.GetById(id, ct);

                if(employee is null)
                    return Results.NotFound();

                await db.Update(id, dto);
                return Results.Ok(dto);
            });
        }
    }
}
