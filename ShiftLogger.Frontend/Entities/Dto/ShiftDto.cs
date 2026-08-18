using System.ComponentModel.DataAnnotations;

namespace ShiftLogger.Frontend.Entities.Dto
{
    internal class ShiftDto
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsEnded { get; set; }
    }
}
