using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Dto
{
    public class HospitalDto
    {
        public int IdHospital { get; set; }
        public string Nome { get; set; } = null!;

        public string? Cnpj { get; set; }

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }

        public string? Cnes { get; set; }

        public bool Ativo { get; set; }
    }
}
