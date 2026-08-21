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
                var employee = await db.GetByNumber(employeeNumber, ct);
                return employee !=null ? Results.Ok(employee) : Results.NotFound();
            });

            app.MapPost("/api/employees", async(EmployeeDto employee, IEmployeeService db, CancellationToken ct) =>
            {
                return await db.Create(employee, ct) ? Results.Created($"/api/employees/{employee.EmployeeNumber}", employee) : Results.Conflict();
            });

            app.MapDelete("/api/employees/{employeeNumber}", async (int employeeNumber, IEmployeeService db, CancellationToken ct) =>
            {

                return await db.Delete(employeeNumber, ct) ? Results.NoContent() : Results.BadRequest();
            });

            app.MapPut("/api/employees/{employeeNumber}", async (int employeeNumber, EmployeeDto dto, IEmployeeService db, CancellationToken ct) =>
            {
                var employee = await db.GetByNumber(employeeNumber, ct);

                if(employee is null)
                    return Results.NotFound();

                
                return await db.Update(employeeNumber, dto) ? Results.Ok(dto) : Results.BadRequest(dto);
            });
        }
    }
}
