using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Models
{
    public record Response
    {
        private readonly IList<string> _mensagensDeErro = new List<string>();

        public bool Sucesso { get { return Erros.Count() == 0; } }
        public IEnumerable<string> Erros { get; }
        public object Result { get; }

        public Response() => Erros = new ReadOnlyCollection<string>(_mensagensDeErro);

        public Response(object result) : this() => Result = result;

        public Response InserirErro(string message)
        {
            _mensagensDeErro.Add(message);
            return this;
        }
    }

}
