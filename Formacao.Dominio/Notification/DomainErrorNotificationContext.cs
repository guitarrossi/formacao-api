using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Notification
{
    public class DomainErrorNotificationContext
    {
        private readonly List<DomainErrorNotification> _notifications;
        public IReadOnlyCollection<DomainErrorNotification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public DomainErrorNotificationContext()
        {
            _notifications = new List<DomainErrorNotification>();
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new DomainErrorNotification(key, message));
        }

        public void AddNotification(DomainErrorNotification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<DomainErrorNotification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IReadOnlyCollection<DomainErrorNotification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<DomainErrorNotification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<DomainErrorNotification> notifications)
        {
            _notifications.AddRange(notifications);
        }
    }
}
