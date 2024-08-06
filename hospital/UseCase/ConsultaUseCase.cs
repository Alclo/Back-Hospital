using hospital.DTO;

namespace hospital.UseCase
{
    public interface ConsultaUseCase
    {
        ConsultaDTO insertConsulta(ConsultaDTO pConsulta);

        ConsultaDTO getByIdConsulta(ConsultaDTO pConsulta);

        ConsultaDTO deleteConsulta(ConsultaDTO pConsulta);

        ConsultaDTO updateConsulta(ConsultaDTO pConsulta);

        List<ConsultaDTO> selectByExampleConsulta(string? pCriterio);
    }
}
