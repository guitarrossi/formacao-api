using Formacao.Application.Interfaces.Repositories;
using Formacao.Application.Mapper;
using Formacao.Application.Modelos;
using Formacao.Application.Models;
using Formacao.Application.UseCases.Formacao.Filtrar;
using Formacao.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.UseCases.Formacao.ListarFormacoes
{
    public record FiltrarFormacoesHandler : IRequestHandler<FiltrarFormacoes, Response>
    {
        private readonly IFormacaoRepository _formacaoRepository;

        public FiltrarFormacoesHandler(IFormacaoRepository formacaoRepository)
        {
            _formacaoRepository = formacaoRepository;
        }

        public async Task<Response> Handle(FiltrarFormacoes request, CancellationToken cancellationToken)
        {
            request.Deconstruct(out string nome, out FormacaoStatusEnum? status, out DateTime? dataInicio, out int? paginaAtual, out int? tamanhoPagina);

            var formacoes = await _formacaoRepository.FiltarFormacoesPaginado(nome, status, dataInicio, tamanhoPagina, paginaAtual);

            var resultado = formacoes.Resultado.MapearParaResultado();
            var retorno = new ResultadoPaginado<FiltrarFormacoesResult>(formacoes.PaginaAtual, formacoes.TotalRegistros, formacoes.RegistrosPorPagina, resultado);

            return new Response(retorno);
        }
    }
}
