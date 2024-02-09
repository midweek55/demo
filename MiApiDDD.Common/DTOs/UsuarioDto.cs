namespace MiApiDDD.Common.DTOs
{
    public class UsuarioDto
    { 
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string? Rol { get; set; }
        
        public List<string> Modulos { get; set; }
    }
}