using System.ComponentModel.DataAnnotations;

namespace ShiftsLoggerApp.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")] 
        public required string Name { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Department cannot exceed 15 characters")]
        public required string Department { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }
    }
}
