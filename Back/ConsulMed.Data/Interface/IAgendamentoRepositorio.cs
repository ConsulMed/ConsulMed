using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Interface
{
    public interface IAgendamentoRepositorio
    {
        List<Dto.AgendamentoDto> ListarTodas();
        Dto.AgendamentoDto PorId(int idAgendamento);
        int Atualizar(Dto.AgendamentoDto cadastrarDto);
        int Cadastrar(Dto.AgendamentoDto cadastrarDto);
        int Excluir(int idAgendamento);
    }
}
