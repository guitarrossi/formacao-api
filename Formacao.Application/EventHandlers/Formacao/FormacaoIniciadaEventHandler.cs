using Formacao.Dominio.Eventos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.EventHandlers.Formacao
{
    public class FormacaoIniciadaEventHandler : INotificationHandler<FormacaoIniciadaEvent>
    {
        private readonly ILogger<FormacaoIniciadaEventHandler> _logger;

        public FormacaoIniciadaEventHandler(ILogger<FormacaoIniciadaEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(FormacaoIniciadaEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Formação Iniciada");
        }
    }
}
