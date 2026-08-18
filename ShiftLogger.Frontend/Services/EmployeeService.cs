using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Services
{
    internal class EmployeeService : IEmployeeService
    {
        public Task Create(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int employeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Get(int employeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Update(int empoyeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
