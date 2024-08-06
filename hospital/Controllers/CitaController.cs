using Microsoft.AspNetCore.Mvc;
using hospital.UseCase;
using hospital.DTO;
using hospital.Domain;

namespace hospital.Controllers
{

    [Route("Cita")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaUseCase citaUseCase;

        public CitaController(CitaUseCase citaUseCase)
        {
            this.citaUseCase = citaUseCase;
        }
 
        [ProducesResponseType(typeof(CitaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpGet("seleccionaCita/{pIdCita}")]
        public ActionResult<CitaDTO> seleccionaCita(int pIdCita)
        {
            var pCita = new CitaDTO();

            pCita.Id = pIdCita;

            pCita = this.citaUseCase.getByIdCita(pCita);
            return Ok(pCita);
        }

        [HttpGet("buscaCita/{pCriterio}")]
        [ProducesResponseType(typeof(CitaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<List<Cita>> buscaCita(string? pCriterio)
        {
            var banco = citaUseCase.selectByExampleCita(pCriterio);
            return Ok(banco);
        }

        [ProducesResponseType(typeof(CitaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPost("agregaCita")]
        public ActionResult<CitaDTO> agregaCita(CitaDTO pCita)
        {
            this.citaUseCase.insertCita(pCita);
            return Ok(pCita);
        }

        [ProducesResponseType(typeof(CitaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPut("actualizaBanco/{pIdCita}")]
        public ActionResult<CitaDTO> actualizaCita(string pIdCita, CitaDTO pCita)
        {
            if (pCita.Id.Equals(pIdCita))
            {
                this.citaUseCase.updateCita(pCita);
                return Ok(pCita);
            }
            return BadRequest();
        }
  
        [ProducesResponseType(typeof(CitaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpDelete("eliminaCita/{pIdCita}")]

        public ActionResult<CitaDTO> eliminaCita(string pIdCita, CitaDTO pCita)
        {
            if (pCita.Id.Equals(pIdCita))
            {
                this.citaUseCase.deleteCita(pCita);
                return Ok(pCita);
            }
            return BadRequest();
        }
    }
}
