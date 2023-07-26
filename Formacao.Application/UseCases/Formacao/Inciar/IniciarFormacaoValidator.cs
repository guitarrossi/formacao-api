using Formacao.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.CasosDeUso.Formacao.Inciar
{
    public class IniciarFormacaoValidator : AbstractValidator<IniciarFormacao>
    {
        private readonly IFormacaoRepository _formacaoRepository;

        public IniciarFormacaoValidator(IFormacaoRepository formacaoRepository)
        {
            _formacaoRepository = formacaoRepository;
        }

        public IniciarFormacaoValidator()
        {
            RuleFor(f => f.IdFormacao)
                .NotEmpty()
                .WithMessage("IdFormacao é obrigatório")
                .MustAsync(FormacaoExiste)
                .WithMessage("IdFormação não pertence a nenhuma formação");
        }

        private async Task<bool> FormacaoExiste(IniciarFormacao iniciarFormacao, Guid idFormacao, CancellationToken cancellationToken)
        {
            return await _formacaoRepository.ChecarSeFormacaoExiste(idFormacao);
        }
    }
}
