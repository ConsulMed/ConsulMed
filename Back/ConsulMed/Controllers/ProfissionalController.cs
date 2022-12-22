using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsulMed.Data.Dto;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ConsulMed.Data.Repositorio;
using ConsulMed.Data.Interface;
using ConsulMed.Data.Entidade;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsulMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly ConsulMed.Data.Interface.IProfissionalRepositorio _profissionalRepositorio;

        public ProfissionalController(
            ConsulMed.Data.Interface.IProfissionalRepositorio profissionalRepositorio)
        {
            _profissionalRepositorio = profissionalRepositorio;
        }

        // GET: api/<ProfissionalController>
        [HttpGet]
        [Route("/[controller]/ListarTodosProfissionais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsulMed.Data.Dto.ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodosProfissionais()
        {
            try
            {
                List<ProfissionalDto> resultado = _profissionalRepositorio.ListarTodosProfissionais();

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

        // GET api/<ProfissionalController>/5
        [HttpGet]
        [Route("/[controller]/ConsultarProfissionalPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsulMed.Data.Dto.ProfissionalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                ProfissionalDto resultado = _profissionalRepositorio.ConsultarProfissionalPorId(id);

                if (resultado == null)
                    return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProfissionalController>
        [HttpPost]
        [Route("/[controller]/CadastrarProfissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarProfissional(ProfissionalDto cadastrarDto)
        {
            try
            {
                int cadastro = _profissionalRepositorio.CadastrarProfissional(cadastrarDto);

                if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                    return NoContent();

                return Ok(cadastro);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ProfissionalController>/5
        [HttpPut]
        [Route("/[controller]/AtualizarProfissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(ProfissionalDto cadastrarDto)
        {
            try
            {
                return Ok(_profissionalRepositorio.AtualizarProfissional(cadastrarDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        [Route("/[controller]/ExcluirProfissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int IdProfissional)
        {
            try
            {
                return Ok(_profissionalRepositorio.ExcluirProfissional(IdProfissional));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
