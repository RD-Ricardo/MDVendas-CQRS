using MDVendas.Core.Messages.CommonMessages.Notifications;
using MDVendas.Vendas.Application.Commands;
using MediatR;

namespace MDVendasAPI.DI
{
    public static class DependencyInjection
    {
        public static void Dependencias(this IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
