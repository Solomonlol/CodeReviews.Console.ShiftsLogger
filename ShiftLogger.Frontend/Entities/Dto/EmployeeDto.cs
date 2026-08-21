using System.ComponentModel.DataAnnotations;

namespace ShiftLogger.Frontend.Entities.Dto
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "First Name is required. Please fill in this field!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters long.")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "First name must contain only letters of the English and Russian alphabet.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required. Please fill in this field!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters long.")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Last name must contain only letters of the English and Russian alphabet.")]
        public string LastName { get; set; }

        
        [Range(1, 999999, ErrorMessage ="User identification number should be on 1-999999 range")]
        public int EmployeeNumber { get; set; }

        public EmployeeDto() { }
        public EmployeeDto(string firstName, string lastName, int employeeNumber)
        {
            
            FirstName = firstName;
            LastName = lastName;
            EmployeeNumber = employeeNumber;
        }
    }
}
