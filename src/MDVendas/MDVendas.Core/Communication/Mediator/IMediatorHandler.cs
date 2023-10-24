using MDVendas.Core.Messages;
using MDVendas.Core.Messages.CommonMessages.Notifications;

namespace MDVendas.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T coamando) where T : Command;
        Task PublicarNotificacao<T>(T notificao) where T : DomainNotification;
    }
}
