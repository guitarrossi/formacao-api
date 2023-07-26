using Formacao.Application.Interfaces.Repositories;
using Formacao.Application.Models;
using Formacao.Dominio.Notification;
using Formacao.Dominio.Regras;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.CasosDeUso.Formacao.Inciar
{
    public class IniciarFormacaoHandler : IRequestHandler<IniciarFormacao, Response>
    {
        private readonly IFormacaoRepository _formacaoRepository;
        private readonly DomainErrorNotificationContext _notifications;

        public IniciarFormacaoHandler(IFormacaoRepository formacaoRepository, DomainErrorNotificationContext notificationContext)
        {
            _formacaoRepository = formacaoRepository;
            _notifications = notificationContext;
        }

        public async Task<Response> Handle(IniciarFormacao request, CancellationToken cancellationToken)
        {
            var formacao = await _formacaoRepository.SelecionarPorIdAsync(request.IdFormacao);

            if (formacao.EstaEmAndamento())
            {
                _notifications.AddNotification(FormacaoRegra.FormacaoJaEmAndamento.CodigoRegra, FormacaoRegra.FormacaoJaEmAndamento.Descricao);
                return new Response();
            }

            formacao.IniciarFormacao();

            _formacaoRepository.Alterar(formacao);

            await _formacaoRepository.SaveChangesAsync();

            return new Response();
        }
    }
}
