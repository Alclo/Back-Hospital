using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hospital.Domain;

public partial class Especialidad
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
