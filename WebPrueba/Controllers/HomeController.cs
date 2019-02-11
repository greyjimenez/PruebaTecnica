using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebPrueba.Models;

namespace WebPrueba.Controllers
{
    /// <summary>
    /// Proyecto de MVC.NET.  encargado de la capa de presentación.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// se guarda la url del web api.
        /// Es importante ejecutar el proyecto ServicioRest
        /// Método Get que carga el listado de personas que se han contactado.
        /// consume el servicio web api y consume el servicio get
        /// </summary>
        string Baseurl = "http://localhost:50172/";
        public async Task<ActionResult> Index()
        {
            List<ContactoModel> EmpInfo = new List<ContactoModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Contacto");


                if (Res.IsSuccessStatusCode)
                {

                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    dynamic content = JsonConvert.DeserializeObject(EmpResponse);
                    var array = content.responseData;

                    if (array != null)
                    {
                        foreach (JObject objeto in array)
                        {
                            var datos = new ContactoModel();
                            string value = "";
                            foreach (JProperty item in objeto.Properties())
                            {

                                if (item.Name == "NOMBRE")
                                {
                                    value = item.Value.ToString();
                                    datos.NOMBRE = value;
                                }

                                if (item.Name == "EMAIL")
                                {
                                    value = item.Value.ToString();
                                    datos.EMAIL = value;
                                }

                                if (item.Name == "CELULAR")
                                {
                                    value = item.Value.ToString();
                                    datos.CELULAR = value;
                                }

                                if (item.Name == "IDENTIFICACION")
                                {
                                    value = item.Value.ToString();
                                    datos.IDENTIFICACION = value;
                                }

                                if (item.Name == "FECHA_SOLICITUD")
                                {
                                    value = item.Value.ToString();
                                    datos.FECHA_SOLICITUD = Convert.ToDateTime(value);
                                }
                            }

                            EmpInfo.Add(datos);
                        }
                    }
                }
                return View(EmpInfo);
            }

        }

        /// <summary>
        /// Metodo get que carga el formulario de contacto
        /// </summary>
        /// <returns></returns>

        public ActionResult Contact()
        {
            var model = new ContactoModel();

            return View(model);
        }

        /// <summary>
        /// Método Post.  que  consume el servicio web api para guardar los datos diligenciados en el formulario de contacto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact(ContactoModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl + "api/Contacto");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ContactoModel>("Contacto", model);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(model);
        }
    }
}