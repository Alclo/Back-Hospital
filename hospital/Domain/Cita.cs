using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.Domain;

public partial class Cita
{
    [Key]
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int PacienteId { get; set; }

    public int DoctorId { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;
}
