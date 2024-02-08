using MiApiDDD.Dominio.Interfaces;

namespace MiApiDDD.Aplicacion.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<List<string>> ObtenerNombresModulosPorUsuarioId(Guid usuarioId)
        {
            // Utiliza el repositorio para obtener la información requerida
            var nombresModulos = await _usuarioRepository.ObtenerNombresModulosPorUsuarioIdAsync(usuarioId);
            return nombresModulos;
        }
    }
}