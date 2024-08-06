namespace hospital.DTO
{
    public class DoctorDTO
    {
        public DoctorDTO() { }
        public DoctorDTO(int Id,string? Nombre,int Edad,string? Curp, string? Telefono,string? Direccion,string? Cedula,int EspecialidadId,int HospitalId) {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Curp = Curp;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Cedula = Cedula;
            this.EspecialidadId = EspecialidadId;
            this.HospitalId = HospitalId;
        }
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int Edad { get; set; }

        public string? Curp { get; set; } = null!;

        public string? Telefono { get; set; } = null!;

        public string? Direccion { get; set; } = null!;

        public string? Cedula { get; set; } = null!;

        public int EspecialidadId { get; set; }

        public int HospitalId { get; set; }
    }
}
