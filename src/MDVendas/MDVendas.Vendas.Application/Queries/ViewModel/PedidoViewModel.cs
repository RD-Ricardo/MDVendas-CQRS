namespace MDVendas.Vendas.Application.Queries.ViewModel
{
    public class PedidoViewModel
    {
        public int Codigo { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCadastro { get; set; }
        public int PedidoStatus { get; set; }
    }
}
