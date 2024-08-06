namespace hospital.DTO
{
    public class PacienteDTO
    {
        public PacienteDTO() { }
        public PacienteDTO(int Id,string? Nombre,string? Sexo,string? Curp,DateOnly FechaNacimiento,string? Telefono,string? Direccion,
            string? Aseguradora,DateOnly FechaRegistro,Patologico patologico,NoPatologico noPatologico,Hereditario hereditario,Responsable responsable) {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Sexo = Sexo;
            this.Curp = Curp;
            this.FechaNacimiento = FechaNacimiento;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Aseguradora = Aseguradora;
            this.FechaRegistro = FechaRegistro;
            this.Patologico = patologico;
            this.NoPatologico = noPatologico;
            this.Hereditario = hereditario;
            this.Responsable = responsable;

        }
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string Curp { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Aseguradora { get; set; } = null!;
        public DateOnly FechaRegistro { get; set; }
        public Patologico Patologico { get; set; } = null!;
        public NoPatologico NoPatologico { get; set; } = null!;
        public Hereditario Hereditario { get; set; } = null!;
        public Responsable Responsable { get; set; } = null!;
    }


    public class Patologico
    {
        public bool Cirugia { get; set; }
        public bool Tabaquismo { get; set; }
        public bool Alergias { get; set; }
        public bool Alcoholismo { get; set; }
        public bool DepenciaDrogas { get; set; }
        public bool Farmacodependencias { get; set; }
        public string Otro { get; set; }
    }

    public class Hereditario
    {
        public bool Diabetes { get; set; }
        public bool Hipertension { get; set; }
        public bool Cardiopatia { get; set; }
        public bool Cancer { get; set; }
        public string Otro { get; set; }
        public string TipoFamilia { get; set; }
    }

    public class NoPatologico
    {
        public string EstadoCivil { get; set; }
        public string Escolaridad { get; set; }
        public string Ocupacion { get; set; }
        public string Alimentacion { get; set; }
        public bool ActividadFisica { get; set; }
        public string FactorRiesgoLaboral { get; set; }
        public string HigienePersonal { get; set; }

    }

    public class Responsable
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

    }
}

