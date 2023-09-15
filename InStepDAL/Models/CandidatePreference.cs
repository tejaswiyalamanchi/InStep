using System;
using System.Collections.Generic;

namespace InStepDAL.Models;

public partial class CandidatePreference
{
    public int CandidateId { get; set; }

    public int ProjectCode { get; set; }

    public virtual CandidateDetail Candidate { get; set; } = null!;

    public virtual ProjectDetail ProjectCodeNavigation { get; set; } = null!;
}
