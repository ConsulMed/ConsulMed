using ConsulMed.Data.Contexto;
using ConsulMed.Data.Dto;
using ConsulMed.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Repositorio
{
    public class BeneficiarioRepositorio : IBeneficiarioRepositorio
    {
        private readonly Contexto.ConsulMedContext _contexto;

        public BeneficiarioRepositorio(Contexto.ConsulMedContext contexto)
        {
            _contexto = contexto;
        }

        public int Atualizar(BeneficiarioDto cadastrarDto)
        {
            Entidade.Beneficiario beneficiarioEntidadeBanco =
                (from c in _contexto.Beneficiarios
                 where c.IdBeneficiario == cadastrarDto.IdBeneficiario
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidade.Beneficiario();

            if (beneficiarioEntidadeBanco == null || DBNull.Value.Equals(beneficiarioEntidadeBanco.IdBeneficiario) || beneficiarioEntidadeBanco.IdBeneficiario == 0)
            {
                return 0;
            }

            beneficiarioEntidadeBanco.Nome = cadastrarDto.Nome;
            beneficiarioEntidadeBanco.Cpf = cadastrarDto.Cpf;
            beneficiarioEntidadeBanco.Telefone = cadastrarDto.Telefone;
            beneficiarioEntidadeBanco.Endereco = cadastrarDto.Endereco;
            beneficiarioEntidadeBanco.NumeroCarteirinha = cadastrarDto.NumeroCarteirinha;
            beneficiarioEntidadeBanco.Ativo = cadastrarDto.Ativo;
            beneficiarioEntidadeBanco.Email = cadastrarDto.Email;
            beneficiarioEntidadeBanco.Senha = cadastrarDto.Senha;

            _contexto.ChangeTracker.Clear();
            _contexto.Beneficiarios.Update(beneficiarioEntidadeBanco);
            return _contexto.SaveChanges();
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
                Nome = s.Nome,
                Cpf = s.Cpf,
                Telefone = s.Telefone,
                Endereco = s.Endereco,
                NumeroCarteirinha = s.NumeroCarteirinha,
                Ativo = s.Ativo,
                Email = s.Email,
                Senha = s.Senha
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
