
using FluentValidation.Validators;
using MediatR;

namespace MDVendas.Core.Messages.CommonMessages.Notifications
{
    public class DomainNotification: Message, INotification
    {
        public DateTime Timestamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Keys { get; private set; }
        public string  Value { get; private set; }
        public int Version { get; private set; }
        public DomainNotification(string keys, string value)
        {
            Timestamp = DateTime.Now;
            DomainNotificationId = Guid.NewGuid();
            Keys = keys;
            Value = value;
            Version = 1;
        }

    }
}
