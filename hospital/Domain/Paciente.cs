using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hospital.Domain;

public partial class Paciente
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Curp { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Aseguradora { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public string Patologico { get; set; } = null!;

    public string NoPatologico { get; set; } = null!;

    public string Hereditario { get; set; } = null!;

    public string Responsable { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
