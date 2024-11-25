using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EcoFarm.Models
{
    [Keyless]
    public class LoginModel
    {
        public string Usuario { get; set; } // Nome de usuário
        public string Senha { get; set; } // Senha
    }
}
