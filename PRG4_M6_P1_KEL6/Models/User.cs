using System;
using System.Collections.Generic;

namespace PRG4_M6_P1_KEL6.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Nama { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Alamat { get; set; }

    public string? NoTelp { get; set; }

    public int Status { get; set; }
}
