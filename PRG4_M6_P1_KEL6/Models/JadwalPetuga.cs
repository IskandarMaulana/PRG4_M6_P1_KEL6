using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRG4_M6_P1_KEL6.Models;

public partial class JadwalPetuga
{
    public int Id { get; set; }

    public string Nim { get; set; } = null!;

    public string Tugas { get; set; } = null!;

    public string WaktuTugas { get; set; } = null!;

    public virtual DataPetuga NimNavigation { get; set; } = null!;
}
