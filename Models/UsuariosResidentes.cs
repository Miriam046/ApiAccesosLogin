using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVigilancia.Models
{
    public class UsuariosResidentes
    {
        [Key]
        public int id_usuario { get; set; }

        public int id_residente { get; set; }

        [Required]
        public string correo { get; set; }

        [Required]
        public string contraseña { get; set; }
    }
}

