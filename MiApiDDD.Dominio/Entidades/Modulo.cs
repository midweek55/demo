namespace MiApiDDD.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;

    namespace MiApiDDD.Dominio.Entidades
    {
        public class Modulo
        {
            public Guid ID { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public Guid? IDModuloPadre { get; set; } // Opcional, para estructuras jerárquicas
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaActualizacion { get; set; }
            public int Estado { get; set; }

            // Propiedad de navegación hacia el módulo padre en una estructura jerárquica
            public Modulo ModuloPadre { get; set; }

            // Colección para módulos hijos en una estructura jerárquica
            public ICollection<Modulo> ModulosHijos { get; set; }

            // Propiedades de navegación hacia AccionModulo
            public ICollection<AccionModulo> AccionModulos { get; set; }

            public Modulo()
            {
                ModulosHijos = new HashSet<Modulo>();
                AccionModulos = new HashSet<AccionModulo>();
            }
        }
    }
}