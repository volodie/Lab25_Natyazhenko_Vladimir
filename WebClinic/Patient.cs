using System;
using System.Collections.Generic;

namespace WebClinic;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public string PatientSurname { get; set; } = null!;

    public int HealingPlanId { get; set; }

    public virtual ICollection<PatientCard> PatientCards { get; } = new List<PatientCard>();
}
