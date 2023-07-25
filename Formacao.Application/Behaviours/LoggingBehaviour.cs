using Formacao.Application.Interfaces.Services;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;
        private readonly IUsuarioAutenticado _usuarioAutenticado;
        //private readonly IIdentityService _identityService;

        public LoggingBehaviour(ILogger<TRequest> logger, IUsuarioAutenticado user)
            //IIdentityService identityService)
        {
            _logger = logger;
            _usuarioAutenticado = user;
            //_identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _usuarioAutenticado.Id ?? string.Empty;
            //string? userName = string.Empty;

            //if (!string.IsNullOrEmpty(userId))
            //{
            //    userName = await _identityService.GetUserNameAsync(userId);
            //}

            _logger.LogInformation("Log de requisição: {Name} {@UserId} {@Request}",
                requestName, userId, request);
        }
    }
}
