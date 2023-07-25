using Formacao.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Entidades
{
    public class Pessoa : EntidadeHistorico
    {
        protected Pessoa()
        {
        }

        public string Nome { get; private set; }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public IEnumerable<FormacaoPessoa> FormacaoPessoas { get; private set; }
    }
}
