using ConsulMed.Data.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsulMed.Data.Dto;
using ConsulMed.Data.Entidade;
using Microsoft.EntityFrameworkCore;

namespace ConsulMed.Data.Repositorio
{
    public class HospitalRepositorio : IHospitalRepositorio
    {
        private readonly Contexto.ConsulMedContext _contexto;

        public HospitalRepositorio(Contexto.ConsulMedContext contexto)
        {
            _contexto = contexto;
        }

        public List<Dto.HospitalDto> ConsultarTodos()
        {
            return _contexto.Hospitals.Select(h => new Dto.HospitalDto()
            {
                IdHospital = h.IdHospital,
                Nome = h.Nome
            }).ToList();
        }

        public HospitalDto ConsultarPorId(int idHospital)
        {
            return (from h in _contexto.Hospitals
                    where h.IdHospital == idHospital
                    select new Dto.HospitalDto()
                    {
                        IdHospital = h.IdHospital,
                        Nome = h.Nome
                    })
                    ?.FirstOrDefault()
                    ?? new HospitalDto();
        }

        public int CadastrarHospital(HospitalDto cadastroDto)
        {
            Hospital hospital = new Hospital()
            {
                Nome = cadastroDto.Nome,
                Cnpj = cadastroDto.Cnpj,
                Endereço = cadastroDto.Endereço,
                Telefone = cadastroDto.Telefone,
                Cnes = cadastroDto.Cnes,
                Ativo = cadastroDto.Ativo
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Hospitals.Add(hospital);
            return _contexto.SaveChanges();
        }

        public int AtualizarHospital (HospitalDto cadastroDto)
        {
            Hospital hospital =
                (from h in _contexto.Hospitals
                 where h.IdHospital == cadastroDto.IdHospital
                 select h)
                 ?.FirstOrDefault()
                 ?? new Hospital();

            if (hospital == null || DBNull.Value.Equals(hospital.IdHospital) || hospital.IdHospital == 0)
            {
                return 0;
            }

                hospital.Nome = cadastroDto.Nome;
                hospital.Cnpj = cadastroDto.Cnpj;
                hospital.Endereço = cadastroDto.Endereço;
                hospital.Telefone = cadastroDto.Telefone;
                hospital.Cnes = cadastroDto.Cnes;
                hospital.Ativo = cadastroDto.Ativo;

            _contexto.ChangeTracker.Clear();
            _contexto.Hospitals.Update(hospital);
            return _contexto.SaveChanges();
        }

        public int RemoverHospital(int id)
        {
            Hospital hospital =
                (from h in _contexto.Hospitals
                 where h.IdHospital == id
                 select h)
                 ?.FirstOrDefault()
                 ?? new Hospital();

            if (hospital == null || DBNull.Value.Equals(hospital.IdHospital) || hospital.IdHospital == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Hospitals.Remove(hospital);
            return _contexto.SaveChanges();
        }
    }
}
