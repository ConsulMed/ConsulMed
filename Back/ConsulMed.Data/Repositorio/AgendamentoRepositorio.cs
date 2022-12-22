using ConsulMed.Data.Dto;
using ConsulMed.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Repositorio
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly Contexto.ConsulMedContext _contexto;

        public AgendamentoRepositorio(Contexto.ConsulMedContext contexto)
        {
            _contexto = contexto;
        }

        public int Atualizar(AgendamentoDto cadastrarDto)
        {
            Entidade.Agendamento agendamentoEntidadeBanco =
                (from c in _contexto.Agendamentos
                 where c.IdAgendamento == cadastrarDto.IdAgendamento
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidade.Agendamento();

            if (agendamentoEntidadeBanco == null || DBNull.Value.Equals(agendamentoEntidadeBanco.IdAgendamento) || agendamentoEntidadeBanco.IdAgendamento == 0)
            {
                return 0;
            }
            agendamentoEntidadeBanco.IdAgendamento = cadastrarDto.IdAgendamento;
            agendamentoEntidadeBanco.IdHospital = cadastrarDto.IdHospital;
            agendamentoEntidadeBanco.IdEspecialidade = cadastrarDto.IdEspecialidade;
            agendamentoEntidadeBanco.IdProfissional = cadastrarDto.IdProfissional;
            agendamentoEntidadeBanco.DataHoraAgendamento = cadastrarDto.DataHoraAgendamento;
            agendamentoEntidadeBanco.IdBeneficiario = cadastrarDto.IdBeneficiario;
            agendamentoEntidadeBanco.Ativo = cadastrarDto.Ativo;

            _contexto.ChangeTracker.Clear();
            _contexto.Agendamentos.Update(agendamentoEntidade);
            return _contexto.SaveChanges();
        }

        public int Cadastrar(AgendamentoDto cadastrarDto)
        {
            Entidade.Agendamento agendamentoEntidade = new Entidade.Agendamento()
            {
                IdAgendamento = cadastrarDto.IdAgendamento,
                IdHospital = cadastrarDto.IdHospital,
                IdEspecialidade = cadastrarDto.IdEspecialidade,
                IdProfissional = cadastrarDto.IdProfissional,
                DataHoraAgendamento = cadastrarDto.DataHoraAgendamento,
                Ativo = cadastrarDto.Ativo,
                IdBeneficiario = cadastrarDto.IdBeneficiario,
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Agendamentos.Add(agendamentoEntidade);
            return _contexto.SaveChanges();
        }

        public int Excluir(int idAgendamento)
        {
            Entidade.Agendamento agendamentoEntidadeBanco =
                (from c in _contexto.Agendamentos
                 where c.IdAgendamento == idAgendamento
                 select c).FirstOrDefault();

            if (agendamentoEntidadeBanco == null || DBNull.Value.Equals(agendamentoEntidadeBanco.IdAgendamento) || agendamentoEntidadeBanco.IdAgendamento == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Agendamentos.Remove(agendamentoEntidadeBanco);
            return _contexto.SaveChanges();
        }

        public List<Dto.AgendamentoDto> ListarTodas()
        {
            return _contexto.Agendamentos.Select(s => new Dto.AgendamentoDto()
            {
                IdAgendamento = s.IdAgendamento,
                IdHospital = s.IdHospital,
                IdEspecialidade = s.IdEspecialidade,
                IdProfissional = s.IdProfissional,
                DataHoraAgendamento = s.DataHoraAgendamento,
                IdBeneficiario = s.IdBeneficiario,
                Ativo = s.Ativo,
            }).ToList();
        }

        public AgendamentoDto PorId(int id)
        {
            return (from t in _contexto.Agendamentos
                    where t.IdAgendamento == id
                    select new Dto.AgendamentoDto()
                    {
                        IdAgendamento = t.IdAgendamento,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdProfissional = t.IdProfissional,
                        DataHoraAgendamento = t.DataHoraAgendamento,
                        IdBeneficiario = t.IdBeneficiario,
                        Ativo = t.Ativo,
                    })
                    ?.FirstOrDefault()
                    ?? new AgendamentoDto();
        }
    }
}
