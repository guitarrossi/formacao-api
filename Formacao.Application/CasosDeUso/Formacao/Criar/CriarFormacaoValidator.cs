using FluentValidation;
using Formacao.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.CasosDeUso.Formacao.Criar
{
    public class CriarFormacaoValidator : AbstractValidator<CriarFormacao>
    {
        private readonly IFormacaoRepository _formacaoRepository;

        public CriarFormacaoValidator(IFormacaoRepository formacaoRepository)
        {
            _formacaoRepository = formacaoRepository;

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(c => c.Nome)
                .MustAsync(NomeDaFormacaoDeveSerUnico)
                .WithMessage("Nome deve ser unico");
                
        }

        private async Task<bool> NomeDaFormacaoDeveSerUnico(CriarFormacao criarFormacao, string nome, CancellationToken ct)
        {
            return !await _formacaoRepository.ChecarSeNomeExisteIgnorandoIdFornecido(nome);
        }
    }
}
