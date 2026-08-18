using Microsoft.EntityFrameworkCore;
using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;
using ShiftLogger.Backend.Interfaces;
using Solomonlol.ShiftLogger;

namespace ShiftLogger.Backend.Services
{
    public class EmployeeService : IEmloyeeService
    {
        private readonly ApplicationContext _context;
        public EmployeeService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(EmployeeDto employee, CancellationToken cancellationToken = default)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Employees.FindAsync(id, cancellationToken);
            if(user!=null)
                _context.Employees.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Employee>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Employees.ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.FindAsync(id, cancellationToken);
        }

        public async Task<Employee> GetByNumber(int employeeNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.FirstOrDefaultAsync(u=>u.EmployeeNumber==employeeNumber);
        }

        public async Task Update(Employee user, CancellationToken cancellationToken = default)
        {
            if(user!=null)
                _context.Employees.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
