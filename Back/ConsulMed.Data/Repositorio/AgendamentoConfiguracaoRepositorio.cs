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

        public AgendamentoConfiguracaoRepositorio(Contexto.ConsulMedContext contexto)
        {
            _contexto = contexto;
        }

        public int Atualizar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            Entidade.AgendamentoConfiguracao agendamentoConfiguracaoEntidadeBanco =
                (from c in _contexto.AgendamentoConfiguracaos
                 where c.IdConfiguracao == cadastrarDto.IdConfiguracao
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidade.AgendamentoConfiguracao();


            if (agendamentoConfiguracaoEntidadeBanco == null || DBNull.Value.Equals(agendamentoConfiguracaoEntidadeBanco.IdConfiguracao) || agendamentoConfiguracaoEntidadeBanco.IdConfiguracao == 0)
            {
                return 0;
            }
            agendamentoConfiguracaoEntidadeBanco.IdConfiguracao = cadastrarDto.IdConfiguracao;
            agendamentoConfiguracaoEntidadeBanco.IdHospital = cadastrarDto.IdHospital;
            agendamentoConfiguracaoEntidadeBanco.IdEspecialidade = cadastrarDto.IdEspecialidade;
            agendamentoConfiguracaoEntidadeBanco.IdProfissional = cadastrarDto.IdProfissional;
            agendamentoConfiguracaoEntidadeBanco.DataHoraInicioAtendimento = cadastrarDto.DataHoraInicioAtendimento;
            agendamentoConfiguracaoEntidadeBanco.DataHoraFinalAtendimento = cadastrarDto.DataHoraFinalAtendimento;

            _contexto.ChangeTracker.Clear();
            _contexto.AgendamentoConfiguracaos.Update(agendamentoConfiguracaoEntidadeBanco);
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
                DataHoraInicioAtendimento = cadastrarDto.DataHoraInicioAtendimento,
                DataHoraFinalAtendimento = cadastrarDto.DataHoraFinalAtendimento
            };

            _contexto.ChangeTracker.Clear();
            _contexto.AgendamentoConfiguracaos.Add(agendamentoConfiguracaoEntidade);
            return _contexto.SaveChanges();

        }

        public int Excluir(int idAgendamentoConfiguracao)
        {
            Entidade.AgendamentoConfiguracao agendamentoConfiguracaoEntidadeBando =
                (from c in _contexto.AgendamentoConfiguracaos
                 where c.IdConfiguracao == idAgendamentoConfiguracao
                 select c).FirstOrDefault();


            if (agendamentoConfiguracaoEntidadeBando == null || DBNull.Value.Equals(agendamentoConfiguracaoEntidadeBando.IdConfiguracao) || agendamentoConfiguracaoEntidadeBando.IdConfiguracao == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.AgendamentoConfiguracaos.Remove(agendamentoConfiguracaoEntidadeBando);
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
                DataHoraInicioAtendimento = s.DataHoraInicioAtendimento,
                DataHoraFinalAtendimento = s.DataHoraFinalAtendimento,
            }).ToList();
        }

        public AgendamentoConfiguracaoDto PorId(int id)
        {
            return (from t in _contexto.AgendamentoConfiguracaos
                    where t.IdConfiguracao == id
                    select new Dto.AgendamentoConfiguracaoDto()
                    {
                        IdConfiguracao = t.IdConfiguracao,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdProfissional = t.IdProfissional,
                        DataHoraInicioAtendimento = t.DataHoraInicioAtendimento,
                        DataHoraFinalAtendimento = t.DataHoraFinalAtendimento,
                    })
                    ?.FirstOrDefault()
                    ?? new AgendamentoConfiguracaoDto();
        }
    }
}
