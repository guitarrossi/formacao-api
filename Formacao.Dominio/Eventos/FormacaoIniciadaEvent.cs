using Formacao.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Eventos
{
    public class FormacaoIniciadaEvent : EventoBase
    {
        public FormacaoIniciadaEvent(Guid formacaoId)
        {
            FormacaoId = formacaoId;
        }

        public Guid FormacaoId { get; private set; }

        
    }
}
