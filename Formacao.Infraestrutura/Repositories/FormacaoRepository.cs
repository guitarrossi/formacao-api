using Formacao.Application.Interfaces.Repositories;
using Formacao.Application.Modelos;
using Formacao.Dominio.Enums;
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

        public async Task<ResultadoPaginado<Dominio.Entidades.Formacao>> FiltarFormacoesPaginado(string nome, FormacaoStatusEnum? status, DateTime? dataInicio, int? tamanhoPagina = 20, int? paginaAtual = 1)
        {
            var query = DbSet.AsNoTrackingWithIdentityResolution();

            if (ValorSeraFiltrado(nome))
                query = query.Where(f => f.Nome.Contains(nome));
            if (status.HasValue)
                query = query.Where(f => f.Status == status.Value);
            if (dataInicio.HasValue)
                query = query.Where(f => dataInicio >= f.DataInicio);

            var total = await query.CountAsync();

            paginaAtual = paginaAtual == null ? 0 : paginaAtual == 1 ? 0 : paginaAtual;
            tamanhoPagina = tamanhoPagina == null ? 20 : tamanhoPagina;

            var resultados  = await query.Skip(paginaAtual.Value * tamanhoPagina.Value).Take(tamanhoPagina.Value).ToListAsync();

            return new ResultadoPaginado<Dominio.Entidades.Formacao>(paginaAtual.Value, total, tamanhoPagina.Value, resultados);
        }

        private bool ValorSeraFiltrado(string texto)
        {
            return texto is not null && !string.IsNullOrEmpty(texto);
        }
    }
}
