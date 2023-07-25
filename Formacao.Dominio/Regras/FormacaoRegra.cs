using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Regras
{
    public partial class FormacaoRegra : Regra
    {
        public static Regra FormacaoJaEmAndamento = new Regra("001", "Formação já está em andamento, não é possivel alterá-la.");
    }
}
