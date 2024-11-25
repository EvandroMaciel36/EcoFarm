using System.ComponentModel.DataAnnotations;

namespace EcoFarm.Models
{
    public class LoginModel
    {
        public string Usuario { get; set; } // Nome de usuário
        public string Senha { get; set; } // Senha
    }
}
