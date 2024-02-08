using MediatR;
using MiApiDDD.Aplicacion.DTOs;

namespace MiApiDDD.Aplicacion.Queries
{
    public class ObtenerDetallesUsuarioQuery : IRequest<UsuarioDto>
    {
        public Guid UsuarioId { get; }

        public ObtenerDetallesUsuarioQuery(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}