using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Entidades.Base
{
    public abstract class EntidadeHistorico : EntidadeBase
    {
        public DateTime CriadoEm { get; private set; }
        public Guid CriadoPorIdUsuario { get; private set; }
        public DateTime? UltimaAlteracaoEm { get; private set; }
        public Guid? UltimaAlteracaoPorIdUsuario { get; private set; }
        public DateTime? ExcluidoEm { get; private set; }
        public Guid? ExcluidoPorIdUsuario { get; private set; }

        public void RegistrarHistoricoCriacao(DateTime criadoEm, Guid criadoPor)
        {
            CriadoEm = criadoEm;
            CriadoPorIdUsuario = criadoPor;
        }

        public void RegistrarHistoricoUltimaAlteracao(DateTime ultimaAlteracaoEm, Guid ultimaAlteracaoPor)
        {
            UltimaAlteracaoEm = ultimaAlteracaoEm;
            UltimaAlteracaoPorIdUsuario = ultimaAlteracaoPor;
        }
    }
}
