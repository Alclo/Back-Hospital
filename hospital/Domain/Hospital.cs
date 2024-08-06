using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hospital.Domain;

public partial class Hospital
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Rfc { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
