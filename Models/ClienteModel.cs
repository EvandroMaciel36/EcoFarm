using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoFarm.Models;


namespace EcoFarm.Models
{
    [Table("CLIENTE")]
    public class ClienteModel
    {
        public ClienteModel()
        {
            Contas = new HashSet<CadastroModel>();
        }

        [Key]
        public int Id_cliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime Data_cadastro { get; set; }
        public string Status_cliente { get; set; }

        public ICollection<CadastroModel> Contas { get; set; }
    }
}
