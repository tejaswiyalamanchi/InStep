using System;
using System.Collections.Generic;

namespace InStepDAL.Models;

public partial class InternDetail
{
    public int InternId { get; set; }

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public int? MentorId { get; set; }

    public int? ProjectCode { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    public virtual MentorDetail? Mentor { get; set; }

    public virtual ProjectDetail? ProjectCodeNavigation { get; set; }
}
