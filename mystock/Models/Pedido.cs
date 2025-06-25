using System.ComponentModel.DataAnnotations;
using MyStockClientes;

namespace MyStockPedidos.Models
{
    public enum StatusPedido
    {
        Pendente,
        Processando,
        Concluido,
        Cancelado
    }

    public class Pedido
    {
        // Número do pedido será o Id do Banco de Dados
        public int Id { get; set; }

        // Chave estrangeira para Cliente relacionado ao pedido
        [Required(ErrorMessage = "O cliente é obrigatório")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        // Data do pedido
        public DateTime DataPedido { get; set; } = DateTime.Now;

        // Status do pedido
        [Required(ErrorMessage = "O Status do pedido é obrigatório")]
        public StatusPedido Status { get; set; } = StatusPedido.Pendente;


        // Lista de itens do pedido
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
        // Calculo total do pedido
        public decimal ValorTotalPedido => Itens.Sum(item => item.ValorTotalItemPedido);
    }
}