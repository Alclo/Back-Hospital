using Microsoft.AspNetCore.Mvc;
using hospital.UseCase;
using hospital.DTO;
using hospital.Domain;

namespace hospital.Controllers
{

    [Route("Consulta")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaUseCase consultaUseCase;

        public ConsultaController(ConsultaUseCase consultaUseCase)
        {
            this.consultaUseCase = consultaUseCase;
        }
 
        [ProducesResponseType(typeof(ConsultaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpGet("seleccionaConsulta/{pIdConsulta}")]
        public ActionResult<ConsultaDTO> seleccionaConsulta(int pIdConsulta)
        {
            var pConsulta = new ConsultaDTO();

            pConsulta.Id = pIdConsulta;

            pConsulta = this.consultaUseCase.getByIdConsulta(pConsulta);
            return Ok(pConsulta);
        }

        [HttpGet("buscaConsulta/{pCriterio}")]
        [ProducesResponseType(typeof(ConsultaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<List<Consulta>> buscaConsulta(string? pCriterio)
        {
            var banco = consultaUseCase.selectByExampleConsulta(pCriterio);
            return Ok(banco);
        }

        [ProducesResponseType(typeof(ConsultaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPost("agregaConsulta")]
        public ActionResult<ConsultaDTO> agregaConsulta(ConsultaDTO pConsulta)
        {
            this.consultaUseCase.insertConsulta(pConsulta);
            return Ok(pConsulta);
        }

        [ProducesResponseType(typeof(ConsultaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPut("actualizaBanco/{pIdConsulta}")]
        public ActionResult<ConsultaDTO> actualizaConsulta(string pIdConsulta, ConsultaDTO pConsulta)
        {
            if (pConsulta.Id.Equals(pIdConsulta))
            {
                this.consultaUseCase.updateConsulta(pConsulta);
                return Ok(pConsulta);
            }
            return BadRequest();
        }
  
        [ProducesResponseType(typeof(ConsultaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpDelete("eliminaConsulta/{pIdConsulta}")]

        public ActionResult<ConsultaDTO> eliminaConsulta(string pIdConsulta, ConsultaDTO pConsulta)
        {
            if (pConsulta.Id.Equals(pIdConsulta))
            {
                this.consultaUseCase.deleteConsulta(pConsulta);
                return Ok(pConsulta);
            }
            return BadRequest();
        }
    }
}
