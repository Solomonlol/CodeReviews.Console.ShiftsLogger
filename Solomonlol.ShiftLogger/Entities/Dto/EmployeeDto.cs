using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShiftLogger.Backend.Entities.Dto
{
    internal class EmployeeDto
    {
        [Required(ErrorMessage = "First name not specified")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name not specified")]
        [StringLength(50)]
        public string LastName { get; set; }

        
        [Range(1, 999999, ErrorMessage ="User identification number should be on 1-999999 range")]
        public int EmployeeNumber { get; set; }
    }
}
