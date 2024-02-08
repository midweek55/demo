using MediatR;
using MiApiDDD.Aplicacion.Queries;
using MiApiDDD.Dominio.Interfaces;

namespace MiApiDDD.Aplicacion.Handlers;

public class ObtenerModulosPorUsuarioIdHandler : IRequestHandler<ObtenerModulosPorUsuarioIdQuery, List<string>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ObtenerModulosPorUsuarioIdHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<string>> Handle(ObtenerModulosPorUsuarioIdQuery request, CancellationToken cancellationToken)
    {
        return await _usuarioRepository.ObtenerNombresModulosPorUsuarioIdAsync(request.UsuarioId);
    }
}