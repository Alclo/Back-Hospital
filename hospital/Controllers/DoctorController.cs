using Microsoft.AspNetCore.Mvc;
using hospital.UseCase;
using hospital.DTO;
using hospital.Domain;

namespace hospital.Controllers
{
    [Route("Doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorUseCase doctorUseCase;

        public DoctorController(DoctorUseCase doctorUseCase)
        {
            this.doctorUseCase = doctorUseCase;
        }

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

        [HttpGet("buscaDoctor/{pCriterio}")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<List<Doctor>> buscaDoctor(string? pCriterio)
        {
            var banco = doctorUseCase.selectByExampleDoctor(pCriterio);
            return Ok(banco);
        }
 
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpPost("agregaDoctor")]
        public ActionResult<DoctorDTO> agregaDoctor(DoctorDTO pDoctor)
        {
            this.doctorUseCase.insertDoctor(pDoctor);
            return Ok(pDoctor);
        }
 
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
 
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [HttpDelete("eliminaDoctor/{pIdDoctor}")]
<<<<<<< HEAD
=======

>>>>>>> 66289edbc18442e3fcf200f51bb2194ecdce5672
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
