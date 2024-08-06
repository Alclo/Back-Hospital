using hospital.DTO;

namespace hospital.UseCase
{
    public interface PacienteUseCase
    {
        PacienteDTO insertPaciente(PacienteDTO pPaciente);
        PacienteDTO deletePaciente(PacienteDTO pPaciente);
        PacienteDTO updatePaciente(PacienteDTO pPaciente);
        PacienteDTO getidPaciente(PacienteDTO pPaciente);
        List<PacienteDTO> selectByExamplePaciente(string? pCriterio);
    }
}
