using hospital.DTO;

namespace hospital.UseCase
{
    public interface DoctorUseCase
    {
        DoctorDTO insertDoctor(DoctorDTO pDoctor);

        DoctorDTO getByIdDoctor(DoctorDTO pDoctor);

        DoctorDTO deleteDoctor(DoctorDTO pDoctor);

        DoctorDTO updateDoctor(DoctorDTO pDoctor);

        List<DoctorDTO> selectByExampleDoctor(string? pCriterio);
    }
}
