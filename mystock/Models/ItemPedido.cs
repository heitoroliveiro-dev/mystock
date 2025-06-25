using System.ComponentModel.DataAnnotations;
using MyStockPedidos.Models;
using MyStockProdutos.Models;

namespace MyStockPedidos.Models
{
    public class ItemPedido
    {
        // Id será utilizado como PedidoId
        public int Id { get; set; }

        // Chave estrangeira de Pedido
        public int PedidoId { get; set; }

        // Chave estrangeira de Produtos
        public int ProdutoId { get; set; }

        // Quantidade
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int QuantidadeItemPedido { get; set; }

        // Preço unitário
        [Required(ErrorMessage = "O preço unitário é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero")]
        public decimal PrecoUnitario { get; set; }

        // Propriedades de navegação
        public Pedido? Pedido { get; set; }
        public Produto? Produto { get; set; }

        public decimal ValorTotalItemPedido => QuantidadeItemPedido * PrecoUnitario;
    }
}