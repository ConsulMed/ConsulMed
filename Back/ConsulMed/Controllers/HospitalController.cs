using ConsulMed.Data.Dto;
using ConsulMed.Data.Entidade;
using ConsulMed.Data.Interface;
using ConsulMed.Data.Repositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsulMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly ConsulMed.Data.Interface.IHospitalRepositorio _hospitalRepositorio;

        public HospitalController(
            ConsulMed.Data.Interface.IHospitalRepositorio hospitalRepositorio)
        {
            _hospitalRepositorio = hospitalRepositorio;
        }

        [HttpGet]
        [Route("/ListarTodosHospitais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Dto.HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodosHospitais()
        {
            try
            {
                List<HospitalDto> listarHospitais = _hospitalRepositorio.ConsultarTodos();

                if (listarHospitais == null)
                {
                    return NoContent();
                }

                if (listarHospitais.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(listarHospitais);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("/Hospital/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Dto.HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Hospital(int id)
        {
            try
            {
                HospitalDto listarHospital = _hospitalRepositorio.ConsultarPorId(id);

                if (id < 1 || listarHospital == null)
                    return NoContent();

                return Ok(listarHospital);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("/CadastrarHospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarHospital (HospitalDto cadastroDto)
        {
            try
            {
                int cadastro = _hospitalRepositorio.CadastrarHospital(cadastroDto);

                if (cadastroDto == null || String.IsNullOrEmpty(cadastroDto.Nome))
                    return NoContent();

                return Ok(cadastro);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("/EditarHospital/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarHospital(HospitalDto cadastroDto)
        {
            try
            {
                return Ok(_hospitalRepositorio.AtualizarHospital(cadastroDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("/ExcluirHospital/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemoverHospital(int id)
        {
            try
            {
                return Ok(_hospitalRepositorio.RemoverHospital(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            } 
        }
    }
}
