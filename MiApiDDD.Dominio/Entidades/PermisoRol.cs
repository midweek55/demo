namespace MiApiDDD.Dominio.Entidades
{
    public class PermisoRol
    {
        public PermisoRol()
        {
        }

        public Guid ID { get; set; }
        public Guid IDROL { get; set; }
        
        public Rol ROL { get; set; }
        public Guid IDPERMISOMODULO { get; set; } // Asume que esta es la FK hacia AccionModulo
        public DateTime FECHACREACION { get; set; }
        public DateTime FECHAACTUALIZACION { get; set; }
        public int ESTADO { get; set; }

        // Propiedad de navegación hacia AccionModulo
        public AccionModulo AccionModulo { get; set; }

        // Propiedades de navegación adicionales y configuraciones...
    }
}