using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiVigilancia.Models
{
    public class LoginRequest
    {
        public string usuarioNombre { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}