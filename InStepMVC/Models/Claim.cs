using InStepDAL.Models;
using System.ComponentModel.DataAnnotations;

namespace InStepMVC.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        public int InternId { get; set; }

        [Required(ErrorMessage = "Please select claim type")]
        public string ClaimType { get; set; } = null!;

        [Required(ErrorMessage = "Please enter claim name")]
        public string ClaimName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter claim amount")]
        public int Amount { get; set; }

        public string Status { get; set; } = null!;

        public IFormFile ProofDocument { get; set; } = null!;

        public virtual InternDetail Intern { get; set; } = null!;
    }
}
