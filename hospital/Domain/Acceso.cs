using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace hospital.Domain;

public partial class Acceso
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;
}
