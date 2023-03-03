using System;
using System.Collections.Generic;

namespace WebClinic;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DeparmentTitle { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
}
