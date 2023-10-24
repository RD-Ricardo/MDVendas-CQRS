using MDVendas.Core.Messages;
using MDVendas.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace MDVendas.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> EnviarComando<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task PublicarNotificacao<T>(T notificao) where T : DomainNotification
        {
            await _mediator.Publish(notificao);
        }
    }
}
