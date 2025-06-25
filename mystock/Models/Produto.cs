using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyStock.Models
{

    public enum UnidadeMedida
    {
        Un,
        Kg,
        L,
        M,
        Cx,
        Pc
    }
    public class Produto
    {
        public int Id { get; set; }

        // Nome do produto
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        // Marca do produto
        [StringLength(100, ErrorMessage = "A marca do produto deve ter no máximo 100 caracteres")]
        public string Marca { get; set; } = string.Empty;

        // Descrição do produto
        [StringLength(500, ErrorMessage = "A descrição do produto deve ter no máximo 500 caracteres")]
        public string? Descricao { get; set; }

        // Preço de compra
        [Required(ErrorMessage = "O preço de compra é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço de compra deve ser maior que zero")]
        public decimal PrecoCompra { get; set; }

        // Preço de venda
        [Required(ErrorMessage = "O preço de venda é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço de venda deve ser maior que zero")]
        public decimal PrecoVenda { get; set; }

        // Quantidade em estoque
        [Required(ErrorMessage = "A quantidade em estoque é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero")]
        public int QuantidadeEstoque { get; set; }

        // Unidade de medida
        [Required(ErrorMessage = "A unidade de medida é obrigatória")]
        public UnidadeMedida UnidadeMedida { get; set; }

        // Estoque mínimo
        public int EstoqueMinimo { get; set; } = 5;

        // Data de hoje
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public bool EstoqueBaixo => QuantidadeEstoque <= EstoqueMinimo;
    }
}