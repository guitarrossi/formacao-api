using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Modelos
{
    public class ResultadoPaginado<T> where T : class
    {
        public ResultadoPaginado(int paginaAtual, int totalRegistros, int registrosPorPagina, IEnumerable<T> resultado)
        {
            PaginaAtual = paginaAtual;
            TotalRegistros = totalRegistros;
            RegistrosPorPagina = registrosPorPagina;
            Resultado = resultado;
        }

        public int PaginaAtual { get; private set; }
        public int TotalRegistros { get; private set; }
        public int RegistrosPorPagina { get; private set; }
        public IEnumerable<T> Resultado { get; private set; } = new List<T>();
    }
}
