using LogicaNegocio;
using Model;
using ServicioREST.Common;
using ServicioREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ServicioREST.Common.Constantes;

namespace ServicioREST.Controllers
{
    public class ContactoController : ApiController
    {
        /// <summary>
        /// Metodo: GET
        /// encargardo de traer todos los datos que devuelve la logica de negocio de la tabla contacto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Contacto")]
        public HttpResponseMessage Get()
        {
            EstructuraModel datos = new EstructuraModel();

            try
            {

                var listado = new ContactoLN().Consultar();
                if (listado.Count > 0)
                {
                    datos.responseData = listado;
                    datos.responseDetails = Constantes.Respuestas.Correcta;
                    datos.responseStatus = (int)EnumEstado.Correcto;
                }
                else if (listado.Count == 0)
                {
                    datos.responseDetails = Constantes.Respuestas.Vacio;
                    datos.responseStatus = (int)EnumEstado.Vacio;
                }

                return Request.CreateResponse(HttpStatusCode.OK, datos);
            }
            catch (Exception ex)
            {
                datos.responseDetails = Constantes.Respuestas.Error;
                datos.responseStatus = (int)EnumEstado.Error;

                return Request.CreateResponse(HttpStatusCode.InternalServerError, datos);
            }


        }
        /// <summary>
        /// Método GET.
        /// Que recibe el id del registro
        /// y devuelve un registro con los datos del id suministrado
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Contacto/{Id}")]
        public HttpResponseMessage Get(int Id)
        {
            EstructuraModel datos = new EstructuraModel();
            var listado = new List<Contacto>();

            try
            {

                var registro = new ContactoLN().ObtenerRegistro(Id);
                if (registro != null)
                {
                    listado.Add(registro);
                    datos.responseData = listado;
                    datos.responseDetails = Constantes.Respuestas.Correcta;
                    datos.responseStatus = (int)EnumEstado.Correcto;
                }
                else
                {
                    datos.responseDetails = Constantes.Respuestas.Vacio;
                    datos.responseStatus = (int)EnumEstado.Vacio;
                }

                return Request.CreateResponse(HttpStatusCode.OK, datos);
            }
            catch (Exception ex)
            {
                datos.responseDetails = Constantes.Respuestas.Error;
                datos.responseStatus = (int)EnumEstado.Error;

                return Request.CreateResponse(HttpStatusCode.InternalServerError, datos);
            }


        }

        /// <summary>
        /// Metodo:  PUT
        /// Encargado de actualizar los datos de un registro
        /// llama la logica de negocio el método editar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Contacto")]
        public HttpResponseMessage Put([FromBody]Contacto item)
        {
            String Mensaje = "";
            ContactoLN objLogica = new ContactoLN();
            Contacto registro;
            ResultadoModel datos = new ResultadoModel();
            try
            {


                if (item != null)
                {
                    if (!ModelState.IsValid)
                    {
                        var errors = ModelState.Select(x => x.Value.Errors)
                               .Where(y => y.Count > 0)
                               .ToList();

                        datos.responseDetails = Mensaje;
                        datos.responseStatus = (int)EnumEstado.NoAceptado;
                        return Request.CreateResponse<ResultadoModel>(HttpStatusCode.NotAcceptable, datos);
                    }

                    registro = objLogica.ObtenerRegistro(item.ID_CONTACTO);
                    if (registro != null)
                    {
                        if (item.ID_CONTACTO == 0)
                            Mensaje = "Id Contacto es requerido";

                        if (String.IsNullOrEmpty(item.NOMBRE))
                            Mensaje = "El nombre es requerido";
                        if (String.IsNullOrEmpty(item.IDENTIFICACION))
                            Mensaje = "la identificación es requerido";
                        if (String.IsNullOrEmpty(item.EMAIL))
                            Mensaje = "el email es requerido";
                        if (String.IsNullOrEmpty(item.CELULAR))
                            Mensaje = "el celular es requerido";

                        if (!String.IsNullOrEmpty(Mensaje))
                        {
                            datos.responseDetails = Mensaje;
                            datos.responseStatus = (int)EnumEstado.NoAceptado;

                        }
                        else
                        {
                            registro = item;
                            objLogica.Editar(registro);
                            datos.responseDetails = Constantes.Respuestas.Correcta;
                            datos.responseStatus = (int)EnumEstado.Correcto;
                            datos.Id = item.ID_CONTACTO.ToString();
                        }
                    }
                    else
                    {
                        datos.responseDetails = Constantes.Respuestas.Vacio;
                        datos.responseStatus = (int)EnumEstado.Vacio;
                    }
                }
                else
                {
                    datos.responseDetails = "El registro no puede ser nulo";
                    datos.responseStatus = (int)EnumEstado.NoAceptado;

                }

                return Request.CreateResponse<ResultadoModel>(HttpStatusCode.OK, datos);

            }
            catch (Exception ex)
            {
                datos.responseDetails = Constantes.Respuestas.Error;
                datos.responseStatus = (int)EnumEstado.Error;
                return Request.CreateResponse<ResultadoModel>(HttpStatusCode.InternalServerError, datos);
            }
        }

