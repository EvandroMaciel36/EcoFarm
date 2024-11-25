using System.ComponentModel.DataAnnotations;

namespace EcoFarm.Models
{
    public class CarrinhoDeComprasModel
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string CaminhoImagem { get; set; }
        public int Quantidade { get; set; }

    }
}
