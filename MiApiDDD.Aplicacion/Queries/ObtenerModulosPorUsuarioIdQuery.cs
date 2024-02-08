using MediatR;
using System;
using System.Collections.Generic;

namespace MiApiDDD.Aplicacion.Queries
{
    public class ObtenerModulosPorUsuarioIdQuery : IRequest<List<string>>
    {
        public Guid UsuarioId { get; }

        public ObtenerModulosPorUsuarioIdQuery(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}