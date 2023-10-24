using MDVendas.Vendas.Application.Queries.ViewModel;

namespace MDVendas.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<IEnumerable<PedidoViewModel>> ObterPEdidosCliente(Guid clienteId);
    }


    public class PedidoQueries : IPedidoQueries
    {
        public Task<IEnumerable<PedidoViewModel>> ObterPEdidosCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
