using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiApiDDD.Aplicacion.DTOs;

namespace MiApiDDD.Dominio.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<string>> ObtenerNombresModulosPorUsuarioIdAsync(Guid usuarioId);
        Task<UsuarioDto> ObtenerDetallesUsuarioAsync(Guid usuarioId);
    }
}