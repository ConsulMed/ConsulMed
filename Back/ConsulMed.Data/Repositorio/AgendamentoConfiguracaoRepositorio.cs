using ConsulMed.Data.Dto;
using ConsulMed.Data.Entidade;
using ConsulMed.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Repositorio
{
    public class AgendamentoConfiguracaoRepositorio : IAgendamentoConfiguracaoRepositorio
    {
        private readonly Contexto.ConsulMedContext _contexto;
        private AgendamentoConfiguracao agendamentoConfiguracaoEntidade;
        private AgendamentoConfiguracao agendamentoConfiguracaoEntidadeBanco;

        public AgendamentoConfiguracaoRepositorio(Contexto.ConsulMedContext contexto)
        {
            _contexto = contexto;
        }

        public int Atualizar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            Entidade.AgendamentConfiguracao agendamentoConfiguracaoEntidadeBanco =
                (from c in _contexto.AgendamentoConfiguracaos
                 where c.IdConfiguracao == cadastrarDto.IdConfiguracao
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidade.AgendamentoConfiguracao();


            if (agendamentoConfiguracaoEntidadeBanco == null || DBNull.Value.Equals(agendamentoConfiguracaoEntidadeBanco.IdAgendamento) || agendamentoConfiguracaoEntidadeBanco.IdAgendamento == 0)
            {
                return 0;
            }
            agendamentoConfiguracaoEntidadeBanco.IdConfiguracao = cadastrarDto.IdConfiguracao;
            agendamentoConfiguracaoEntidadeBanco.IdHospital = cadastrarDto.IdHospital;
            agendamentoConfiguracaoEntidadeBanco.IdEspecialidade = cadastrarDto.IdEspecialidade;
            agendamentoConfiguracaoEntidadeBanco.IdProfissional = cadastrarDto.IdProfissional;
            agendamentoConfiguracaoEntidadeBanco.DataHoraAgendamento = cadastrarDto.DataHoraAgendamento;
            agendamentoConfiguracaoEntidadeBanco.DataHoraFimAgendamento = cadastrarDto.DataHoraFimAgendamento;

            _contexto.ChangeTracker.Clear();
            _contexto.AgendamentoConfiguracaos.Update(agendamentoConfiguracaoEntidade);
            return _contexto.SaveChanges();
        }

        public int Cadastrar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            Entidade.AgendamentoConfiguracao agendamentoConfiguracaoEntidade = new Entidade.AgendamentoConfiguracao()
            {
                IdConfiguracao = cadastrarDto.IdConfiguracao,
                IdHospital = cadastrarDto.IdHospital,
                IdEspecialidade = cadastrarDto.IdEspecialidade,
                IdProfissional = cadastrarDto.IdProfissional,
                DataHoraAgendamento = cadastrarDto.DataHoraAgendamento,
                DataHoraFinalAgendamento = cadastrarDto.DataHoraFinalAgendamento
            };

            _contexto.ChangeTracker.Clear();
            _contexto.AgendamentoConfiguracaos.Add(agendamentoConfiguracaoEntidade);
            return _contexto.SaveChanges();
        }

        public int Excluir(int idAgendamentoConfiguracao)
        {
            Entidade.AgendamentoConfiguracao agendamentoConfiguracaoEntidadeBando =
                (from c in _contexto.AgendamentoConfiguracaos
                 where c.IdAgendamentoConfiguracao == idAgendamentoConfiguracao
                 select c).FirstOrDefault();


            if (agendamentoConfiguracaoEntidadeBanco == null || DBNull.Value.Equals(agendamentoConfiguracaoEntidadeBanco.IdAgendamentoConfiguracao) || agendamentoConfiguracaoEntidadeBanco.IdAgendamentoConfiguracao == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.AgendamentoConfiguracaos.Remove(agendamentoConfiguracaoEntidadeBanco);
            return _contexto.SaveChanges();
        }

        public List<Dto.AgendamentoConfiguracaoDto> ListarTodas()
        {
            return _contexto.AgendamentoConfiguracaos.Select(s => new Dto.AgendamentoConfiguracaoDto()
            {
                IdConfiguracao = s.IdConfiguracao,
                IdHospital = s.IdHospital,
                IdEspecialidade = s.IdEspecialidade,
                IdProfissional = s.IdProfissional,
                DataHoraAgendamento = s.DataHoraAgendamento,
                DataHoraFinalAtendimento = s.DataHoraFinalAtendimento,
            }).ToList();
        }

        public AgendamentoConfiguracaoDto PorId(int id)
        {
            return (from t in _contexto.AgendamentoConfiguracaos
                    where t.IdAgendamentoConfiguracao == id
                    select new Dto.AgendamentoConfiguracaoDto()
                    {
                        IdConfiguracao = t.IdConfiguracao,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdProfissional = t.IdProfissional,
                        DataHoraAgendamento = t.DataHoraAgendamento,
                        DataHoraFinalAtendimento = t.DataHoraFinalAtendimento,
                    })
                    ?.FirstOrDefault()
                    ?? new BeneficiarioDto();
        }
    }
}
