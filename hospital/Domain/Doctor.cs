using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hospital.Domain;

public partial class Doctor
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string Curp { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public int EspecialidadId { get; set; }

    public int HospitalId { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Especialidad Especialidad { get; set; } = null!;

    public virtual Hospital Hospital { get; set; } = null!;
}
