namespace MiApiDDD.Dominio.Entidades
{
    public class Rol
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } // Asumiendo que puede ser nullable
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int Estado { get; set; }

        // Propiedades de navegación
        public ICollection<RolUsuario> RolUsuarios { get; set; }
        public ICollection<PermisoRol> PermisoRoles { get; set; }

        public Rol()
        {
            RolUsuarios = new HashSet<RolUsuario>();
            PermisoRoles = new HashSet<PermisoRol>();
        }
    }
}