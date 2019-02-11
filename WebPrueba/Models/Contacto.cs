using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPrueba.Models
{
    public class Contacto
    {
        [Key]
        public Int64 ID_CONTACTO { get; set; }

        [Required]
        [StringLength(20)]
        public string IDENTIFICACION { get; set; }

        [Required]
        [StringLength(250)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(200)]
        [EmailAddress]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string CELULAR { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime FECHA_SOLICITUD { get; set; }

        [StringLength(500)]
        public string DESCRIPCION { get; set; }


    }
}