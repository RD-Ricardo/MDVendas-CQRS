namespace MDVendas.Core.Messages
{
    public class Message
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
