using ConsulMed.Data.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsulMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoConfiguracaoController : ControllerBase
    {
        private readonly ConsulMed.Data.Interface.IAgendamentoConfiguracaoRepositorio _agendamentoConfiguracaoRepositorio;
        
        public AgendamentoConfiguracaoController(
            ConsulMed.Data.Interface.IAgendamentoConfiguracaoRepositorio agendamentoConfiguracaoRepositorio)
        {
            _agendamentoConfiguracaoRepositorio = agendamentoConfiguracaoRepositorio;
        }

        [HttpGet]
        [Route("/[controller]/ListarTodas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsulMed.Data.Dto.AgendamentoConfiguracaoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodas()
        {
            try
            {
                List<AgendamentoConfiguracaoDto> resultado = _agendamentoConfiguracaoRepositorio.ListarTodas();

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
        [Route("/[controller]/PorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsulMed.Data.Dto.AgendamentoConfiguracaoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                AgendamentoConfiguracaoDto resultado = _agendamentoConfiguracaoRepositorio.PorId(id);

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
        [Route("/[controller]/Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            try
            {
                int resultado = _agendamentoConfiguracaoRepositorio.Cadastrar(cadastrarDto);

                if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.IdConfiguracao.ToString()))
                    return NoContent();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("/[controller]/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            try
            {
                return Ok(_agendamentoConfiguracaoRepositorio.Atualizar(cadastrarDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        [Route("/[controller]/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int IdAgendamentoConfiguracao)
        {
            try
            {
                return Ok(_agendamentoConfiguracaoRepositorio.Excluir(IdAgendamentoConfiguracao));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
