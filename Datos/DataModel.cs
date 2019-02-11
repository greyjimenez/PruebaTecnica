namespace Datos
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// en el proyecto model se crea el modelo de la tablas y aque se crea el contexto.
    /// se utiliza entity framework
    /// Code FIrst.  Cree el modelo con clases y luego ya se encargará el sistema de traspasarlo a la base de datos. para este caso se creo un nuevo esquema en una base datos oracle.  Ya tenia instalado en mi computadora Oracle 
    /// </summary>
    public class DataModel : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'DataModel' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'Datos.DataModel' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'DataModel'  en el archivo de configuración de la aplicación.
        public DataModel()
            : base("DataModel")
        {
        }


        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        //Tablas del modelo de datos
        public virtual DbSet<Contacto> CONTACTO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataModel>(null);
            modelBuilder.HasDefaultSchema("PRUEBA_TECNICA");

            
        }
    }

   
}