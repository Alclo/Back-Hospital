using Microsoft.AspNetCore.Mvc;
using hospital.UseCase;
using hospital.DTO;
using hospital.Domain;

namespace hospital.Controllers
{
    /// <summary>
    /// Clase BancoController que atiende las peticiones para llevar a cabo 
    ///  las operaciones para la entidad banco
    /// </summary>  

    [Route("Doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorUseCase doctorUseCase;

        /// <summary>
        /// Constructor default, inyecta el objeto de negocio
        /// </summary>  

        public DoctorController(DoctorUseCase doctorUseCase)
        {
            this.doctorUseCase = doctorUseCase;
        }




        /// <summary>
        /// Obtiene un  registro de Banco por identificador primario
        /// </summary>  
        /// <remarks>
        /// Obtiene un  registro de Banco por identificador primario
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo DoctorDTO.class </returns>   
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpGet("seleccionaDoctor/{pIdDoctor}")]
        public ActionResult<DoctorDTO> seleccionaDoctor(int pIdDoctor)
        {
            var pDoctor = new DoctorDTO();

            pDoctor.Id = pIdDoctor;

            pDoctor = this.doctorUseCase.getByIdDoctor(pDoctor);
            return Ok(pDoctor);
        }




        /// <summary>
        /// Busca un registro Banco que tengan coincidencia con el criterio de busqueda 
        /// </summary>  
        /// <remarks>
        /// Busca un registro Banco que tengan coincidencia con el criterio de busqueda 
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo EmpleadoDTO.class </returns> 
        [HttpGet("buscaDoctor/{pCriterio}")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<List<Doctor>> buscaDoctor(string? pCriterio)
        {
            var banco = doctorUseCase.selectByExampleDoctor(pCriterio);
            return Ok(banco);
        }




        /// <summary>
        /// Inserta un registro Banco 
        /// </summary>  
        /// <remarks>
        /// Los campos obligatorios
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo DoctorDTO.class </returns>   
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPost("agregaDoctor")]
        public ActionResult<DoctorDTO> agregaDoctor(DoctorDTO pDoctor)
        {
            this.doctorUseCase.insertDoctor(pDoctor);
            return Ok(pDoctor);
        }




        /// <summary>
        /// Actualiza un registro Banco 
        /// </summary>  
        /// <remarks>
        /// Los campos obligatorios
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo DoctorDTO.class </returns>   
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPut("actualizaBanco/{pIdDoctor}")]
        public ActionResult<DoctorDTO> actualizaDoctor(string pIdDoctor, DoctorDTO pDoctor)
        {
            if (pDoctor.Id.Equals(pIdDoctor))
            {
                this.doctorUseCase.updateDoctor(pDoctor);
                return Ok(pDoctor);
            }
            return BadRequest();
        }




        /// <summary>
        /// Inactiva un registro Banco 
        /// </summary>  
        /// <remarks>
        /// Los campos obligatorios
        /// </remarks>  
        /// <returns> Retorna un objeto del tipo DoctorDTO.class </returns>   
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpDelete("eliminaDoctor/{pIdDoctor}")]

        public ActionResult<DoctorDTO> eliminaDoctor(string pIdDoctor, DoctorDTO pDoctor)
        {
            if (pDoctor.Id.Equals(pIdDoctor))
            {
                this.doctorUseCase.deleteDoctor(pDoctor);
                return Ok(pDoctor);
            }
            return BadRequest();
        }
    }
}
