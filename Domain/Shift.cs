using ShiftsLoggerApp.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShiftsLoggerApp.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required")]
        
        public DateTime Date { get; set; }
        public DateTime? StartTime { get; set; }

        [DateGreaterThan("StartTime")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "Has Lunch Break")]

        [MaxLength(15, ErrorMessage = "Department cannot exceed 15 characters")]
        public string? Department { get; set; }
        public bool HasLunchBreak { get; set; }
        public double TotalTime { get; set; }

        [ForeignKey("Worker")]
        [Display(Name = "Worker ID")]
        public int WorkerId { get; set; }
    }
}
