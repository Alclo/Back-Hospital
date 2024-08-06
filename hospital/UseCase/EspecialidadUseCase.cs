using hospital.DTO;

namespace hospital.UseCase
{
        public interface EspecialidadUseCase
        {

            /**
             * Este codigo se genero con Arquitecto MVC.
             * Este m\u00E9todo declara las reglas de negocio  
             * de alta en la tabla Doctor
             */

            EspecialidadDTO insertEspecialidad(EspecialidadDTO pEspecialidad);

            /**
             * Este codigo se genero con Arquitecto MVC.
             * Este m\u00E9todo declara las reglas de negocio 
             * para seleccion de un registro en  
             * la tabla Doctor
             * mediante la llave primaria 	
             */
            EspecialidadDTO getByIdEspecialidad(EspecialidadDTO pEspecialidad);

            /**
             * Este codigo se genero con Arquitecto MVC.
             * Este m\u00E9todo ejecuta las reglas de negocio 
             * para dar de baja fisicamente un registro en  
             * la tabla Doctor
             * mediante la llave primaria 	
             */
            EspecialidadDTO deleteEspecialidad(EspecialidadDTO pEspecialidad);


            /**
             * Este codigo se genero con Arquitecto MVC.
             * Este m\u00E9todo declara las reglas de negocio 
             * para actualizar un registro en  
             * la tabla Doctor
             * mediante la llave primaria 	
             */
            EspecialidadDTO updateEspecialidad(EspecialidadDTO pEspecialidad);

            /**
             * Este codigo se genero con Arquitecto MVC.
             * Este m\u00E9todo declara las reglas de negocio 
             * para seleccion de registros en  
             * la tabla Doctor 
             * dependiendo de las propiedades del parametro 	
             */
            List<EspecialidadDTO> selectByExampleEspecialidad(string? pCriterio);
        }
}
