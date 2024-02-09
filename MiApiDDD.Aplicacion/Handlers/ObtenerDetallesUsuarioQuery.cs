using MediatR;
using MiApiDDD.Dominio.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MiApiDDD.Aplicacion.Queries;
using UsuarioDto = MiApiDDD.Common.DTOs.UsuarioDto;

namespace MiApiDDD.Aplicacion.Handlers
{
    public class ObtenerDetallesUsuarioHandler : IRequestHandler<ObtenerDetallesUsuarioQuery, UsuarioDto>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObtenerDetallesUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto?> Handle(ObtenerDetallesUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.ObtenerDetallesUsuarioAsync(request.UsuarioId);
        }
    }
}