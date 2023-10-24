using MDVendas.Core.Communication.Mediator;
using MDVendas.Core.Messages;
using MDVendas.Core.Messages.CommonMessages.Notifications;
using MDVendas.Vendas.Application.Events;
using MDVendas.Vendas.Domain;
using MediatR;

namespace MDVendas.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;

        private readonly IMediatorHandler _mediatorHandler;
        
        public PedidoCommandHandler(IPedidoRepository pedidoRepository, IMediatorHandler mediatorHandler)
        {
            _pedidoRepository = pedidoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {

            if (!ValidarComando(message)) return false;

            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(message.ClienteId);
            var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);

            if(pedido == null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId);
                pedido.AdicionarItem(pedidoItem);

                _pedidoRepository.Adicionar(pedido);
                pedido.AdicioanarEvento(new PedidoRascunhoIniciadoEvent(message.ClienteId, message.ProdutoId));
            }
            else
            {
                var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoItemExistente)
                {
                    _pedidoRepository.AtualizarItem(pedidoItem);
                }
                else
                {
                    _pedidoRepository.AdicionarItem(pedidoItem);
                }

                pedido.AdicioanarEvento(new PedidoAtualizadoEvent(message.ClienteId, pedido.Id, pedido.ValorTotal));
            }
            
            pedido.AdicioanarEvento(new PedidoItemAdicionadoEvent(message.ClienteId, 
                                                                  pedido.Id, 
                                                                  message.ProdutoId, 
                                                                  message.ValorUnitario, 
                                                                  message.Quantidade));

            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public bool ValidarComando(Command message)
        {
            if(message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                // lançar evento
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
