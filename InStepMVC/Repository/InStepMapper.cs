using AutoMapper;
using InStepDAL.Models;

namespace InStepMVC.Repository
{
    public class InStepMapper:Profile
    {
        public InStepMapper() 
        {
            CreateMap<ProjectDetail, Models.ProjectDetail>();
        }
    }
}
