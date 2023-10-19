using System;
using System.Collections.Generic;

namespace PRG4_M6_P1_KEL6.Models;

public partial class DataPetuga
{
    public string Nim { get; set; } = null!;

    public string Nama { get; set; } = null!;

    public string Prodi { get; set; } = null!;

    public string NoTelp { get; set; } = null!;

    public int Status { get; set; }

    public virtual Transaksi? Transaksi { get; set; }
}
