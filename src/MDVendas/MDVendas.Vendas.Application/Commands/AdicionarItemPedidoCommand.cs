using FluentValidation;
using FluentValidation.Validators;
using MDVendas.Core.Messages;

namespace MDVendas.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {

        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }


    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(x => x.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente invalido");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("");

            RuleFor(x => x.Quantidade)
                .LessThan(15)
                .WithMessage("");


        }
    }
}
