using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Interface
{
    public interface IEspecialidadeRepositorio
    {
        List<Dto.EspecialidadeDto> ConsultarTodos();
        Dto.EspecialidadeDto ConsultarPorId(int idEspecialidade);
        int AtualizarEspecialidade(Dto.EspecialidadeDto beneficiario);
        int CadastrarEspecialidade(Dto.EspecialidadeDto cadastrarDto);
        int RemoverEspecialidade(int idEspecialidade);
    }
}
