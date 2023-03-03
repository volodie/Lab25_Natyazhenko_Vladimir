using System;
using System.Collections.Generic;

namespace WebClinic;

public partial class Job
{
    public int JobTitleId { get; set; }

    public string JobTitle { get; set; } = null!;

    public decimal Salary { get; set; }

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
}
