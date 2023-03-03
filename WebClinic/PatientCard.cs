using System;
using System.Collections.Generic;

namespace WebClinic;

public partial class PatientCard
{
    public int CardId { get; set; }

    public int IdPatient { get; set; }

    public int IdDoctor { get; set; }

    public int HealingPlan { get; set; }

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Patient IdPatientNavigation { get; set; } = null!;
}
