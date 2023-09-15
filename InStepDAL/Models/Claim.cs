using System;
using System.Collections.Generic;

namespace InStepDAL.Models;

public partial class Claim
{
    public int ClaimId { get; set; }

    public int InternId { get; set; }

    public string ClaimType { get; set; } = null!;

    public string ClaimName { get; set; } = null!;

    public int Amount { get; set; }

    public string Status { get; set; } = null!;

    public byte[] ProofDocument { get; set; } = null!;

    public virtual InternDetail Intern { get; set; } = null!;
}
