using Formacao.Application.UseCases.Formacao.Filtrar;
using Formacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Mapper
{
    public static class MapeamentoEntidadeParaResponse
    {
        public static IEnumerable<FiltrarFormacoesResult> MapearParaResultado(this IEnumerable<Dominio.Entidades.Formacao> formacoes)
        {
            return formacoes
                .Select(s => new FiltrarFormacoesResult
                {
                    DataInicio = s.DataInicio,
                    Descricao = s.Descricao,
                    IdFormacao = s.Id,
                    Nome = s.Nome,
                    Status = s.Status
                });
        }
    }
}
