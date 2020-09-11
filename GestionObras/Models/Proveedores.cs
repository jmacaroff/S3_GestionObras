using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionObras.Models
{
    public class Proveedores
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Column(TypeName = "varchar(100)")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Solo se aceptan 11 digitos")]
        [Column(TypeName = "nchar(11)")]
        public string NRCUIT{ get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(22)]
        [RegularExpression(@"^\d{22}$", ErrorMessage = "Solo se aceptan 22 digitos")]
        [Column(TypeName = "nchar(22)")]
        public string NRCBU { get; set; }


        [StringLength(100, ErrorMessage = "Solo se aceptan 100 digitos")]
        [Column(TypeName = "varchar(100)")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "Solo se aceptan 20 digitos")]
        [RegularExpression(@"^\d+", ErrorMessage = "Solo se aceptan numeros")]
        [Column(TypeName = "nchar(20)")]
        public string Telefono { get; set; }


        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

    }
}
