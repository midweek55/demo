using System;
using System.Collections.Generic;
using MiApiDDD.Dominio.Entidades.MiApiDDD.Dominio.Entidades;

namespace MiApiDDD.Dominio.Entidades
{
    public class AccionModulo
    {
        // Constructor sin parámetros para EF Core
        public AccionModulo()
        {
            PermisoRoles = new HashSet<PermisoRol>();
        }

        // Constructor con parámetros para la creación de instancias (opcional)
        public AccionModulo(Guid id, Guid idmodulo, string nombre, DateTime fechacreacion, DateTime fechaactualizacion, int? estado)
        {
            ID = id;
            IDMODULO = idmodulo;
            NOMBRE = nombre;
            FECHACREACION = fechacreacion;
            FECHAACTUALIZACION = fechaactualizacion;
            ESTADO = estado;
        }

        public Guid ID { get; set; }
        public Guid IDMODULO { get; set; }
        public string NOMBRE { get; set; }
        public DateTime FECHACREACION { get; set; }
        public DateTime FECHAACTUALIZACION { get; set; }
        public int? ESTADO { get; set; }

        public Modulo Modulo { get; set; } // Propiedad de navegación hacia Modulo
        public ICollection<PermisoRol> PermisoRoles { get; set; } // Propiedad de navegación hacia PermisoRol
    }
}