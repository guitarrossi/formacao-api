using Formacao.Application.Interfaces.Repositories.Base;
using Formacao.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Infraestrutura.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public DbSet<T> DbSet { get; }
        private FormacaoContext Context { get; }
        public RepositoryBase(FormacaoContext context)
        {
            DbSet = context.Set<T>();
            Context = context;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
