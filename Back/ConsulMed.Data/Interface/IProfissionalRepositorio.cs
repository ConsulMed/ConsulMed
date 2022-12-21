using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsulMed.Data;
using ConsulMed.Data.Dto;

namespace ConsulMed.Data.Interface
{
    public interface IProfissionalRepositorio
    {
        List<Dto.ProfissionalDto> ListarTodosProfissionais();
        Dto.ProfissionalDto ConsultarProfissionalPorId(int idProfissional);
        int AtualizarProfissional(Dto.ProfissionalDto profissional);
        int CadastrarProfissional(Dto.ProfissionalDto cadastrarDto);
        int ExcluirProfissional(int idProfissional);
    }
}
