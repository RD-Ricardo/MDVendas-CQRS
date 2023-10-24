using MDVendas.Core.Messages;

namespace MDVendas.Core.DomianObjects
{
    public abstract class Entity
    {
        private List<Event> _events;
        public IReadOnlyCollection<Event> Events => _events;
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public void AdicioanarEvento(Event evento)
        {
            _events = _events ?? new List<Event>();
            _events.Add(evento);
        }

        public void RemoverEvento(Event evento)
        {
            _events?.Remove(evento);
        }

        public void LimparEvento()
        {
            _events?.Clear();
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
