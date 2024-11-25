using System.ComponentModel.DataAnnotations;

namespace EcoFarm.Models
{
    public class CarrinhoModel
    {
        [Key]
        public int Id { get; set; } // Id do produto
        public string Nome { get; set; } // Nome do produto
        public decimal Preco { get; set; } // Preço unitário
        public int Quantidade { get; set; } // Quantidade escolhida
        public decimal Total => Preco * Quantidade; // Total (Preço * Quantidade)


    }
}
