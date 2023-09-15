using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace InStepMVC.Models
{
    public class CandidateDetail
    {
        [Required(ErrorMessage = "Please enter First name")]
        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter Last name")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter email id")]
        [RegularExpression("([A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4})", ErrorMessage ="Please enter valid email id")]
        public string EmailId { get; set; } = null!;

        [Required(ErrorMessage = "Please enter mobile number")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Enter mobile number in valid format.")]
        public string MobileNumber { get; set; } = null!;

        [Required(ErrorMessage = "Please enter University name")]
        [StringLength(150)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string UniversityName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your degree")]
        [StringLength(30)]
        public string Degree { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your current academic year")]
        [Range(1, 6, ErrorMessage = "Enter valid academic year")]
        public int AcademicYear { get; set; }

        [Required(ErrorMessage = "Please enter your course")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string Course { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your CGPA")]
        [Range(0,10,ErrorMessage ="CGPA should be between 0 and 10")]
        public decimal Cgpa { get; set; }

        [Required(ErrorMessage = "Please enter your skills")]
        [StringLength(100)]
        public string Skills { get; set; } = null!;

        [Required(ErrorMessage = "Please enter when you will be available to start")]
        public DateTime AvailableStart { get; set; }

        [Required(ErrorMessage = "Please upload your resume")]
        public IFormFile Resume { get; set; } = null!;
    }
}
