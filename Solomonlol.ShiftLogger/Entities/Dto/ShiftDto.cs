using System.ComponentModel.DataAnnotations;

namespace ShiftLogger.Backend.Entities.Dto
{
    internal class ShiftDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsEnded { get; set; }
    }
}
