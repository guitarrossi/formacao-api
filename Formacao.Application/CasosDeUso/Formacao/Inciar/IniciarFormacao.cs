using Formacao.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.CasosDeUso.Formacao.Inciar
{
    public record IniciarFormacao(Guid IdFormacao) : IRequest<Response>
    {
    }
}
