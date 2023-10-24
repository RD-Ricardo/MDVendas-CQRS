using MDVendas.Core.Communication.Mediator;
using MDVendas.Core.DomianObjects;

namespace MDVendas.Vendas.Data
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediatorHandler mediator, MDVendasContext ctx)
        {
            var domainEntities = ctx.ChangeTracker.Entries<Entity>().Where(x => x.Entity.Events != null && x.Entity.Events.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.Events).ToList();

            domainEntities.ToList().ForEach(entity => entity.Entity.LimparEvento());

            var tasks = domainEvents.Select(async (domian) =>
            {
                await mediator.PublicarEvento(domian);
            });


            await Task.WhenAll(tasks);
        }
    }
}
