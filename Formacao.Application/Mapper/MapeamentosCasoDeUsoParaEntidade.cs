using Formacao.Application.CasosDeUso.Formacao.Criar;
using Formacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Mapper
{
    public static class MapeamentosCasoDeUsoParaEntidade
    {
        public static Dominio.Entidades.Formacao MapearParaFormacao(this CriarFormacao criarFormacao)
        {
            return new Dominio.Entidades.Formacao(criarFormacao.Nome, criarFormacao.Descricao, criarFormacao.DataInicio);
        }
    }
}
