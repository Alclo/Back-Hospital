using Microsoft.AspNetCore.Mvc;
using hospital.UseCase;
using hospital.DTO;
using hospital.Domain;

namespace hospital.Controllers
{

    [Route("Paciente")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteUseCase consultaUseCase;

        public PacienteController(PacienteUseCase consultaUseCase)
        {
            this.consultaUseCase = consultaUseCase;
        }
 
        [ProducesResponseType(typeof(PacienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpGet("seleccionaPaciente/{pIdPaciente}")]
        public ActionResult<PacienteDTO> seleccionaPaciente(int pIdPaciente)
        {
            var pPaciente = new PacienteDTO();

            pPaciente.Id = pIdPaciente;

            pPaciente = this.consultaUseCase.getidPaciente(pPaciente);
            return Ok(pPaciente);
        }

        [HttpGet("buscaPaciente/{pCriterio}")]
        [ProducesResponseType(typeof(PacienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<List<Paciente>> buscaPaciente(string? pCriterio)
        {
            var banco = consultaUseCase.selectByExamplePaciente(pCriterio);
            return Ok(banco);
        }

        [ProducesResponseType(typeof(PacienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPost("agregaPaciente")]
        public ActionResult<PacienteDTO> agregaPaciente(PacienteDTO pPaciente)
        {
            this.consultaUseCase.insertPaciente(pPaciente);
            return Ok(pPaciente);
        }

        [ProducesResponseType(typeof(PacienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPut("actualizaPaciente/{pIdPaciente}")]
        public ActionResult<PacienteDTO> actualizaPaciente(int pIdPaciente, PacienteDTO pPaciente)
        {
            if (pPaciente.Id.Equals(pIdPaciente))
            {
                this.consultaUseCase.updatePaciente(pPaciente);
                return Ok(pPaciente);
            }
            return BadRequest();
        }
  
        [ProducesResponseType(typeof(PacienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpDelete("eliminaPaciente/{pIdPaciente}")]

        public ActionResult<PacienteDTO> eliminaPaciente(int pIdPaciente, PacienteDTO pPaciente)
        {
            if (pPaciente.Id.Equals(pIdPaciente))
            {
                this.consultaUseCase.deletePaciente(pPaciente);
                return Ok(pPaciente);
            }
            return BadRequest();
        }
    }
}
