namespace hospital.DTO
{
    public class CitaDTO
    {
        public CitaDTO() { }
        public CitaDTO(int Id,DateTime Fecha,int PacienteId,int DoctorId) {
            this.Id = Id;
            this.Fecha = Fecha;
            this.PacienteId = PacienteId;
            this.DoctorId = DoctorId;  
        }
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int PacienteId { get; set; }

        public int DoctorId { get; set; }
    }
}
