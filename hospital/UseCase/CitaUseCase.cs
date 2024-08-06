using hospital.DTO;

namespace hospital.UseCase
{
    public interface CitaUseCase
    {
        CitaDTO insertCita(CitaDTO pCita);

        CitaDTO getByIdCita(CitaDTO pCita);

        CitaDTO deleteCita(CitaDTO pCita);

        CitaDTO updateCita(CitaDTO pCita);

        List<CitaDTO> selectByExampleCita(string? pCriterio);

    }
}