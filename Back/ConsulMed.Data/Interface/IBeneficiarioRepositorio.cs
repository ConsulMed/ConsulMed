using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsulMed.Data;
using ConsulMed.Data.Dto;

namespace ConsulMed.Data.Interface
{
    public interface IBeneficiarioRepositorio
    {
        List<Dto.BeneficiarioDto> ListarTodas();
        Dto.BeneficiarioDto PorId(int idBeneficiario);
        int Atualizar(Dto.BeneficiarioDto beneficiario);
        int Cadastrar(Dto.BeneficiarioDto cadastrarDto);
        int Excluir(int idBeneficiario);
    }
}
