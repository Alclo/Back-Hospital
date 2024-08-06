namespace hospital.DTO
{
    public class HospitalDTO
    {
        public HospitalDTO() { 
        }
        public HospitalDTO(int Id,string? Nombre,string? RazonSocial,string? Direccion,string? Rfc,string? Telefono,string? Correo)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.RazonSocial = RazonSocial;
            this.Rfc = Rfc;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Correo = Correo;
        }
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? RazonSocial { get; set; }

        public string? Direccion { get; set; } 

        public string? Rfc { get; set; } 

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

    }
}
