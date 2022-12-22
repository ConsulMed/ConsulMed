using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Interface
{
    public interface IAgendamentoConfiguracaoRepositorio
    {
        List<Dto.AgendamentoConfiguracaoDto> ListarTodas();
        Dto.AgendamentoConfiguracaoDto PorId(int idAgendamentoConfiguracao);
        int Atualizar(Dto.AgendamentoConfiguracaoDto cadastrarDto);
        int Cadastrar(Dto.AgendamentoConfiguracaoDto cadastrarDto);
        int Excluir(int idAgendamentoConfiguracao);
    }
}
