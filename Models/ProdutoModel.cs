using System.ComponentModel.DataAnnotations;

namespace EcoFarm.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id_produto { get; set; } // id_produto (Primary Key)

        public string Nome { get; set; } // nome
        public string Descricao { get; set; } // descricao
        public string Categoria { get; set; } // categoria
        public int Quantidade { get; set; } // quantidade
        public decimal Preco { get; set; } // preco
        public DateTime Data_entrada { get; set; } // data_entrada (nullable)
        public int Id_fornecedor { get; set; } // id_fornecedor (Foreign Key)
        public string Caminho_imagem { get; set; } // caminho_imagem (novo campo)

    }
}
