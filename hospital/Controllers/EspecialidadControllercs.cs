using hospital.Domain;
using hospital.DTO;
using hospital.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("Especialidad")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly EspecialidadUseCase especialidadUseCase;

        /// <summary>
        /// Constructor default, inyecta el objeto de negocio
        /// </summary>  

        public EspecialidadController(EspecialidadUseCase especialidadUseCase)
        {
            this.especialidadUseCase =  especialidadUseCase;
        }




        /// <summary>
        /// Obtiene un  registro de Banco por identificador primario
        /// </summary>  
        /// <remarks>
        /// Obtiene un  registro de Banco por identificador primario
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo EspecialidadDTO.class </returns>   
        [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpGet("seleccionaEspecialidad/{pIdEspecialidad}")]
        public ActionResult<EspecialidadDTO> seleccionaEspecialidad(int pIdEspecialidad)
        {
            var pEspecialidad = new EspecialidadDTO();

            pEspecialidad.Id = pIdEspecialidad;

            pEspecialidad = this.especialidadUseCase.getByIdEspecialidad(pEspecialidad);
            return Ok(pEspecialidad);
        }




        /// <summary>
        /// Busca un registro Banco que tengan coincidencia con el criterio de busqueda 
        /// </summary>  
        /// <remarks>
        /// Busca un registro Banco que tengan coincidencia con el criterio de busqueda 
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo EmpleadoDTO.class </returns> 
        [HttpGet("buscaEspecialidad/{pCriterio}")]
        [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<List<Especialidad>> buscaEspecialidad(string? pCriterio)
        {
            var banco = especialidadUseCase.selectByExampleEspecialidad(pCriterio);
            return Ok(banco);
        }




        /// <summary>
        /// Inserta un registro Banco 
        /// </summary>  
        /// <remarks>
        /// Los campos obligatorios
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo EspecialidadDTO.class </returns>   
        [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPost("agregaEspecialidad")]
        public ActionResult<EspecialidadDTO> agregaEspecialidad(EspecialidadDTO pEspecialidad)
        {
            this.especialidadUseCase.insertEspecialidad(pEspecialidad);
            return Ok(pEspecialidad);
        }




        /// <summary>
        /// Actualiza un registro Banco 
        /// </summary>  
        /// <remarks>
        /// Los campos obligatorios
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo EspecialidadDTO.class </returns>   
        [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPut("actualizaEspecialidad/{pIdEspecialidad}")]
        public ActionResult<EspecialidadDTO> actualizaEspecialidad(string pIdEspecialidad, EspecialidadDTO pEspecialidad)
        {
            if (pEspecialidad.Id.Equals(pIdEspecialidad))
            {
                this.especialidadUseCase.updateEspecialidad(pEspecialidad);
                return Ok(pEspecialidad);
            }
            return BadRequest();
        }




        /// <summary>
        /// Inactiva un registro Banco 
        /// </summary>  
        /// <remarks>
        /// Los campos obligatorios
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo EspecialidadDTO.class </returns>   
        [ProducesResponseType(typeof(EspecialidadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpDelete("eliminaEspecialidad/{pIdEspecialidad}")]

        public ActionResult<EspecialidadDTO> eliminaEspecialidad(string pIdEspecialidad, EspecialidadDTO pEspecialidad)
        {
            if (pEspecialidad.Id.Equals(pIdEspecialidad))
            {
                this.especialidadUseCase.deleteEspecialidad(pEspecialidad);
                return Ok(pEspecialidad);
            }
            return BadRequest();
        }
    }
}
