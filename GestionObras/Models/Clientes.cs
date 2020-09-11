using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionObras.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Solo se aceptan 11 digitos")]
        [Column(TypeName = "nchar(11)")]
        public string NRCUIT{ get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(100, ErrorMessage = "Solo se aceptan 100 digitos maximo")]
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }


        [StringLength(100, ErrorMessage = "Solo se aceptan 100 digitos")]
        [Column(TypeName = "varchar(100)")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "Solo se aceptan 20 digitos")]
        [RegularExpression(@"^\d+", ErrorMessage = "Solo se aceptan numeros")]
        [Column(TypeName = "nvarchar(20)")]
        public string Telefono { get; set; }


        [EmailAddress (ErrorMessage = "Ingrese un email valido")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
    }
}
