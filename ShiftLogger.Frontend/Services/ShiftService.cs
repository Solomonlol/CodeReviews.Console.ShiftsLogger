using ShiftLogger.Frontend.Entities.Dto;
using ShiftLogger.Frontend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftLogger.Frontend.Services
{
    internal class ShiftService : IShiftService
    {
        private readonly HttpClient _httpClient;
        public ShiftService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5013/");
        }
        public Task End(int employeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShiftDto>> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShiftDto>> GetAllCurrent(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShiftDto>> GetByEmployeeNumber(int empoyeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task GetCurrent(int empoyeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Start(int employeeNumber, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
