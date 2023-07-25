using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Notification
{
    public class DomainErrorNotification
    {
        public string Key { get; }
        public string Message { get; }

        public DomainErrorNotification(string key, string message)
        {
            Key = key;
            Message = message;
        }
        
    }
}
