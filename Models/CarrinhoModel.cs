using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoFarm.Models
{
    [Table("CARRINHO")]
    public class CarrinhoModel
    {
        [Key]
        public int Id_carrinho { get; set; } // ID do item no carrinho

        // FK para ProdutoModel
        public int Id_produto { get; set; } // ID do produto no carrinho

        [ForeignKey("Id_produto")]
        public ProdutoModel Produto { get; set; } // Relacionamento com ProdutoModel

        public string Nome_produto { get; set; } // Nome do produto

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco_unitario { get; set; } // Preço unitário do produto

        public int Quantidade { get; set; } // Quantidade do produto

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco_total { get; set; } // Preço total (quantidade * preço unitário)

        public DateTime Data_adicionado { get; set; } = DateTime.Now; // Data de inclusão
    }
}
