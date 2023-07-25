using Formacao.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Entidades
{
    public class FormacaoPessoa : EntidadeHistorico
    {
        public FormacaoPessoa(Pessoa pessoa, Formacao formacao)
        {
            Pessoa = pessoa;
            Formacao = formacao;
        }

        protected FormacaoPessoa()
        {

        }

        public Pessoa Pessoa { get; private set; }
        public Formacao Formacao { get; private set; }

        public Guid IdPessoa { get; private set; }

        public Guid IdFormacao { get; private set; }
    }
}
