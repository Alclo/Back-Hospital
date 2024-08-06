namespace hospital.DTO
{
    public class EspecialidadDTO
    {
        public EspecialidadDTO() { }
        public EspecialidadDTO(int Id,string Nombre) {
            this.Id = Id;
            this.Nombre = Nombre;  
        }
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
