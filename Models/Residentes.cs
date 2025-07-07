using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVigilancia.Models
{
    public class Residentes
    {
        [Key]
        public int id_residente { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string apellido_paterno { get; set; }

        [Required]
        [MaxLength(100)]
        public string apellido_materno { get; set; }

        [MaxLength(100)]
        public string calle { get; set; }

        [MaxLength(50)]
        public string numero { get; set; }

        [MaxLength(100)]
        public string telefono { get; set; }
    }
}

