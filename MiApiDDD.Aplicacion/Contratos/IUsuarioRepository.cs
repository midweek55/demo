namespace MiApiDDD.Aplicacion.Contratos
{
    public interface IUsuarioRepository
    {
        Task<List<string>> ObtenerNombresModulosPorUsuarioIdAsync(Guid usuarioId);
    }
}