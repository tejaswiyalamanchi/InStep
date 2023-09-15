using AutoMapper;
using InStepDAL;
using InStepDAL.Models;
using InStepMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InStepMVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        InStepRepository repObj;

        public RegisterController(IMapper mapper)
        {
            repObj = new InStepRepository();
            _mapper = mapper;
        }

        public ActionResult IndexViewData()
        {
            RegisterModel registerModel = new RegisterModel();
            registerModel.candidate = new InStepMVC.Models.CandidateDetail();
            registerModel.projectDetails = GetProjectDetails();
            return View(registerModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCandidateAsync(Models.CandidateDetail candidate, int[] projects)
        {
            byte[] data = null;
            using (var dataStream = new MemoryStream())
            {
                await candidate.Resume.CopyToAsync(dataStream);
                 data = dataStream.ToArray();
            }

            int returnValue = repObj.RegisterCandidate(candidate.FirstName, candidate.LastName, candidate.EmailId, candidate.MobileNumber,
                                    candidate.UniversityName,candidate.Degree, candidate.AcademicYear, candidate.Course, candidate.Cgpa, candidate.Skills,candidate.AvailableStart,data, projects);
            if(returnValue == -1)
            {
                return View("AlreadyRegistered");
            }
            else if(returnValue == -2)
            {
                return View("SomethingWentWrong");
            }
            else
            {
                return View("SuccessfullRegistration");
            }
        }

        
        public List<Models.ProjectDetail> GetProjectDetails() 
        {
            List<InStepDAL.Models.ProjectDetail> projects = repObj.GetProjectDetails();
            List<Models.ProjectDetail> projectDetails = new List<Models.ProjectDetail>();
            foreach (var p in projects)
            {
                projectDetails.Add(_mapper.Map<Models.ProjectDetail>(p));
            }
            return projectDetails;
        }

    }
}
