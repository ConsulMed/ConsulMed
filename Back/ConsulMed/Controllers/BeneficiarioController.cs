using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsulMed.Data.Dto;
using System.Data;
using System.Data.SqlClient;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsulMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarioController : ControllerBase
    {
        private readonly ConsulMed.Data.Interface.IBeneficiarioRepositorio _beneficiarioRepositorio;

        public BeneficiarioController(
            ConsulMed.Data.Interface.IBeneficiarioRepositorio beneficiarioRepositorio)
        {
            _beneficiarioRepositorio = beneficiarioRepositorio;
        }

        [HttpGet]
        [Route("/ListarTodas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsulMed.Data.Dto.BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodas()
        {
            try
            {
                List<BeneficiarioDto> resultado = _beneficiarioRepositorio.ListarTodas();

                if (resultado == null)
                {
                    return NoContent();
                }

                if (resultado.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/PorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsulMed.Data.Dto.BeneficiarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                BeneficiarioDto resultado = _beneficiarioRepositorio.PorId(id);

                if (resultado == null)
                    return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(BeneficiarioDto cadastrarDto)
        {
            try
            {
                int resultado = _beneficiarioRepositorio.Cadastrar(cadastrarDto);

                if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                    return NoContent();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        [Route("/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(BeneficiarioDto cadastrarDto)
        {
            try
            {
                return Ok(_beneficiarioRepositorio.Atualizar(cadastrarDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        [Route("/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int IdBeneficiario)
        {
            try
            {
                return Ok(_beneficiarioRepositorio.Excluir(IdBeneficiario));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
