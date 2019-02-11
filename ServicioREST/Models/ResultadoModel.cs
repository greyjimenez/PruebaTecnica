using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioREST.Models
{
    public class ResultadoModel
    {
        public string Id { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }
}