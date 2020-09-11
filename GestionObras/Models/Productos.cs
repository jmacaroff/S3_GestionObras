using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionObras.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten Letras")]
        public string Descripcion { get; set; }

        [Required (ErrorMessage = "Se requiere un precio")]
        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "Se aceptan 2 decimales. Ingrese el valor decimal con ' . '")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        public string Observacion { get; set; }

    }
}
