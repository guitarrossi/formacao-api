using Formacao.Application.Interfaces.Repositories.Base;
using Formacao.Application.Modelos;
using Formacao.Dominio.Entidades;
using Formacao.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Interfaces.Repositories
{
    public interface IFormacaoRepository : IRepositoryBase<Dominio.Entidades.Formacao>
    {
        Task Inserir(Dominio.Entidades.Formacao formacao);

        void Alterar(Dominio.Entidades.Formacao formacao);

        Task<Dominio.Entidades.Formacao> SelecionarPorIdAsync(Guid id);

        Task<bool> ChecarSeNomeExisteIgnorandoIdFornecido(string nome, Guid? ignorarEsteId = default);

        Task<bool> ChecarSeFormacaoExiste(Guid id);

        Task<ResultadoPaginado<Dominio.Entidades.Formacao>> FiltarFormacoesPaginado(string nome, FormacaoStatusEnum? status, DateTime? dataInicio, int? tamanhoPagina = 20, int? paginaAtual = 1);
    }
}
