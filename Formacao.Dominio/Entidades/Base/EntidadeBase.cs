using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Entidades.Base
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        [NotMapped]
        public IEnumerable<EventoBase> Events { get; private set; }

        private readonly List<EventoBase> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<EventoBase> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(EventoBase domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(EventoBase domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
