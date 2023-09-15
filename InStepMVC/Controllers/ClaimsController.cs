using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using InStepDAL;

namespace InStepMVC.Controllers
{
    public class ClaimsController : Controller
    {
        InStepRepository repObj;

        public ClaimsController()
        {
            repObj = new InStepRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RaiseClaimAsync(Models.Claim claim)
        {
            byte[] data = null;
            using (var dataStream = new MemoryStream())
            {
                await claim.ProofDocument.CopyToAsync(dataStream);
                data = dataStream.ToArray();
            }
            //User.Identity.GetUserId();
            int returnValue = repObj.RaiseClaim(claim.InternId, claim.ClaimType, claim.ClaimName, claim.Amount, data);
            if (returnValue == -1)
            {
                return View("InvalidInternId");
            }
            else if (returnValue == -2)
            {
                return View("../Register/SomethingWentWrong");
            }
            else
            {
                return View("SuccessfulClaim");
            }
        }
    }
}
