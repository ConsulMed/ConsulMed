using ConsulMed.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulMed.Data.Dto
{
    public class AgendamentoDto
    {
        public int IdAgendamento { get; set; }
        public int IdHospital { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdProfissional { get; set; }
        public DateTime DataHoraAgendamento { get; set; }
        public int IdBeneficiario { get; set; }
        public bool Ativo { get; set; }
        public virtual Beneficiario IdBeneficiarioNavigation { get; set; } = null!;
        public virtual Especialidade IdEspecialidadeNavigation { get; set; } = null!;
        public virtual Hospital IdHospitalNavigation { get; set; } = null!;
        public virtual Profissional IdProfissionalNavigation { get; set; } = null!;
    }
}
