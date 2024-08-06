using hospital.DTO;

namespace hospital.UseCase
{
    public interface HospitalUseCase
    {
        HospitalDTO insertHospital(HospitalDTO pHospital);

        HospitalDTO updateHospital(HospitalDTO phospital);

        HospitalDTO deleteHospital(HospitalDTO pHospital);

        HospitalDTO getByIdHospital(HospitalDTO pHospital);

        List<HospitalDTO> selectByExampleHospital(string? pCriterio);
    }
}