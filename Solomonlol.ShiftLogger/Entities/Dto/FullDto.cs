using System.ComponentModel.DataAnnotations;

namespace ShiftLogger.Backend.Entities.Dto
{
    public class FullDto
    {
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;


        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;


        [Range(1, 999999, ErrorMessage = "User identification number should be on 1-999999 range")]
        public int EmployeeNumber { get; set; }
        public DateTime? StartTime { get; set; } = null;
        public DateTime? EndTime { get; set; } = null;
        public TimeSpan? Duration {  get; set; } = TimeSpan.Zero;
        public bool IsEnded { get; set; }
        public FullDto(EmployeeDto eDto, ShiftDto sDto)
        {
            FirstName = eDto.FirstName;
            LastName = eDto.LastName;
            EmployeeNumber = eDto.EmployeeNumber;
            StartTime = sDto.StartTime;
            EndTime = sDto.EndTime;
            Duration = EndTime - StartTime;
            IsEnded = sDto.IsEnded;
        }
        public FullDto(Employee employee, ShiftDto sDto)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            EmployeeNumber = employee.EmployeeNumber;
            StartTime = sDto.StartTime;
            EndTime = sDto.EndTime;
            Duration = EndTime - StartTime;
            IsEnded = sDto.IsEnded;
        }
        public FullDto(EmployeeDto eDto, Shift shift)
        {
            FirstName = eDto.FirstName;
            LastName = eDto.LastName;
            EmployeeNumber = eDto.EmployeeNumber;
            StartTime = shift.StartTime;
            EndTime = shift.EndTime;
            Duration = EndTime - StartTime;
            IsEnded = shift.IsEnded;
        }

        public FullDto(Employee employee, Shift shift)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            EmployeeNumber = employee.EmployeeNumber;
            StartTime = shift.StartTime;
            EndTime = shift.EndTime;
            Duration = EndTime - StartTime;
            IsEnded = shift.IsEnded;
        }
        
    }
}
