using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;
using ShiftLogger.Backend.Interfaces;
using Solomonlol.ShiftLogger;

namespace ShiftLogger.Backend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Create(EmployeeDto employee, CancellationToken cancellationToken = default)
        {
            var createdEmployee = new Employee();
            _mapper.Map(employee, createdEmployee);
            await _context.Employees.AddAsync(createdEmployee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int employeeNumber, CancellationToken cancellationToken = default)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber, cancellationToken);
            if(user!=null)
                _context.Employees.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var employeeList = await _context.Employees.ToListAsync(cancellationToken);
            return _mapper.Map<List<EmployeeDto>>(employeeList);
        }

        public async Task<EmployeeDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FindAsync(id, cancellationToken);
            var dto = new EmployeeDto();
            if (employee != null)
                return null;
            _mapper.Map(employee, dto);
            return dto;
        }

        public async Task<EmployeeDto> GetByNumber(int employeeNumber, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(u=>u.EmployeeNumber==employeeNumber);
            var dto = new EmployeeDto();
            _mapper.Map(employee, dto);
            return dto;
        }

        public async Task Update(int employeeNumber, EmployeeDto dto, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e=>e.EmployeeNumber== employeeNumber, cancellationToken);
            if (employee != null)
            {
                _mapper.Map(dto, employee);
                _context.Employees.Update(employee);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
