using MDVendas.Core.Communication.Mediator;
using MDVendas.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace MDVendas.Vendas.Data
{
    public class MDVendasContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public MDVendasContext(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublicarEventos(this);

            return await base.SaveChangesAsync() > 0;
        }
    }
}
