using hospital.DTO;

namespace hospital.UseCase
{
    public interface DoctorUseCase
    {


        DoctorDTO insertDoctor(DoctorDTO pDoctor);

        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo declara las reglas de negocio 
         * para seleccion de un registro en  
         * la tabla Doctor
         * mediante la llave primaria 	
         */
        DoctorDTO getByIdDoctor(DoctorDTO pDoctor);

        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo ejecuta las reglas de negocio 
         * para dar de baja fisicamente un registro en  
         * la tabla Doctor
         * mediante la llave primaria 	
         */
        DoctorDTO deleteDoctor(DoctorDTO pDoctor);


        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo declara las reglas de negocio 
         * para actualizar un registro en  
         * la tabla Doctor
         * mediante la llave primaria 	
         */
        DoctorDTO updateDoctor(DoctorDTO pDoctor);

        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo declara las reglas de negocio 
         * para seleccion de registros en  
         * la tabla Doctor 
         * dependiendo de las propiedades del parametro 	
         */
        List<DoctorDTO> selectByExampleDoctor(string? pCriterio);
    }
}
