using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVigilancia.Models
{
    [Table("Invitados")]
    public class Invitados
    {
        [Key] // Indica que esta propiedad es la clave primaria
        [Column("id_invitado")] // Mapea con la columna de la base de datos
        public int id_invitado { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("apellido_paterno")]
        public string apellido_paterno { get; set; }

        [Column("apellido_materno")]
        public string apellido_materno { get; set; }

        [Column("tipo_invitacion")]
        public string tipo_invitacion { get; set; }

        [Column("codigo")]
        public string codigo { get; set; }

        [Column("fecha_validez")]
        public DateTime fecha_validez { get; set; }

        [Column("estado")]
        public string estado { get; set; }

        [Column("id_residente")]
        public int id_residente { get; set; }
    }
}


