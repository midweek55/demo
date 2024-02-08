namespace MiApiDDD.Dominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }

        public virtual ICollection<RolUsuario> RolUsuarios { get; set; } = new List<RolUsuario>();
        
        private Usuario() { }
        
        public Usuario(string login, string nombres, string apellidos)
        {
            Id = Guid.NewGuid();
            Login = login;
            Nombres = nombres;
            Apellidos = apellidos;
        }
        
    }
}