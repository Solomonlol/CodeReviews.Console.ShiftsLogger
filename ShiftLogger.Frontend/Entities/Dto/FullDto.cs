using System.ComponentModel.DataAnnotations;

namespace ShiftLogger.Frontend.Entities.Dto
{
    public class FullDto
    {
        [Required(ErrorMessage = "First Name is required. Please fill in this field!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name length should be between 2 and 50 simbols")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "First name must contain only letters of the English and Russian alphabet.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required. Please fill in this field!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name length should be between 2 and 50 simbols")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Last name must contain only letters of the English and Russian alphabet.")]
        public string LastName { get; set; } = string.Empty;


        [Range(1, 999999, ErrorMessage = "User identification number should be on 1-999999 range")]
        public int EmployeeNumber { get; set; }
        public DateTime? StartTime { get; set; } = null;
        public DateTime? EndTime { get; set; } = null;
        public TimeSpan? Duration 
        { 
            get 
            {
                if(StartTime ==null || EndTime ==null)
                    return TimeSpan.Zero;
                var seconds = Math.Floor((EndTime.Value - StartTime.Value).TotalSeconds);
                return TimeSpan.FromSeconds(seconds);
            } 
        }
        public bool IsEnded { get; set; }
        public FullDto() { }
        public FullDto(EmployeeDto eDto, ShiftDto sDto)
        {
            FirstName = eDto.FirstName;
            LastName = eDto.LastName;
            EmployeeNumber = eDto.EmployeeNumber;
            StartTime = sDto.StartTime;
            EndTime = sDto.EndTime;
            IsEnded = sDto.IsEnded;
        }
    }
}
