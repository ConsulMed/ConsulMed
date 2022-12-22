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
    public class EspecialidadeRepositorio : IEspecialidadeRepositorio

    {
        private readonly Contexto.ConsulMedContext _contexto;

        public EspecialidadeRepositorio(Contexto.ConsulMedContext contexto)
        {
            _contexto = contexto;
        }

        public List<Dto.EspecialidadeDto> ConsultarTodos()
        {
            return _contexto.Especialidades.Select(h => new Dto.EspecialidadeDto()
            {
                Ativo = h.Ativo,
                Descrição = h.Descrição,
                IdEspecialidade = h.IdEspecialidade,
                Nome = h.Nome,

            }).ToList();
        }

        public EspecialidadeDto ConsultarPorId(int idEspecialidade)
        {
            return (from h in _contexto.Especialidades
                    where h.IdEspecialidade == idEspecialidade
                    select new Dto.EspecialidadeDto()
                    {
                        IdEspecialidade = h.IdEspecialidade,
                        Nome = h.Nome
                    })
                    ?.FirstOrDefault()
                    ?? new EspecialidadeDto();
        }

        public int CadastrarEspecialidade(EspecialidadeDto cadastroDto)
        {
            Especialidade especialidade = new Especialidade()
            {
                Nome = cadastroDto.Nome,
                Ativo = cadastroDto.Ativo,
                Descrição = cadastroDto.Descrição,
                IdEspecialidade = cadastroDto.IdEspecialidade,

            };

            _contexto.ChangeTracker.Clear();
            _contexto.Especialidades.Add(especialidade);
            return _contexto.SaveChanges();
        }

        public int AtualizarEspecialidade(EspecialidadeDto cadastroDto)
        {
            Especialidade especialidade =
                (from h in _contexto.Especialidades
                 where h.IdEspecialidade == cadastroDto.IdEspecialidade
                 select h)
                 ?.FirstOrDefault()
                 ?? new Especialidade();

            if (especialidade == null || DBNull.Value.Equals(especialidade.IdEspecialidade) || especialidade.IdEspecialidade == 0)
            {
                return 0;
            }

            especialidade.Nome = cadastroDto.Nome;
            especialidade.Ativo = cadastroDto.Ativo;
            especialidade.Descrição = cadastroDto.Descrição;
            especialidade.IdEspecialidade = cadastroDto.IdEspecialidade;


            _contexto.ChangeTracker.Clear();
            _contexto.Especialidades.Update(especialidade);
            return _contexto.SaveChanges();
        }

        public int RemoverEspecialidade(int id)
        {
            Especialidade especialidade =
                (from h in _contexto.Especialidades
                 where h.IdEspecialidade == id
                 select h)
                 ?.FirstOrDefault()
                 ?? new Especialidade();

            if (especialidade == null || DBNull.Value.Equals(especialidade.IdEspecialidade) || especialidade.IdEspecialidade == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Especialidades.Remove(especialidade);
            return _contexto.SaveChanges();
        }
    }
}