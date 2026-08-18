using AutoMapper;
using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;
using ShiftLogger.Backend.Interfaces;


namespace ShiftLogger.Backend.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapEmployeeEndpoints(this WebApplication app)
        {
            app.MapGet("/api/employees", async (IEmloyeeService db, CancellationToken ct) =>
            {
                return await db.GetAll(ct);
            });

            app.MapGet("/api/employees/{id}", async (int id, IEmloyeeService db, CancellationToken ct) =>
            {
                return await db.GetById(id, ct)
                    is EmployeeDto employee ? Results.Ok(employee) : Results.NotFound();
            });

            app.MapPost("/api/employees", async(EmployeeDto employee, IEmloyeeService db, CancellationToken ct) =>
            {
                await db.Create(employee, ct);
            });

            app.MapDelete("/api/employees/{id}", async (int id, IEmloyeeService db, CancellationToken ct) =>
            {
                await db.Delete(id, ct);
            });

            app.MapPut("/api/employees/{id}", async (int employeeNumber, EmployeeDto dto, IEmloyeeService db, CancellationToken ct) =>
            {
                var employee = await db.GetByNumber(employeeNumber, ct);

                if(employee is null)
                    return Results.NotFound();

                

                await db.Update(employeeNumber, employee);
                return Results.Ok(employee);
            });
        }
    }
}
