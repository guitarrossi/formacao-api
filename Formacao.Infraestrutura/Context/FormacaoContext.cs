using Formacao.Infraestrutura.Extensions;
using Formacao.Infraestrutura.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Infraestrutura.Context
{
    public class FormacaoContext : DbContext
    {
        private readonly IMediator? _mediator;
        private readonly EntidadeHistoricoInterceptor? _auditableEntitySaveChangesInterceptor;

        public FormacaoContext(DbContextOptions<FormacaoContext> options) : base(options) { }

        public FormacaoContext(
            DbContextOptions<FormacaoContext> options,
            IMediator mediator,
            EntidadeHistoricoInterceptor auditableEntitySaveChangesInterceptor)
            : this(options)
        {
            _mediator = mediator;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<Dominio.Entidades.Formacao> Formacao { get; }

        public DbSet<Dominio.Entidades.FormacaoPessoa> FormacaoPessoa { get; }

        public DbSet<Dominio.Entidades.Pessoa> Pessoa { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_auditableEntitySaveChangesInterceptor != null)
                optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (_mediator != null)
                await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
