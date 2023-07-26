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
    public record CriarFormacao(string Nome, string Descricao, DateTime DataInicio) : IRequest<Response>
    {
    }

    
}
