namespace InStepMVC.Models
{
    public class RegisterModel
    {
        public CandidateDetail candidate { get; set; }
        public IEnumerable<ProjectDetail> projectDetails { get; set; }
    }
}
