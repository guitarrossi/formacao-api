using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formacao.Application.Interfaces.Services;
using Formacao.Dominio.Entidades.Base;
using Formacao.Application.Interfaces.Data;

namespace Formacao.Infraestrutura.Interceptors
{
 
    public class EntidadeHistoricoInterceptor : SaveChangesInterceptor
    {
        private readonly IUsuarioAutenticado _user;
        private readonly IDateTime _dateTime;

        public EntidadeHistoricoInterceptor(
            IUsuarioAutenticado user,
            IDateTime dateTime)
        {
            _user = user;
            _dateTime = dateTime;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<EntidadeHistorico>())
            {
                if (entry.State == EntityState.Added)
                {
                    var parsed = Guid.TryParse(_user.Id, out Guid userId);
                    entry.Entity.RegistrarHistoricoCriacao(_dateTime.Now, parsed ? userId : Guid.Empty);
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    var parsed = Guid.TryParse(_user.Id, out Guid userId);
                    entry.Entity.RegistrarHistoricoUltimaAlteracao(_dateTime.Now, parsed ? userId : Guid.Empty);
                }
            }
        }
    }

    public static class Extensions
    {
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
            entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
    
}
