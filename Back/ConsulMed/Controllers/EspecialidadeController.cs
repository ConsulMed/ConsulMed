using ConsulMed.Data.Dto;
using ConsulMed.Data.Repositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsulMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly ConsulMed.Data.Interface.IEspecialidadeRepositorio _especialidadeRepositorio;

        public EspecialidadeController(
            ConsulMed.Data.Interface.IEspecialidadeRepositorio especialidadeRepositorio)
        {
            _especialidadeRepositorio = especialidadeRepositorio;
        }

        [HttpGet]
        [Route("/[controller]/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsulMed.Data.Dto.EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodas()
        {
            try
            {
                List<EspecialidadeDto> resultado = _especialidadeRepositorio.ConsultarTodos();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsulMed.Data.Dto.EspecialidadeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                EspecialidadeDto resultado = _especialidadeRepositorio.ConsultarPorId(id);

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
        public IActionResult Cadastrar(EspecialidadeDto cadastrarDto)
        {
            try
            {
                int resultado = _especialidadeRepositorio.CadastrarEspecialidade(cadastrarDto);

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
        [Route("/[controller]/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(EspecialidadeDto cadastrarDto)
        {
            try
            {
                return Ok(_especialidadeRepositorio.AtualizarEspecialidade(cadastrarDto));
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
        public IActionResult Excluir(int IdEspecialidade)
        {
            try
            {
                return Ok(_especialidadeRepositorio.RemoverEspecialidade(IdEspecialidade));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
