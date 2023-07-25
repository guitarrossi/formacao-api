using Formacao.Application.Exceptions;
using Formacao.Application.Interfaces.Services;
using Formacao.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUsuarioAutenticado _usuarioAutenticado;
        //private readonly IIdentityService _identityService;

        public AuthorizationBehaviour(
            IUsuarioAutenticado user)
            //IIdentityService identityService)
        {
            _usuarioAutenticado = user;
            //_identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                // Must be authenticated user
                if (_usuarioAutenticado.Id == null)
                {
                    throw new UnauthorizedAccessException();
                }

                // Role-based authorization
                //var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                //if (authorizeAttributesWithRoles.Any())
                //{
                //    var authorized = false;

                //    foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                //    {
                //        foreach (var role in roles)
                //        {
                //            var isInRole = await _identityService.IsInRoleAsync(_usuarioAutenticado.Id, role.Trim());
                //            if (isInRole)
                //            {
                //                authorized = true;
                //                break;
                //            }
                //        }
                //    }

                //    // Must be a member of at least one role in roles
                //    if (!authorized)
                //    {
                //        throw new AcessoProibidoException();
                //    }
                //}

                //// Policy-based authorization
                //var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
                //if (authorizeAttributesWithPolicies.Any())
                //{
                //    foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
                //    {
                //        var authorized = await _identityService.AuthorizeAsync(_usuarioAutenticado.Id, policy);

                //        if (!authorized)
                //        {
                //            throw new ForbiddenAccessException();
                //        }
                //    }
                //}
            }

            // User is authorized / authorization not required
            return await next();
        }
    }
}
