using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.CasosDeUso.Formacao.Criar
{
    public record CriarFormacaoResult(Guid id, string Nome, DateTime DataInicio)
    {
    }
}
