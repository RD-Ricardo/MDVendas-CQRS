﻿using MediatR;

namespace MDVendas.Core.Messages.CommonMessages.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;
        public DomainNotificationHandler(List<DomainNotification> notifications)
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> ObterNotificacoes() => _notifications;

        public virtual bool TemNoficacao() => ObterNotificacoes().Any();

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
        
    }
}
