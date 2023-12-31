﻿using MDVendas.Core.DomianObjects;

namespace MDVendas.Vendas.Domain
{
    public class PedidoItem : Entity
    {

        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        
        //EF Rel.
        public Pedido Pedido { get; set; }

        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }


        internal void AssociarPèdido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        internal void AdicionarUnidade(int unidade)
        {
            Quantidade += unidade;
        }

        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }
    }


}
