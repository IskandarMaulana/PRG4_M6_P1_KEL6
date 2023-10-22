using System;
using System.Collections.Generic;

namespace PRG4_M6_P1_KEL6.Models;

public partial class Transaksi
{
    public string Nim { get; set; } = null!;

    public DateTime? Tanggal { get; set; }

    public string? Jobdesk { get; set; }

    public string? WaktuSholat { get; set; }

    public virtual DataPetuga NimNavigation { get; set; } = null!;
}
