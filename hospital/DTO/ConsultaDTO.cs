namespace hospital.DTO
{
    public class ConsultaDTO
    {
        public ConsultaDTO() { }
        public ConsultaDTO(int Id,string? Diagnostico,string? Tratamiento,int CitaId) {
            this.Id = Id;
            this.Diagnostico = Diagnostico;
            this.Tratamiento = Tratamiento;
            this.CitaId = CitaId;
        }
        public int Id { get; set; }

        public string? Diagnostico { get; set; } = null!;

        public string? Tratamiento { get; set; } = null!;

        public int CitaId { get; set; }
    }
}
