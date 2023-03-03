using System;
using System.Collections.Generic;

namespace WebClinic;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string DoctorSurname { get; set; } = null!;

    public int TitileJobId { get; set; }

    public int Iddepart { get; set; }

    public virtual Department IddepartNavigation { get; set; } = null!;

    public virtual ICollection<PatientCard> PatientCards { get; } = new List<PatientCard>();

    public virtual Job TitileJob { get; set; } = null!;
}
