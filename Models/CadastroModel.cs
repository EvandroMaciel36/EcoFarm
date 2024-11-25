namespace EcoFarm.Models
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CadastroModel
    {
        [Key]
        public int Id_cliente { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string nome_usuario { get; set; }

        public string senha { get; set; }

        public DateTime Data_cadastro { get; set; }

        public string Status_cliente { get; set; }

        [ValidateNever] // Ignora a validação do campo Cliente
        [ForeignKey("Id_cliente")]
        public ClienteModel Cliente { get; set; }
    }
}
