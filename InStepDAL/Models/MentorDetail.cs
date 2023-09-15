using System;
using System.Collections.Generic;

namespace InStepDAL.Models;

public partial class MentorDetail
{
    public int MentorId { get; set; }

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public int? ProjectCode { get; set; }

    public virtual ICollection<InternDetail> InternDetails { get; set; } = new List<InternDetail>();

    public virtual ProjectDetail? ProjectCodeNavigation { get; set; }
}
