using Formacao.Application.Interfaces.Data;
using Formacao.Application.Interfaces.Repositories;
using Formacao.Infraestrutura.Context;
using Formacao.Infraestrutura.Interceptors;
using Formacao.Infraestrutura.Repositories;
using Formacao.Infraestrutura.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Infraestrutura
{
    public static class RegisterServices
    {
        public static IServiceCollection RegistrarServicosInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<EntidadeHistoricoInterceptor>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FormacaoContext>(options =>
                    options.UseSqlServer(connectionString));


            services.AddTransient<IDateTime, DateTimeService>();

            services.AddScoped<IFormacaoRepository, FormacaoRepository>();

            return services;
        }
    }
   
}
