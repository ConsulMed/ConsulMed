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
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly Contexto.ConsulMedContext _contexto;

        public ProfissionalRepositorio(Contexto.ConsulMedContext contexto)
        {
            _contexto = contexto;
        }

        public int AtualizarProfissional(ProfissionalDto cadastrarDto)
        {
            Entidade.Profissional profissionalEntidadeBanco =
                (from c in _contexto.Profissional
                 where c.IdProfissional == cadastrarDto.IdProfissional
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidade.Profissional();

            if (profissionalEntidadeBanco == null || DBNull.Value.Equals(profissionalEntidadeBanco.IdProfissional) || profissionalEntidadeBanco.IdProfissional == 0)
            {
                return 0;
            }

            profissionalEntidadeBanco.Nome = cadastrarDto.Nome;
            profissionalEntidadeBanco.Telefone = cadastrarDto.Telefone;
            profissionalEntidadeBanco.Endereco = cadastrarDto.Endereco;
            profissionalEntidadeBanco.Ativo = cadastrarDto.Ativo;

            _contexto.ChangeTracker.Clear();
            _contexto.Profissional.Update(profissionalEntidadeBanco);
            return _contexto.SaveChanges();
        }

        public int CadastrarProfissional(ProfissionalDto cadastrarDto)
        {
            Entidade.Profissional profissionalEntidade = new Entidade.Profissional()
            {
                Nome = cadastrarDto.Nome,
                Telefone = cadastrarDto.Telefone,
                Endereco = cadastrarDto.Endereco,
                Ativo = cadastrarDto.Ativo,
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Profissional.Add(profissionalEntidade);
            return _contexto.SaveChanges();
        }

        public int ExcluirProfissional(int idProfissional)
        {
            Entidade.Profissional profissionalEntidadeBanco =
                 (from c in _contexto.Profissional
                  where c.IdProfissional == idProfissional
                  select c).FirstOrDefault();

            if (profissionalEntidadeBanco == null || DBNull.Value.Equals(profissionalEntidadeBanco.IdProfissional) || profissionalEntidadeBanco.IdProfissional == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Profissional.Remove(profissionalEntidadeBanco);
            return _contexto.SaveChanges();
        }

        public List<Dto.ProfissionalDto> ListarTodosProfissionais()
        {
            return _contexto.Profissional.Select(s => new Dto.ProfissionalDto()
            {
                IdProfissional = s.IdProfissional,
                Nome = s.Nome,
                Telefone = s.Telefone,
                Endereco = s.Endereco,
                Ativo = s.Ativo
            }).ToList();
        }

        public ProfissionalDto ConsultarProfissionalPorId(int id)
        {
            return (from t in _contexto.Profissional
                    where t.IdProfissional == id
                    select new Dto.ProfissionalDto()
                    {
                        IdProfissional = t.IdProfissional,
                        Nome = t.Nome,
                        Telefone = t.Telefone,
                        Endereco = t.Endereco,
                        Ativo = t.Ativo
                    })
                    ?.FirstOrDefault()
                    ?? new ProfissionalDto();
        }
    }
}
