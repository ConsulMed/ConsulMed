using ConsulMed.Data.Dto;
using ConsulMed.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Interface
{
    public interface IHospitalRepositorio
    {
        public List<Dto.HospitalDto> ConsultarTodos();
        public Dto.HospitalDto ConsultarPorId(int idHospital);
        public int CadastrarHospital(Dto.HospitalDto cadastroDto);

        public int AtualizarHospital(HospitalDto cadastroDto);

        public int RemoverHospital(int id);
    }
}
