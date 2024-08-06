using Microsoft.AspNetCore.Mvc;
using hospital.UseCase;
using hospital.DTO;
using hospital.Domain;

namespace hospital.Controllers
{

    [Route("Hospital")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalUseCase pacienteUseCase;

        public HospitalController(HospitalUseCase pacienteUseCase)
        {
            this.pacienteUseCase = pacienteUseCase;
        }
 
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpGet("seleccionaHospital/{pIdHospital}")]
        public ActionResult<HospitalDTO> seleccionaHospital(int pIdHospital)
        {
            var pHospital = new HospitalDTO();

            pHospital.Id = pIdHospital;

            pHospital = this.pacienteUseCase.getByIdHospital(pHospital);
            return Ok(pHospital);
        }

        [HttpGet("buscaHospital/{pCriterio}")]
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<List<Hospital>> buscaHospital(string? pCriterio)
        {
            var banco = pacienteUseCase.selectByExampleHospital(pCriterio);
            return Ok(banco);
        }

        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPost("agregaHospital")]
        public ActionResult<HospitalDTO> agregaHospital(HospitalDTO pHospital)
        {
            this.pacienteUseCase.insertHospital(pHospital);
            return Ok(pHospital);
        }

        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPut("actualizaHospital/{pIdHospital}")]
        public ActionResult<HospitalDTO> actualizaHospital(int pIdHospital, HospitalDTO pHospital)
        {
            if (pHospital.Id.Equals(pIdHospital))
            {
                this.pacienteUseCase.updateHospital(pHospital);
                return Ok(pHospital);
            }
            return BadRequest();
        }
  
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpDelete("eliminaHospital/{pIdHospital}")]

        public ActionResult<HospitalDTO> eliminaHospital(int pIdHospital, HospitalDTO pHospital)
        {
            if (pHospital.Id.Equals(pIdHospital))
            {
                this.pacienteUseCase.deleteHospital(pHospital);
                return Ok(pHospital);
            }
            return BadRequest();
        }
    }
}
