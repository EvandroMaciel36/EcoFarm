using System.ComponentModel.DataAnnotations;

namespace EcoFarm.Models
{
    public class CadastroModel
    {

        [Key]
        public int Id_conta { get; set; } // Nome da coluna no banco
        public int Id_cliente { get; set; } // Nome da coluna no banco
        public string nome_usuario { get; set; } // Nome da coluna no banco
        public string senha { get; set; } // Nome da coluna no banco
        public DateTime Data_criacao { get; set; } // (Opcional) se a tabela tem esse campo
    }
}
