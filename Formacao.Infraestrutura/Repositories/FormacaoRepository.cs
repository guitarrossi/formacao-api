using Formacao.Application.Interfaces.Repositories;
using Formacao.Infraestrutura.Context;
using Formacao.Infraestrutura.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Infraestrutura.Repositories
{
    public class FormacaoRepository : RepositoryBase<Dominio.Entidades.Formacao>, IFormacaoRepository
    {
        public FormacaoRepository(FormacaoContext context) : base(context)
        {
        }

        public void Alterar(Dominio.Entidades.Formacao formacao)
        {
            DbSet.Update(formacao);
        }

        public async Task<bool> ChecarSeNomeExisteIgnorandoIdFornecido(string nome, Guid? ignorarEsteId = default)
        {
            if (ignorarEsteId.HasValue)
                return await DbSet.AnyAsync(f => f.Nome == nome && f.Id != ignorarEsteId.Value);

            return await DbSet.AnyAsync(f => f.Nome == nome);
        }
        public async Task<bool> ChecarSeFormacaoExiste(Guid id)
        {
            return await DbSet.AnyAsync(f => f.Id == id);
        }

        public async Task Inserir(Dominio.Entidades.Formacao formacao)
        {
            await DbSet.AddAsync(formacao);
        }

        public async Task<Dominio.Entidades.Formacao> SelecionarPorIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
