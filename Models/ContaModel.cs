using System.ComponentModel.DataAnnotations.Schema;

namespace EcoFarm.Models
{
    public class ContaModel
    {
        public int Id_cliente { get; set; }
        public string Nome_usuario { get; set; }
        public string Senha { get; set; }

        [ForeignKey("Id_cliente")] public ClienteModel Cliente { get; set; }
    }
}
