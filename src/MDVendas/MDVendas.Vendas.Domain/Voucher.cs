using MDVendas.Core.DomianObjects;

namespace MDVendas.Vendas.Domain
{
    public class  Voucher : Entity
    {
        public string  Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Qunatidade { get; private set; }
        public TipoDescontoVouncher TipoDescontoVouncher { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        //EF. Rel
        public ICollection<Pedido> Pedidos { get;  set; }
    }


}
