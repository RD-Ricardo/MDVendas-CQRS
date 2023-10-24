using MDVendas.Core.Communication.Mediator;
using MDVendas.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MDVendasAPI.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private DomainNotificationHandler _notifications;

        private readonly IMediatorHandler _mediatorHandler;

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }
        protected bool OperacaoValida()
        {
            return !_notifications.TemNoficacao();
        }



    }
}
