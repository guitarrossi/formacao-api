using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Regras
{
    public class Regra
    {
        public string CodigoRegra { get; private set; }

        public string Descricao { get; private set; }

        public Regra(string codigoRegra, string descricao)
        {
            CodigoRegra = codigoRegra;
            Descricao = descricao;
        }

        public Regra()
        {

        }

        //public static Regra CriarRegra(int codigoRegra, string descricao) => new(codigoRegra, descricao);
    }
}
