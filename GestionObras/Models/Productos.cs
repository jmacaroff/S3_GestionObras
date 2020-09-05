using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionObras.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Observacion { get; set; }

    }
}
