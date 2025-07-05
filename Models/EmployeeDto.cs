using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models
{
    public class EmployeeDto
    {
        [Required]
        public String Fname { get; set; }

        [Required]
        public String Lname { get; set; }

        [Required]
        public String EmailId { get; set; }

        [Required]
        public String PhoneNumber { get; set; }
        public String Address { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }
        public IFormFile? ImageFile { get; set; } 

    }
}
