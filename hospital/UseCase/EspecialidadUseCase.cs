using hospital.DTO;

namespace hospital.UseCase
{
        public interface EspecialidadUseCase
        {
            EspecialidadDTO insertEspecialidad(EspecialidadDTO pEspecialidad);

            EspecialidadDTO getByIdEspecialidad(EspecialidadDTO pEspecialidad);

            EspecialidadDTO deleteEspecialidad(EspecialidadDTO pEspecialidad);

            EspecialidadDTO updateEspecialidad(EspecialidadDTO pEspecialidad);

            List<EspecialidadDTO> selectByExampleEspecialidad(string? pCriterio);
        }
}
