namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablaContacto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PRUEBA_TECNICA.CONTACTO",
                c => new
                    {
                        ID_CONTACTO = c.Decimal(nullable: false, precision: 19, scale: 0, identity: true),
                        IDENTIFICACION = c.String(nullable: false, maxLength: 20),
                        NOMBRE = c.String(nullable: false, maxLength: 250),
                        EMAIL = c.String(nullable: false, maxLength: 200),
                        CELULAR = c.String(nullable: false, maxLength: 20),
                        FECHA_SOLICITUD = c.DateTime(nullable: false),
                        DESCRIPCION = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID_CONTACTO);
            
        }
        
        public override void Down()
        {
            DropTable("PRUEBA_TECNICA.CONTACTO");
        }
    }
}
