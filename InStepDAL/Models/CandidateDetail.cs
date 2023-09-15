using System;
using System.Collections.Generic;

namespace InStepDAL.Models;

public partial class CandidateDetail
{
    public int CandidateId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string UniversityName { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public int AcademicYear { get; set; }

    public string Course { get; set; } = null!;

    public decimal Cgpa { get; set; }

    public string Skills { get; set; } = null!;

    public DateTime AvailableStart { get; set; }

    public byte[] Resume { get; set; } = null!;
}
