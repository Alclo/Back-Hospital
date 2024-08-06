namespace hospital.DTO
{
    public class PacienteDTO
    {
        public PacienteDTO() { }
        public PacienteDTO(int Id,string? Nombre,string? Sexo,string? Curp,DateOnly FechaNacimiento,string? Telefono,string? Direccion,
            string? Aseguradora,DateTime FechaRegistro) {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Sexo = Sexo;
            this.Curp = Curp;
            this.FechaNacimiento = FechaNacimiento;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Aseguradora = Aseguradora;
            this.FechaRegistro = FechaRegistro;
        }
        public int Id { get; set; }

        public string? Nombre { get; set; } = null!;
        public string? Sexo { get; set; } = null!;
        public string? Curp { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string? Telefono { get; set; } = null!;
        public string? Direccion { get; set; } = null!;
        public string? Aseguradora { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
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
}

