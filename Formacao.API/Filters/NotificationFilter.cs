using Formacao.Dominio.Notification;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace Formacao.API.Filters
{
    public class NotificationFilter : IEndpointFilter
    {
        private readonly DomainErrorNotificationContext _notificationContext;

        public NotificationFilter(DomainErrorNotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var result = await next(context);

            if (_notificationContext.HasNotifications)
                return Results.BadRequest(_notificationContext.Notifications);

            return result;
        }
    }
}
