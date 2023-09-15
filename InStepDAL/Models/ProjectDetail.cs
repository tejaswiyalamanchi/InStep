using System;
using System.Collections.Generic;

namespace InStepDAL.Models;

public partial class ProjectDetail
{
    public int ProjectCode { get; set; }

    public string ProjectName { get; set; } = null!;

    public string TechnologyName { get; set; } = null!;

    public int Duration { get; set; }

    public string? Details { get; set; }

    public virtual ICollection<InternDetail> InternDetails { get; set; } = new List<InternDetail>();

    public virtual ICollection<MentorDetail> MentorDetails { get; set; } = new List<MentorDetail>();
}
