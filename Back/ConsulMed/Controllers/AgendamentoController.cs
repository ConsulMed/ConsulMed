using ConsulMed.Data.Dto;
using ConsulMed.Data.Interface;
using ConsulMed.Data.Repositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsulMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly ConsulMed.Data.Interface.IAgendamentoRepositorio _agendamentoRepositorio;

        public AgendamentoController(
            ConsulMed.Data.Interface.IAgendamentoRepositorio agendamentoRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        [HttpGet]
        [Route("/ListarTodas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsulMed.Data.Dto.AgendamentoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodas()
        {
            try
            {
                List<AgendamentoDto> resultado = _agendamentoRepositorio.ListarTodas();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsulMed.Data.Dto.AgendamentoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                AgendamentoDto resultado = _agendamentoRepositorio.PorId(id);

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
        public IActionResult Cadastrar(AgendamentoDto cadastrarDto)
        {
            try
            {
                int resultado = _agendamentoRepositorio.Cadastrar(cadastrarDto);

                if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.IdAgendamento.ToString()))
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
        public IActionResult Atualizar(AgendamentoDto cadastrarDto)
        {
            try
            {
                return Ok(_agendamentoRepositorio.Atualizar(cadastrarDto));
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
        public IActionResult Excluir(int IdAgendamento)
        {
            try
            {
                return Ok(_agendamentoRepositorio.Excluir(IdAgendamento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