        /// <summary>
        /// Métodos POST.
        /// encargado de crear un nuevo registro.
        /// Este método llama a la capa de logica de negocio
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Contacto")]
        public HttpResponseMessage Post([FromBody]Contacto item)
        {
            String Mensaje = "";
            ContactoLN objLogica = new ContactoLN();
            ResultadoModel datos = new ResultadoModel();
            try
            {

                if (item != null)
                {
                    if (!ModelState.IsValid)
                    {
                        var errors = ModelState.Select(x => x.Value.Errors)
                               .Where(y => y.Count > 0)
                               .ToList();

                        datos.responseDetails = Mensaje;
                        datos.responseStatus = (int)EnumEstado.NoAceptado;
                        return Request.CreateResponse<ResultadoModel>(HttpStatusCode.NotAcceptable, datos);
                    }

                    if (item != null)
                    {
                        //se realizan validaciones para verificar los datos requeridos

                        if (String.IsNullOrEmpty(item.NOMBRE))
                            Mensaje = "El nombre es requerido";
                        if (String.IsNullOrEmpty(item.IDENTIFICACION))
                            Mensaje = "la identificación es requerido";
                        if (String.IsNullOrEmpty(item.EMAIL))
                            Mensaje = "el email es requerido";
                        if (String.IsNullOrEmpty(item.CELULAR))
                            Mensaje = "el celular es requerido";

                        if (!String.IsNullOrEmpty(Mensaje))
                        {
                            datos.responseDetails = Mensaje;
                            datos.responseStatus = (int)EnumEstado.NoAceptado;
                        }
                        else
                        {
                            var registro = new Contacto
                            {
                                IDENTIFICACION = item.IDENTIFICACION,
                                NOMBRE = item.NOMBRE,
                                CELULAR = item.CELULAR,
                                DESCRIPCION = item.DESCRIPCION,
                                EMAIL = item.EMAIL,
                                FECHA_SOLICITUD = DateTime.Now,
                                ID_CONTACTO = 0

                            };

                            //llama al método agregar de la logica de negocio
                            Int64 Id = objLogica.Agregar(registro);
                            datos.responseDetails = Constantes.Respuestas.Correcta;
                            datos.responseStatus = (int)EnumEstado.Correcto;
                            datos.Id = Id.ToString();

                        }
                    }
                    else
                    {
                        datos.responseDetails = Constantes.Respuestas.Vacio;
                        datos.responseStatus = (int)EnumEstado.Vacio;
                    }
                }
                else
                {
                    datos.responseDetails = "El registro no puede ser nulo";
                    datos.responseStatus = (int)EnumEstado.NoAceptado;
                }

                return Request.CreateResponse<ResultadoModel>(HttpStatusCode.OK, datos);

            }
            catch (Exception ex)
            {
                datos.responseDetails = Constantes.Respuestas.Error;
                datos.responseStatus = (int)EnumEstado.Error;
                return Request.CreateResponse<ResultadoModel>(HttpStatusCode.InternalServerError, datos);
            }
        }
    }
}
