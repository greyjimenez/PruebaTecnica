using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPrueba.Models
{
    public class ContactoModel
    {
        public Int64 ID_CONTACTO { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "La longitud de la identificación debe ser mínimo de 4 caracteres y máximo de 20", MinimumLength = 4)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "La identificación debe ser solo números")]
        [Display(Name = "Identificación")]
        public string IDENTIFICACION { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "La longitud del nombre debe ser mínimo de 4 caracteres y máximo de 250", MinimumLength = 4)]
        [Display(Name = "Nombre completo")]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "La longitud del email debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EMAIL { get; set; }

        [Required]
        //[StringLength(20)]
        [Display(Name = "Celular")]
        [StringLength(10, ErrorMessage = "La longitud del celular debe ser mínimo de 7 caracteres y máximo de 10", MinimumLength = 7)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El celular debe ser solo números")]
        public string CELULAR { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime FECHA_SOLICITUD { get; set; }

        [StringLength(500, ErrorMessage = "La longitud de la descripción debe ser mínimo de 4 caracteres y máximo de 500", MinimumLength = 4)]
        public string DESCRIPCION { get; set; }
    }
}