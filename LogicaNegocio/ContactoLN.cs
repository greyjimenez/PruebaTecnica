using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    /// <summary>
    /// Logica de negocio.  Encargada de ejecutar toda la logica y llamar la conexion de datos.
    /// </summary>
    public class ContactoLN
    {
        public List<Contacto> Consultar()
        {
            List<Contacto> listado = new List<Contacto>();

            try
            {
                using (var context = new DataModel())
                {

                    listado = context.CONTACTO.ToList();

                }
                return listado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contacto ObtenerRegistro(Int64 Id)
        {
            var listado = new Contacto();

            try
            {
                using (var context = new DataModel())
                {

                    listado = context.CONTACTO.Where(X => X.ID_CONTACTO == Id).FirstOrDefault();

                }
                return listado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 Agregar(Contacto registro)
        {
            Int64 Id = 0;
            try
            {
                using (var context = new DataModel())
                {

                    context.CONTACTO.Add(registro);
                    context.SaveChanges();
                    Id = registro.ID_CONTACTO;
                }
                return Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Editar(Contacto registro)
        {
            Int64 Id = 0;
            try
            {
                using (var context = new DataModel())
                {

                    var modelo = context.CONTACTO.Where(X => X.ID_CONTACTO == registro.ID_CONTACTO).FirstOrDefault();
                    modelo = registro;
                    context.SaveChanges();
                    Id = registro.ID_CONTACTO;
                }
             

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
