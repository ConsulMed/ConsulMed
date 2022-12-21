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

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (agendamentoEntidadeBanco == null || DBNull.Value.Equals(agendamentoEntidadeBanco.IdAgendamento) || agendamentoEntidadeBanco.IdAgendamento == 0)
            {
                return 0;
            }

            Entidade.Agendamento agendamentoEntidade = new Entidade.Agendamento()
            {
                IdAgendamento = cadastrarDto.IdAgendamento,
                IdHospital = cadastrarDto.IdHospital,
                IdEspecialidade = cadastrarDto.IdEspecialidade,
                IdProfissional = cadastrarDto.IdProfissional
                DataHoraAgendamento = cadastrarDto.DataHoraAgendamento,
                IdBeneficiario = cadastrarDto.IdBeneficiario,
                Ativo = cadastrarDto.Ativo,

            };

            _contexto.ChangeTracker.Clear();
            _contexto.Agendamentos.Update(agendamentoEntidade);
            return _contexto.SaveChanges();
        }

        public int AtualizarId()
        {
            throw new NotImplementedException();
        }

        public int Cadastrar(BeneficiarioDto cadastrarDto)
        {
            Entidade.Beneficiario beneficiarioEntidade = new Entidade.Beneficiario()
            {
                Nome = cadastrarDto.Nome,
                Cpf = cadastrarDto.Cpf,
                Telefone = cadastrarDto.Telefone,
                Endereco = cadastrarDto.Endereco,
                NumeroCarteirinha = cadastrarDto.NumeroCarteirinha,
                Ativo = cadastrarDto.Ativo,
                Email = cadastrarDto.Email,
                Senha = cadastrarDto.Senha
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Beneficiarios.Add(beneficiarioEntidade);
            return _contexto.SaveChanges();
        }

        public int Excluir(int idBeneficiario)
        {
            Entidade.Beneficiario beneficiarioEntidadeBanco =
                (from c in _contexto.Beneficiarios
                 where c.IdBeneficiario == idBeneficiario
                 select c).FirstOrDefault();

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (beneficiarioEntidadeBanco == null || DBNull.Value.Equals(beneficiarioEntidadeBanco.IdBeneficiario) || beneficiarioEntidadeBanco.IdBeneficiario == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Beneficiarios.Remove(beneficiarioEntidadeBanco);
            return _contexto.SaveChanges();
        }

        public List<Dto.BeneficiarioDto> ListarTodas()
        {
            return _contexto.Beneficiarios.Select(s => new Dto.BeneficiarioDto()
            {
                IdBeneficiario = s.IdBeneficiario,
                Nome = s.Nome
            }).ToList();
        }

        public BeneficiarioDto PorId(int id)
        {
            return (from t in _contexto.Beneficiarios
                    where t.IdBeneficiario == id
                    select new Dto.BeneficiarioDto()
                    {
                        IdBeneficiario = t.IdBeneficiario,
                        Nome = t.Nome
                    })
                    ?.FirstOrDefault()
                    ?? new BeneficiarioDto();
        }
    }
}
