using AutoMapper;
using ShiftLogger.Backend.Entities;
using ShiftLogger.Backend.Entities.Dto;

namespace ShiftLogger.Backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>()
                .ForMember(e => e.Id, d => d.Ignore())
                .ForAllMembers(e => e.Condition((dto, employee, member) =>
                member != null &&
                !(member is string s && string.IsNullOrEmpty(s))));

            CreateMap<Shift, ShiftDto>();
            CreateMap<ShiftDto, Shift>()
                .ForMember(s=>s.Employee, d=>d.Ignore())
                .ForMember(s=>s.Id, d=>d.Ignore())
                .ForAllMembers(e => e.Condition((dto, employee, member) =>
                member != null &&
                !(member is string s && string.IsNullOrEmpty(s))));
        }
    }
}
