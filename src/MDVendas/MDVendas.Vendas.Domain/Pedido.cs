﻿using MDVendas.Core.DomianObjects;

namespace MDVendas.Vendas.Domain
{
    public class Pedido : Entity , IAggregateRoot
    {
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal  Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public virtual Voucher Voucher { get; private set; }

        public Pedido(Guid clienteId, bool voucherUtilizado, decimal desconto, decimal valorTotal)
        {
            ClienteId = clienteId;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            ValorTotal = valorTotal;
            _pedidoItems = new List<PedidoItem>();
        }

        protected Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }

        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUtilizado = true;
            CalcularValorPedido();
        }

        public void CalcularValorPedido()
        {
            ValorTotal = _pedidoItems.Sum(x => x.CalcularValor());
            CalcularValorUtilizadoDesconto();
        }

        public void CalcularValorUtilizadoDesconto()
        {
            if(!VoucherUtilizado) { return; }

            decimal desconto = 0;
            var valor = ValorTotal;

            if(Voucher.TipoDescontoVouncher == TipoDescontoVouncher.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;

        }
    }
}
