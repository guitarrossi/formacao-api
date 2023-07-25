using Formacao.API.Filters;
using Formacao.API.Services;
using Formacao.Application;
using Formacao.Application.Interfaces.Services;
using Formacao.Infraestrutura;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Formacao.API
{
    public static class RegisterServices
    {
        public static void RegistrarInjecoesDeDependencia(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.RegistrarServicosApplication();
            services.RegistrarServicosAPI();
            services.RegistrarServicosInfraestrutura(configuration);
        }

        public static IServiceCollection RegistrarServicosAPI(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioAutenticado, UsuarioAutenticado>();

            return services;
        }
    }
}
