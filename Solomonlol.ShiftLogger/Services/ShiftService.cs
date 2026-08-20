using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;
using ShiftLogger.Backend.Interfaces;
using Solomonlol.ShiftLogger;


namespace ShiftLogger.Backend.Services
{
    public class ShiftService : IShiftService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ShiftService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> Start(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber, cancellationToken);
            if (employee != null)
            {
                var checkShift = await _context.Shifts.FirstOrDefaultAsync(s => s.IsEnded == false && s.EmployeeId == employee.Id, cancellationToken);
                if (checkShift == null)
                {
                    var shift = new Shift()
                    {
                        StartTime = dto.StartTime,
                        EmployeeId = employee.Id,
                        IsEnded = false
                    };
                    return await Create(shift, cancellationToken);
                }
                else return false;
            }
            else return false;
        }

        public async Task<bool> End(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber, cancellationToken);
            if (employee != null)
            {
                var currentShift = await _context.Shifts.FirstOrDefaultAsync(s => s.IsEnded == false && s.EmployeeId == employee.Id, cancellationToken);
                if (currentShift != null && currentShift.StartTime< dto.EndTime)
                {
                    currentShift.EndTime = dto.EndTime;
                    currentShift.IsEnded = true;
                    return await Update(currentShift, cancellationToken);
                }
                else return false;
            }
            else return false;
        }

        public async Task<IEnumerable<Shift>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Shifts.ToListAsync(cancellationToken);
        }

        public async Task<ShiftDto?> GetCurrent(int employeeNumber, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber, cancellationToken);
            
            return employee != null 
                ? _mapper.Map<ShiftDto>(await _context.Shifts.Where(s => s.EmployeeId == employee.Id && s.IsEnded == false)
                .FirstOrDefaultAsync(cancellationToken)) 
                : null;
        }

        public async Task<IEnumerable<Shift>> GetAllByEmployeeNumber(int employeeNumber, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber, cancellationToken);
            
            return employee!=null ? await _context.Shifts.Where(s => s.EmployeeId == employee.Id).ToListAsync(cancellationToken) : Enumerable.Empty<Shift>();
            
        }

        private async Task<bool> Create(Shift shift, CancellationToken cancellationToken = default)
        {
            if(shift!=null)
                await _context.Shifts.AddAsync(shift, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken)>0 ? true : false;
        }
        private async Task<bool> Update(Shift shift, CancellationToken cancellationToken = default)
        {
            if (shift != null)
                _context.Shifts.Update(shift);
            return await _context.SaveChangesAsync(cancellationToken)>0 ? true : false;
        }

    }
}
