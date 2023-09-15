using InStepDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InStepDAL
{
    public class InStepRepository
    {
        InStepContext context;
        public InStepRepository()
        {
            context = new InStepContext();
        }

        public int RegisterCandidate(String firstname, String lastname,
                                       String emailid, String mobilenumber,
                                       String universityname, String degree,
                                       int academicyear, String course, decimal cgpa, String skills,
                                       DateTime availablestart, byte[] resume, params int[] projectCodes)
        {
            SqlParameter prmFirstname = new SqlParameter("@firstname", firstname);
            SqlParameter prmLastname = new SqlParameter("@lastname", lastname);
            SqlParameter prmEmailid = new SqlParameter("@emailid", emailid);
            SqlParameter prmMobilenumber = new SqlParameter("@mobilenumber", mobilenumber);
            SqlParameter prmUniversityname = new SqlParameter("@universityname", universityname);
            SqlParameter prmDegree = new SqlParameter("@degree", degree);
            SqlParameter prmAcademicyear = new SqlParameter("@academicyear", academicyear);
            SqlParameter prmCourse = new SqlParameter("@course", course);
            SqlParameter prmCgpa = new SqlParameter("@cgpa", cgpa);
            SqlParameter prmSkills = new SqlParameter("@skills", skills);
            SqlParameter prmAvailablestart = new SqlParameter("@availablestart", availablestart);
            SqlParameter prmResume = new SqlParameter("@resume", resume);
            SqlParameter prmCid = new SqlParameter("@candidateid", System.Data.SqlDbType.Int);
            prmCid.Direction = System.Data.ParameterDirection.Output;

            context.Database.ExecuteSqlRaw("EXEC usp_ins_candidate_details @firstname,@lastname, @emailid, @mobilenumber, @universityname, @degree, @academicyear, @course, @cgpa, @skills, @availablestart, @resume, @candidateid OUT",
                                                   prmFirstname, prmLastname, prmEmailid, prmMobilenumber, prmUniversityname, prmDegree, prmAcademicyear, prmCourse, prmCgpa, prmSkills, prmAvailablestart, prmResume, prmCid);
            if ((int)prmCid.Value < 0)
            {
                return (int)prmCid.Value;
            }
            else
            {
                int returnValue;
                SqlParameter prmCandidateid = new SqlParameter("@candidateid", prmCid.Value);
                SqlParameter prmProjectcode = new SqlParameter("@projectcode", System.Data.SqlDbType.Int);
                foreach (int i in projectCodes)
                {
                    prmProjectcode.Value = i;
                    returnValue = context.Database.ExecuteSqlRaw("EXEC usp_ins_candidate_preference @candidateid, @projectcode", prmCandidateid, prmProjectcode);
                    if (returnValue == -1)
                        return -2;
                }
                return 1;
            }
        }

        public List<ProjectDetail> GetProjectDetails()
        {
            List<ProjectDetail> projectDetails = context.ProjectDetails.ToList();
            return projectDetails;
        }

        public int RaiseClaim(int internid, String claimtype, String claimname, int amount, byte[] proofdocument)
        {
            SqlParameter prmInternid = new SqlParameter("@internid", internid);
            SqlParameter prmClaimtype = new SqlParameter("@claimtype", claimtype);
            SqlParameter prmClaimname = new SqlParameter("@claimname", claimname);
            SqlParameter prmAmount = new SqlParameter("@amount", amount);
            SqlParameter prmProofdocument = new SqlParameter("@proofdocument", proofdocument);
            SqlParameter prmClaimid = new SqlParameter("@claimid", System.Data.SqlDbType.Int);
            prmClaimid.Direction = System.Data.ParameterDirection.Output;

            context.Database.ExecuteSqlRaw("EXEC usp_ins_claim_details @internid,@claimtype, @claimname, @amount, @proofdocument, @claimid OUT",
                                                   prmInternid, prmClaimtype, prmClaimname, prmAmount, prmProofdocument, prmClaimid);
             return (int)prmClaimid.Value;
            
        }
    }
}
