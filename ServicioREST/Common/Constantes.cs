using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioREST.Common
{
   
    public static class Constantes
    {
        public enum EnumEstado
        {
            Correcto = 200,
            Error = 500,
            Vacio = 404,
            Nuevo = 201,
            Eliminar = 204,
            NoAceptado = 406

        }

        public static class Respuestas
        {
            public const string Correcta = "Respuesta Correcta";
            public const string Vacio = "Respuesta Vacía";
            public const string Error = "Error en el servidor";
            public const string Nuevo = "Nuevo recurso";
            public const string Eliminar = "El registro fue eliminado";
            public const string NoACeptado = "El registro no fue aceptado";
        }
    }
}