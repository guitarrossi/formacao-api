using Formacao.Application.Models;
using Formacao.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.UseCases.Formacao.ListarFormacoes
{
    public record FiltrarFormacoes(string Nome = null, FormacaoStatusEnum? Status = null, DateTime? DataInicio = null, int? PaginaAtual = 1, int? TamanhoPagina = 20) : IRequest<Response>
    {
    }
}
