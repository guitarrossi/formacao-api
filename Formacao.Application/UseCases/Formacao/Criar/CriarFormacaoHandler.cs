using Formacao.Application.Interfaces.Repositories;
using Formacao.Application.Mapper;
using Formacao.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.CasosDeUso.Formacao.Criar
{
    public record CriarFormacaoHandler : IRequestHandler<CriarFormacao, Response>
    {
        private readonly IFormacaoRepository _formacaoRepository;

        public CriarFormacaoHandler(IFormacaoRepository formacaoRepository)
        {
            _formacaoRepository = formacaoRepository;
        }

        public async Task<Response> Handle(CriarFormacao request, CancellationToken cancellationToken)
        {
            var formacao = request.MapearParaFormacao();

            await _formacaoRepository.Inserir(formacao);

            await _formacaoRepository.SaveChangesAsync();

            var resultado = new CriarFormacaoResult(formacao.Id, formacao.Nome, formacao.DataInicio ?? DateTime.Now);

            return new Response(resultado);
        }
    }
}
