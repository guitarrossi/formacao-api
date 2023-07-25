using Formacao.Application.Interfaces.Repositories.Base;
using Formacao.Dominio.Entidades;
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
    }
}
