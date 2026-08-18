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

        private async Task Create(Shift shift, CancellationToken cancellationToken = default)
        {
            await _context.Shifts.AddAsync(shift, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var shift = await _context.Shifts.FindAsync(id, cancellationToken);
            if(shift!=null)
                _context.Shifts.Remove(shift);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task End(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber, cancellationToken);
            if (employee != null)
            {
                var checkShift = await _context.Shifts.FirstOrDefaultAsync(s => s.IsEnded == false && s.EmployeeId == employee.Id, cancellationToken);
                if (checkShift != null)
                {
                    await Update(_mapper.Map<Shift>(dto), cancellationToken);
                }
            }
        }
        public async Task Start(int employeeNumber, ShiftDto dto, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber, cancellationToken);
            if (employee != null)
            {
                var checkShift = await _context.Shifts.FirstOrDefaultAsync(s => s.IsEnded == false && s.EmployeeId == employee.Id, cancellationToken);
                if (checkShift == null)
                {
                    await Create(_mapper.Map<Shift>(dto), cancellationToken);
                }
            }
        }

        public async Task<IEnumerable<Shift>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Shifts.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Shift>> GetAllByEmployeeNumber(int employeeId, CancellationToken cancellationToken = default)
        {
            return await _context.Shifts.Where(s=>s.EmployeeId==employeeId).ToListAsync(cancellationToken);
        }

        public async Task<Shift> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Shifts.FindAsync(id, cancellationToken);
        }


        public async Task Update(Shift shift, CancellationToken cancellationToken = default)
        {
            if (shift != null)
                _context.Shifts.Update(shift);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
