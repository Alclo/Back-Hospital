using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hospital.Domain;

public partial class Consulta
{
    [Key]
    public int Id { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string Tratamiento { get; set; } = null!;

    public int CitaId { get; set; }

    public virtual Cita Cita { get; set; } = null!;
}
